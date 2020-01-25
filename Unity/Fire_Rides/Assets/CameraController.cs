using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera playerCamera;
    GameObject player;
    public Vector3 offset;
    public Vector3 rotarion;
   public void StartCamera()
    {
        playerCamera = Camera.main;
        player = FindObjectOfType<PlayerController>().gameObject;
        //offset = player.transform.position - playerCamera.transform.position;
    }

    void LateUpdate()
    {
        playerCamera.transform.position = player.transform.position + offset;
        playerCamera.transform.eulerAngles = new Vector3(rotarion.x, rotarion.y, rotarion.z);
       //playerCamera.transform.rotation = new Quaternion(2,12,0,0);
    }
}