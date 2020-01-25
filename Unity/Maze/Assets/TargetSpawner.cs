using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public Transform destinationPrefab, playerPrefab;

    MapGenerator map;
    Transform randomTile;

    Color c1, c2;
    public bool SpawnDestination(int mapSize, Color _c1, Color _c2)
    {
        c1 = _c1; c2 = _c2;
        map = FindObjectOfType<MapGenerator>();
        randomTile = map.GetRandomOpenTile();
        Material tileMat = randomTile.GetComponent<Renderer>().material;
        int m = map.mapSize - 1;
        if (randomTile.position.x == m || randomTile.position.x == -m || randomTile.position.z == m || randomTile.position.z == -m)
        {
            tileMat.color = Color.green;
            SpawnPlayer(mapSize);
            return true;
        }
        else
        {
            return false;
        }
    }

    public Color inverseC1, inverseC2;

    void SpawnPlayer(int mapSize)
    {
        float num = 1f;
        try
        {
            Transform _player = FindObjectOfType<Player>().transform;
            DestroyImmediate(_player.gameObject);
        }
        catch { }
        GameObject player = Instantiate(playerPrefab.gameObject, new Vector3(0, 1f, 0), Quaternion.identity);
        player.GetComponent<Player>().destination = randomTile.position;
        player.GetComponent<Player>().mapSize = mapSize;
        Material playerColor = player.GetComponent<Renderer>().material;

        inverseC1 = new Color(num - c1.r, num - c1.g, num - c1.b);
        inverseC2 = new Color(num - c2.r, num - c2.g, num - c2.b);

        playerColor.color = Color.Lerp(inverseC1, inverseC2, Time.deltaTime);
        FindObjectOfType<CameraController>().target = player.transform;
    }
}