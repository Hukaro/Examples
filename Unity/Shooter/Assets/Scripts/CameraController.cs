using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [Range(0, 10)]
    public float lerpTime;
    [Range (0,20)]
    public float critX, critZ;
    Vector3 cameraPos;
    Vector3 playerPos;
    bool playerExist;
    
    float mapSizeX, mapSizeZ;

    float criticalX, criticalZ;


    bool check = false;
    void Start()
    {
        transform.parent = null;
        playerPos = GameObject.FindObjectOfType<Player>().transform.position;
        playerExist = GameObject.FindObjectOfType<Spawner>().isDisabled;
        cameraPos = new Vector3(playerPos.x, 18, playerPos.z - 10);
        this.transform.position = cameraPos;
        mapSizeX = GameObject.FindObjectOfType<MapGenerator>().maps[GameObject.FindObjectOfType<MapGenerator>().mapIndex].mapSize.x;
        mapSizeZ = GameObject.FindObjectOfType<MapGenerator>().maps[GameObject.FindObjectOfType<MapGenerator>().mapIndex].mapSize.y;

    }

    void Update()
    {
        if (!GameObject.FindObjectOfType<Spawner>().isDisabled)
        {
            criticalX = ((mapSizeX / 2) - critX) * GameObject.FindObjectOfType<MapGenerator>().tileSize;
            criticalZ = ((mapSizeZ / 2) - critZ) * GameObject.FindObjectOfType<MapGenerator>().tileSize;

            playerPos = GameObject.FindObjectOfType<Player>().transform.position;

            cameraPos = new Vector3(playerPos.x, 18, playerPos.z - 10);
            /*
            if (playerPos.x >= criticalX)
                cameraPos.x = criticalX;
            if (playerPos.x <= -criticalX)
                cameraPos.x = -criticalX;
            if (playerPos.z >= criticalZ)
                cameraPos.z = criticalZ;
            if (playerPos.z <= -criticalZ)
                cameraPos.z = -criticalZ - 21f;
            /**/

            if (playerPos.x >= criticalX || playerPos.x <= -criticalX)
                cameraPos.x = transform.position.x;
            if (playerPos.z >= criticalZ || playerPos.z <= -criticalZ)
                cameraPos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, cameraPos, lerpTime * Time.deltaTime);
        }
    }
}