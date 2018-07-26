using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    Vector2 moveInput;

    float targetTime = .2f;
    float limit = .5f;

    [HideInInspector]
    public Vector3 destination;
    [HideInInspector]
    public int mapSize;

    void Start()
    {
        destination = new Vector3(destination.x, 0.5f, destination.z);
    }

    void FixedUpdate()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            moveInput = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), CrossPlatformInputManager.GetAxisRaw("Vertical"));
            if (moveInput.x < -limit)
            {
                if (transform.position.x != (-(mapSize - 1) / 2) * 2)
                    if (CheckNextOpenPosition(Vector3.left, Color.red))
                        transform.position = new Vector3(transform.position.x - 2, .5f, transform.position.z);/**/
            }
            else if (moveInput.x > limit)
            {
                if (transform.position.x != ((mapSize - 1) / 2) * 2)
                    if (CheckNextOpenPosition(Vector3.right, Color.green))
                        transform.position = new Vector3(transform.position.x + 2, .5f, transform.position.z);/**/
            }
            else if (moveInput.y < -limit)
            {
                if (transform.position.z != (-(mapSize - 1) / 2) * 2)
                    if (CheckNextOpenPosition(Vector3.back, Color.yellow))
                        transform.position = new Vector3(transform.position.x, .5f, transform.position.z - 2);/**/
            }
            else if (moveInput.y > limit)
            {
                if (transform.position.z != ((mapSize - 1) / 2) * 2)
                    if (CheckNextOpenPosition(Vector3.forward, Color.blue))
                        transform.position = new Vector3(transform.position.x, .5f, transform.position.z + 2);/**/
            }
            targetTime = .2f;
        }
        if (transform.position == destination)
        {
            FindObjectOfType<MapGenerator>().GenerateMap();
        }
    }

    bool CheckNextOpenPosition(Vector3 dir, Color c)
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir * 2, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "Obs")
            {
                return false;
            }
        }
        return true;
    }
}