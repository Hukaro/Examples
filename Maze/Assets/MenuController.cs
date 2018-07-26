using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Transform startWindow;
    public Font mainGameFont;
    public Color mainFontColor;
    Transform[] allMenuWins;
    GameObject _canvas;
    void Start()
    {
        try
        {
            _canvas = GameObject.Find("Canvas");
            int children = _canvas.transform.childCount;
            allMenuWins = new Transform[children];
            for (int i = 0; i < children; ++i)
                allMenuWins[i] = _canvas.transform.GetChild(i);
        }
        catch { }
        if (allMenuWins.Length != 0)
        {
            foreach (Transform menu in allMenuWins)
            {
                if (menu != startWindow)
                    menu.gameObject.SetActive(false);
            }
        }
        FixText();
    }

    public void SwichMenu(Transform targetWindow)
    {

        FixText();
    }

    void FixText()
    {
        Text[] _text = FindObjectsOfType<Text>();
        foreach (Text t in _text)
        {
            if (mainGameFont)
                t.font = mainGameFont;
            t.resizeTextForBestFit = true;
            t.resizeTextMinSize = 20;
            t.resizeTextMaxSize = 100;
            t.color = mainFontColor;
        }
    }
}