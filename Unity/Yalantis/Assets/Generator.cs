using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Generator : MonoBehaviour
{

    InfoHolder ih;

    [Range(2, 10)]
    public float k;

    GameObject DotsHolder;

    void Start()
    {
        try
        {
            DotsHolder = GameObject.FindGameObjectWithTag("dots holder");
        }
        catch { return; }
        ih = FindObjectOfType<InfoHolder>();
        Generate();
    }

    public void Generate()
    {
        //StartCoroutine(GenerateFunc());
        StartCoroutine(GenerateByPattern());
    }

    /*IEnumerator GenerateFunc()
    {
        //num = 1;

        if (DotsHolder.transform.childCount > 0)
        {
            foreach (Transform child in DotsHolder.transform)
            {
                Destroy(child.gameObject);
            }
        }

        float firstX = -(Screen.height / 4);
        float firstY = -firstX;

        for (float y = firstY; y >= -firstY; y -= ih.dotSize * k)
        {
            for (float x = firstX; x <= -firstX; x += ih.dotSize * k)
            {
                CreateDots(x, y);
                yield return null;
            }
        }
    }/**/

    void CreateDots(float X, float Y)//, Vector2 size)
    {
        Vector2 pos = new Vector2(X, Y);

        GameObject newDot = new GameObject();
        newDot.transform.SetParent(DotsHolder.transform);
        newDot.AddComponent<RectTransform>().sizeDelta = new Vector2(ih.dotSize, ih.dotSize);
        newDot.AddComponent<Image>().sprite = ih.ImageForDots;
        newDot.GetComponent<Image>().raycastTarget = false;

        newDot.AddComponent<CircleCollider2D>().isTrigger = true;

        newDot.AddComponent<dotLogic>();
        newDot.tag = "dot";

        newDot.GetComponent<RectTransform>().anchoredPosition = pos;
    }

    IEnumerator GenerateByPattern()
    {
        int randomShape = Random.Range(0, ih.shapesForDots.Count);
        Texture2D txtr = ih.shapesForDots[randomShape].img.texture;
        //Vector2 size = new Vector2(Screen.width / ih.shapesForDots[randomShape].img.texture.width, Screen.height / ih.shapesForDots[randomShape].img.texture.height);
        //Debug.Log(size);
        for (float y = 0; y < txtr.height; y += ih.dotSize * ih.mult)
        {
            for (float x = 0; x < txtr.width; x += ih.dotSize * ih.mult)
            {
                if (txtr.GetPixel(Mathf.RoundToInt(x), Mathf.RoundToInt(y)) == Color.black)// && y % 2 != 0 && x % 2 != 0)
                {
                    CreateDots(x, y);//, size);
                    yield return null;
                }
            }
        }
    }
}