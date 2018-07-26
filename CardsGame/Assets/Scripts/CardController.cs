using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private GameController GC = new GameController();
    private bool move = false;
    private float speed = 30f;
    [SerializeField]
    private Vector3 targetPos;
    [SerializeField]
    private GameObject parent;

    private void Update()
    {
        if (move)
        {
            Move(parent);
        }
    }

    public void DropCard(Vector3 _targetPos, GameObject _parent)
    {
        GC = FindObjectOfType<GameController>();

        targetPos = _targetPos;
        parent = _parent;

        if (_parent == null || _parent.gameObject.layer == GC.LayerValue(GC.tableLayer))
            GC.cardsInDeck.Add(GetComponent<MeshRenderer>().material.mainTexture);

        if (GC.deck == null && _parent == null)
        {
            GC.deck = gameObject;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            if (GC.cardBackTexture != null)
                GetComponent<MeshRenderer>().material.mainTexture = GC.cardBackTexture;
            gameObject.AddComponent<BoxCollider>().center = Vector3.zero;
            name = "Deck of 1 card";
            gameObject.layer = GC.LayerValue(GC.deckLayer);
            targetPos += new Vector3(0, .5f, 0);
        }

        GC.activeCard = null;
        move = true;
    }

    private void Move(GameObject _parent)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        if (transform.position == targetPos)
        {
            move = false;

            if (!GetComponent<BoxCollider>())
                gameObject.AddComponent<BoxCollider>();
            GetComponent<BoxCollider>().center = Vector3.zero;
            GetComponent<BoxCollider>().size = new Vector3(1.5f, 1f, 1.5f);

            if (_parent != null)
            {
                transform.SetParent(_parent.transform);
                Destroy(this);
            }
            else if (_parent == null && GC.deck != null && gameObject.layer != GC.LayerValue(GC.deckLayer))
            {
                Destroy(gameObject);
            }
        }
    }
}