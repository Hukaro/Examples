using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class LongPointer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    float pointerDownTimer;

    public void OnPointerDown(PointerEventData eventData)
    {
        FindObjectOfType<PlayerController>().Connect();
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FindObjectOfType<PlayerController>().UnClipp();
        pointerDownTimer = 0;
        pointerDown = false;
    }

    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime * 2f;
            float angle = 30f;
            Vector3 direction = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0);
            FindObjectOfType<PlayerController>().GetComponent<Rigidbody>().AddForce(direction * pointerDownTimer, ForceMode.Acceleration);
        }
    }
}
