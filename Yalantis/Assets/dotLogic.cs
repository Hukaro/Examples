using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dotLogic : MonoBehaviour
{
    Vector2 fingerPos, startPos;
    InfoHolder ih;

    float mult;

    void Start()
    {
        ih = FindObjectOfType<InfoHolder>();
        GetComponent<Image>().color = Color.green;
        startPos = GetComponent<RectTransform>().anchoredPosition;
        TakeItsPlase(startPos);
    }

    void Update()
    {
        try
        {
            float dist = Vector2.Distance(Input.GetTouch(0).position, GetComponent<RectTransform>().anchoredPosition);
            if (dist > ih.pointDist)
                TakeItsPlase(startPos);
        }
        catch
        {
            TakeItsPlase(startPos);
        }
    }

    void Move()
    {
        fingerPos.x = ((Screen.width / 2) - fingerPos.x) * -1;
        fingerPos.y = ((Screen.height / 2) - fingerPos.y) * -1;

        Vector2 dir = GetComponent<RectTransform>().anchoredPosition - fingerPos;

        GetComponent<RectTransform>().transform.Translate(dir * ih.dotSpeed * mult * Time.deltaTime);
    }

    void TakeItsPlase(Vector2 fingerPos)
    {
        Vector2 dir = fingerPos - GetComponent<RectTransform>().anchoredPosition;

        GetComponent<RectTransform>().transform.Translate(dir * ih.dotSpeed * Time.deltaTime);
    }

    public void TakeData(Vector2 fingerPos)
    {
        this.fingerPos = fingerPos;

        fingerPos.x = ((Screen.width / 2) - fingerPos.x) * -1;
        fingerPos.y = ((Screen.height / 2) - fingerPos.y) * -1;

        float dist = Vector2.Distance(fingerPos, GetComponent<RectTransform>().anchoredPosition);

        mult = (ih.pointDist - dist) * .5f;

        Move();
    }
}