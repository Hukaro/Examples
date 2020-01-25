using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapController : MonoBehaviour
{
    public Text timer;
    public LayerMask wallsLayer, gatesLayer;
    public float rK = 2f;

    int length = 60;
    public float tileSize = 1f;
    GameObject level;
    List<GameObject> tileHolders = new List<GameObject>();
    GameObject tileHolder;
    void Start()
    {
        level = new GameObject();
        level.name = "Level";
        level.transform.position = Vector3.zero;

        tileHolder = new GameObject();
        tileHolder.name = "Tiles";
        tileHolder.transform.position = Vector3.zero;
        tileHolder.transform.SetParent(level.transform);
        tileHolders.Add(tileHolder);

        CreateMap(tileHolder);

        FindObjectOfType<PlayerController>().StartGame(wallsLayer, gatesLayer, timer);

        FindObjectOfType<CameraController>().StartCamera();
    }

    void CreateMap(GameObject currentHolder)
    {
        for (int i = -10; i < length; i++)
        {
            GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Quad);

            float y = Random.Range(1f * rK, 2f * rK);

            tile.transform.position = new Vector3(i, y, 0);

            tile.transform.eulerAngles = new Vector3(-90, 0, 0);

            tile.name = i.ToString();

            tile.AddComponent<Rigidbody>().useGravity = false;
            tile.GetComponent<Rigidbody>().isKinematic = true;

            tile.layer = 8;

            tile.transform.SetParent(currentHolder.transform);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(1f, tileSize, 1f);
            cube.transform.position = new Vector3(i, tile.transform.position.y + tileSize / 2f, 0);
            cube.layer = 8;
            cube.transform.SetParent(tile.transform);

            GameObject _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _cube.transform.localScale = new Vector3(1f, tileSize, 1f);
            y = Random.Range(tileSize * 1.5f, tileSize * 2f);
            _cube.transform.position = new Vector3(i + tileNuber, -y, 0);
            _cube.layer = 10;
            _cube.transform.SetParent(tileHolder.transform);
        }
        tileNuber = length;
    }
    int tileNuber;
    public void AddMapTiles()
    {
        tileHolder = new GameObject();
        tileHolder.name = "Tiles";
        tileHolder.transform.position = Vector3.zero;
        tileHolder.transform.SetParent(level.transform);
        tileHolders.Add(tileHolder);

        for (int i = 0; i < length / 2; i++)
        {
            GameObject tile = GameObject.CreatePrimitive(PrimitiveType.Quad);

            float y = Random.Range(1f * rK, 2f * rK);

            tile.transform.position = new Vector3(i + tileNuber, y, 0);

            tile.transform.eulerAngles = new Vector3(-90, 0, 0);

            tile.name = i + tileNuber.ToString();

            tile.AddComponent<Rigidbody>().useGravity = false;
            tile.GetComponent<Rigidbody>().isKinematic = true;

            tile.layer = 8;

            tile.transform.SetParent(tileHolder.transform);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(1f, tileSize, 1f);
            cube.transform.position = new Vector3(i + tileNuber, tile.transform.position.y + tileSize / 2f, 0);
            cube.layer = 8;
            cube.transform.SetParent(tile.transform);

            GameObject _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _cube.transform.localScale = new Vector3(1f, tileSize, 1f);
            y = Random.Range(tileSize * 1.5f, tileSize * 2f);
            _cube.transform.position = new Vector3(i + tileNuber, -y, 0);
            _cube.layer = 10;
            _cube.transform.SetParent(tileHolder.transform);
        }
        tileNuber += length / 2;
    }
    public void Remover()
    {
        GameObject rem = tileHolders[0];
        tileHolders.RemoveAt(0);
        Destroy(rem);
    }
}