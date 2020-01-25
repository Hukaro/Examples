using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Range(10, 100)]
    public int mapSize = 10;
    [Range(0, 90)]
    public int obstacleCount = 0;

    public Color land, walls;

    [Range(-100, 100)]
    public int seed = 0;

    System.Random rnd;

    GameObject environment;

    void Start()
    {
        rnd = new System.Random(seed);
        CreateEnvironment();
        CreateBorders();
        CreateObstacles();
        GetComponent<GenerationController>().StartGeneration();
    }

    void CreateEnvironment()
    {
        environment = GameObject.CreatePrimitive(PrimitiveType.Cube);
        environment.transform.position = new Vector3(0, -.5f, 0);
        environment.transform.localScale = new Vector3(mapSize, 0.01f, mapSize);
        environment.name = "Environment";
        environment.GetComponent<MeshRenderer>().material.color = land;
    }

    void CreateBorders()
    {
        for (int i = -1; i < 2; i++)
        {
            if (i != 0)
            {
                GameObject obs = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obs.transform.position = new Vector3(0, 0, (environment.transform.lossyScale.z / 2 + obs.transform.lossyScale.z / 2) * i);
                obs.transform.localScale = new Vector3(environment.transform.lossyScale.z, 1, 1);
                obs.layer = LayerMask.NameToLayer("Wall");
                obs.GetComponent<MeshRenderer>().material.color = walls;
                obs.name = "Wall";
                obs.transform.SetParent(environment.transform);
            }
        }
        for (int i = -1; i < 2; i++)
        {
            if (i != 0)
            {
                GameObject obs = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obs.transform.position = new Vector3((environment.transform.lossyScale.x / 2 + obs.transform.lossyScale.x / 2) * i, 0, 0);
                obs.transform.localScale = new Vector3(1, 1, environment.transform.lossyScale.x);
                obs.layer = LayerMask.NameToLayer("Wall");
                obs.GetComponent<MeshRenderer>().material.color = walls;
                obs.name = "Wall";
                obs.transform.SetParent(environment.transform);
            }
        }
    }

    void CreateObstacles()
    {
        for(int i = 0; i < obstacleCount; i++)
        {
            GameObject obs = GameObject.CreatePrimitive(PrimitiveType.Cube);

            float x = Mathf.Lerp(-mapSize / 2f, mapSize / 2f, (float)rnd.NextDouble());
            float y = Mathf.Lerp(0f, 1f, (float)rnd.NextDouble());
            float z = Mathf.Lerp(-mapSize / 2f, mapSize / 2f, (float)rnd.NextDouble());

            obs.transform.position = new Vector3(x, 0, z);
            obs.transform.rotation = new Quaternion(0f, y, 0f, 1f);

            x = Mathf.Lerp(2f, 4f, (float)rnd.NextDouble());
            z = Mathf.Lerp(3f, 6f, (float)rnd.NextDouble());

            obs.transform.localScale = new Vector3(x, 1, z);

            obs.layer= LayerMask.NameToLayer("Wall");

            obs.GetComponent<MeshRenderer>().material.color = walls;
            obs.name = "Obstacle";
            obs.transform.SetParent(environment.transform);
        }
    }
}
