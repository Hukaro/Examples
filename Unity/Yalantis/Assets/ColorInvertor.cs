using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorInvertor : MonoBehaviour
{
    public Image im;
    public Color co;

    public void InvertColor()
    {
        Color c = im.color;
        co = new Color(1 - c.r, 1 - c.g, 1 - c.b);
        im.color = co;
    }
}