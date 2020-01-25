using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    GameController GC;
    private void Start()
    {
        if (!GetComponent<GameController>())
        {
            Debug.Log("No game controller!!!!");
            return;
        }
        GC = GetComponent<GameController>();
    }

    public void Drag(Ray ray, RaycastHit hit)
    {
        GC.activeCard.transform.position = new Vector3(hit.point.x, GC.cardPicupHeight, hit.point.z);

        if (hit.collider.gameObject.layer == GC.LayerValue(GC.playerLayer) || hit.collider.gameObject.layer == GC.LayerValue(GC.warLayer))
        {
            GC.activeCard.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (hit.collider.gameObject.layer == GC.LayerValue(GC.tableLayer)|| hit.collider.gameObject.layer == GC.LayerValue(GC.endLayer))
        {
            GC.activeCard.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }

    public void Drop(Ray ray,RaycastHit hit)
    {
        if (hit.collider.gameObject.layer == GC.LayerValue(GC.tableLayer))
        {
            GC.activeCard.AddComponent<CardController>().DropCard(GC.deckPosition, null);
        }
        else if(hit.collider.gameObject.layer == GC.LayerValue(GC.playerLayer)|| hit.collider.gameObject.layer == GC.LayerValue(GC.warLayer))
        {
            GC.activeCard.AddComponent<CardController>().DropCard(hit.point, hit.collider.gameObject);
        }
        else if(hit.collider.gameObject.layer == GC.LayerValue(GC.cardLayer) && hit.collider.gameObject.transform.parent.gameObject.layer != GC.LayerValue(GC.endLayer))
        {
            GC.activeCard.AddComponent<CardController>().DropCard(hit.point, hit.collider.gameObject.transform.parent.gameObject);
        }
        else
        {
            GC.activeCard.AddComponent<CardController>().DropCard(GC.deckPosition, null);
        }
    }

    public void CardTouched(Ray ray, RaycastHit hit)
    {
        if (hit.collider.gameObject.layer == GC.LayerValue(GC.deckLayer))
        {
            CreateCard(hit);
            if (GC.deck.transform.localScale.y > GC.cardSizes.y)
            {
                GC.deck.transform.localScale = new Vector3(GC.cardSizes.x, GC.cardSizes.y * GC.cardsInDeck.Count, GC.cardSizes.z);
                GC.deck.transform.position = new Vector3(GC.deck.transform.position.x, .5f + GC.cardsInDeck.Count * GC.cardSizes.y / 2f, GC.deck.transform.position.z);
                GC.deck.name = "Deck of " + GC.cardsInDeck.Count + " cards";
            }
            else
            {
                Destroy(GC.deck);
            }
        }
        else if (hit.collider.gameObject.layer == GC.LayerValue(GC.cardLayer))
        {
            GC.activeCard = hit.collider.gameObject;
            if (GC.activeCard.transform.parent)
                GC.activeCard.transform.SetParent(null);
            if (GC.activeCard.transform.GetComponent<BoxCollider>())
                Destroy(GC.activeCard.transform.GetComponent<BoxCollider>());
        }
    }

    void CreateCard(RaycastHit hit)
    {
        GC.activeCard = Instantiate(GC.prefabForCards);
        GC.activeCard.name = "Card";
        GC.activeCard.layer = GC.LayerValue(GC.cardLayer);
        GC.activeCard.transform.localScale = GC.cardSizes;
        GC.activeCard.transform.position = new Vector3(hit.point.x, GC.cardPicupHeight, hit.point.z);
        GC.activeCard.GetComponent<MeshRenderer>().material.mainTexture = GC.cardsInDeck[GC.cardsInDeck.Count - 1];
        GC.cardsInDeck.Remove(GC.cardsInDeck[GC.cardsInDeck.Count - 1]);
    }
}
