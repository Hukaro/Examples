using UnityEngine;
using System.Collections;

public class MazzleFlash : MonoBehaviour {

    public GameObject flashHolder;

    public Sprite[] flashSprites;
    public SpriteRenderer[] spriteRenderers;

    void Start()
    {
        Deactivate();
    }

    public float flashTime;

    public void Activate()
    {
        flashHolder.SetActive(true);

        int flashStiteIndex = Random.Range(0, flashSprites.Length);
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sprite = flashSprites[flashStiteIndex];
        }

            Invoke("Deactivate", flashTime);
    }
    void Deactivate()
    {
        flashHolder.SetActive(false);
    }
}
