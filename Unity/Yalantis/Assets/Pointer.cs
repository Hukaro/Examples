using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pointer : MonoBehaviour
{
    InfoHolder ih;
    void Start()
    {
        ih = FindObjectOfType<InfoHolder>();
    }

    Collider2D[] dotsOnPointer;

    void Update()
    {
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary))
        {
            dotsOnPointer = Physics2D.OverlapCircleAll(Input.GetTouch(0).position, ih.pointDist);

            if (dotsOnPointer.Length > 0)
            {
                foreach (Collider2D c in dotsOnPointer)
                {
                    c.GetComponent<dotLogic>().TakeData(Input.GetTouch(0).position);
                }
            }
        }
    }
}