using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoHolder : MonoBehaviour
{
    [System.Serializable]
    public class Shapes
    {
        public Sprite img;
    }

    public List<Shapes> shapesForDots;


    public Sprite ImageForDots;
    [Range(1,5)]
    public int dotSize;
    [Range(2,10)]
    public int mult;
    [Range(1, 10)]
    public int dotSpeed;
    [Range(100, 300)]
    public float pointDist;
    [Range(0.01f, 0.5f)]
    public float timeBeforeTakeStartPlace;
    void Start()
    {
        if (!ImageForDots)
        {
            Debug.Log("No image for dots been applied");
        }
    }
}