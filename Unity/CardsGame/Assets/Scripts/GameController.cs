using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AllInDeckCards
{
    public Texture cardImage;
}
[RequireComponent(typeof(DragAndDrop))]

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<AllInDeckCards> deckCards = new List<AllInDeckCards>();

    [HideInInspector]
    public List<Texture> cardsInDeck = new List<Texture>();

    public Texture cardBackTexture;

    public Vector3 cardSizes = new Vector3(1, 1, 1);

    public Vector3 deckPosition = new Vector3(0, 0, 0);

    public GameObject prefabForCards;

    public GameObject activeCard, deck;

    private Ray ray;

    private RaycastHit rayHit;

    public float cardPicupHeight = 2f;

    public LayerMask deckLayer, playerLayer, cardLayer, endLayer, tableLayer, warLayer;

    private DragAndDrop dad;

    private void Start()
    {
        if (!GetComponent<DragAndDrop>())
            dad = gameObject.AddComponent<DragAndDrop>();

        dad = GetComponent<DragAndDrop>();
        CreateDeckOfCards();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        dad.CardTouched(ray, rayHit);
                    }
                    else if (Input.GetTouch(i).phase == TouchPhase.Moved)
                    {
                        if (activeCard == null)
                            return;

                        dad.Drag(ray, rayHit);
                    }
                    else if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled)
                    {
                        if (activeCard == null)
                            return;

                        dad.Drop(ray, rayHit);
                    }
                }
            }
        }
        else { activeCard = null; }
    }

    public void CreateDeckOfCards()
    {
        if (deck != null)
        {
            Destroy(deck);
            DestroyAllCards();
            cardsInDeck.Clear();
        }
        #region Shuffle
        for (var i = 0; i < deckCards.Count - 1; ++i)
        {
            int r = Random.Range(i, deckCards.Count - 1);
            Texture tmp = deckCards[i].cardImage;
            deckCards[i].cardImage = deckCards[r].cardImage;
            deckCards[r].cardImage = tmp;
        }
        #endregion

        for (int i = 0; i < deckCards.Count; i++)
        {
            cardsInDeck.Add(deckCards[i].cardImage);
        }

        #region Deck creation
        deck = Instantiate(prefabForCards);
        deck.AddComponent<BoxCollider>().center = Vector3.zero;
        deck.transform.localScale = new Vector3(cardSizes.x, cardSizes.y * cardsInDeck.Count, cardSizes.z);

        deck.transform.position = new Vector3(deckPosition.x, .5f + cardsInDeck.Count * (cardSizes.y / 2f), deckPosition.z);

        if (cardBackTexture != null)
            deck.GetComponent<MeshRenderer>().material.mainTexture = cardBackTexture;

        deck.name = "Deck of " + cardsInDeck.Count + " cards";
        deck.layer = LayerValue(deckLayer);
        #endregion

        StartGame();
    }

    public int LayerValue(int _layer)
    {
        int layer = 2;
        for (int i = 1; i < 15; i++)
        {
            if (layer == _layer)
            {
                layer = i;
                return layer;
            }
            else
                layer *= 2;
        }
        return 0;
    }

    public void ClearOut()
    {
        GameObject[] tmp = new GameObject[2];
        tmp = FindGameObjects(warLayer, endLayer);
        TransportAllCards(tmp);
    }

    public void TakeForYou()
    {
        GameObject[] tmp = new GameObject[2];
        tmp = FindGameObjects(warLayer, playerLayer);
        TransportAllCards(tmp);
    }

    void DestroyAllCards()
    {
        GameObject[] tmp = new GameObject[deckCards.Count];
        tmp = FindObjectsOfType<GameObject>();
        for (int i = 0; i < tmp.Length; i++)
        {
            if (tmp[i].layer == LayerValue(cardLayer))
            {
                Destroy(tmp[i]);
            }
        }
    }
    void TransportAllCards(GameObject[] targets)
    {
        for (int i = 0; i < targets[0].transform.childCount; i++)
        {
            targets[0].transform.GetChild(i).gameObject.AddComponent<CardController>().DropCard(targets[1].transform.position + new Vector3(0, .5f, 0), targets[1]);
        }
    }

    void StartGame()
    {
        for (int i = 0; i < 6; i++)
        {
            activeCard = Instantiate(prefabForCards);
            activeCard.name = "Card";
            activeCard.layer = LayerValue(cardLayer);
            activeCard.transform.localScale = cardSizes;
            activeCard.transform.position = deckPosition;
            activeCard.GetComponent<MeshRenderer>().material.mainTexture = cardsInDeck[cardsInDeck.Count - 1];
            cardsInDeck.Remove(cardsInDeck[cardsInDeck.Count - 1]);

            GameObject[] tmp = new GameObject[2];
            tmp = FindGameObjects(deckLayer, playerLayer);

            activeCard.transform.position = tmp[1].transform.position+new Vector3(0,.5f,0);
            activeCard.transform.SetParent(tmp[1].transform);

            activeCard.AddComponent<BoxCollider>().center = Vector3.zero;
        }
        deck.name = "Deck of " + cardsInDeck.Count + " cards";
    }
    GameObject[] FindGameObjects(LayerMask from,LayerMask to)
    {
        GameObject[] tmp = new GameObject[2];
        GameObject[] allGO = FindObjectsOfType<GameObject>();
        for(int i = 0; i < allGO.Length; i++)
        {
            if (allGO[i].layer == LayerValue(from))
            {
                tmp[0] = allGO[i];
            }
            if (allGO[i].layer == LayerValue(to))
            {
                tmp[1] = allGO[i];
            }
        }
        return tmp;
    }
}