using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Transform tilePrefab;
    public Transform obstaclePrefab;

    public int mapSize;

    int obstaclePersent = 1;

    float tileSize = 2;

    List<Coord> allTileCoords;
    Queue<Coord> shufledTileCoords;
    Queue<Coord> shufledOpenTileCoords;

    Transform[,] tileMap;

    int seed = 10;

    float minObstacleHeight = 1.5f, maxObstacleHeight = 2.5f;
    Coord playerSpawnPosition;

    public Color foregroundColour, backgroundColour;

    int finishedLevels = -1;
    void Start()
    {
        finishedLevels = -1;
        GenerateMap();
    }

    public void GenerateMap()
    {
        finishedLevels++;
        foregroundColour = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        backgroundColour = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        if (finishedLevels % 5 == 0 && finishedLevels != 0)
        {
            mapSize += 2;
        }
        seed = Random.Range(1, 100);
        tileMap = new Transform[mapSize, mapSize];
        System.Random prng = new System.Random(seed);
        GetComponent<BoxCollider>().size = new Vector3(mapSize * tileSize, .05f, mapSize * tileSize);

        allTileCoords = new List<Coord>();
        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                allTileCoords.Add(new Coord(x, y));
            }
        }
        shufledTileCoords = new Queue<Coord>(Utility.ShuffleArray(allTileCoords.ToArray(), seed));

        playerSpawnPosition = new Coord(mapSize / 2, mapSize / 2);//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }
        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                Vector3 tilePosition = CoordToPosition(x, y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * tileSize;
                newTile.parent = mapHolder;
                tileMap[x, y] = newTile;
            }
        }

        bool[,] obstacleMap = new bool[mapSize, mapSize];

        int obstacleCount = (int)(mapSize * mapSize);
        int currentObstacleCount = 0;
        List<Coord> allOpenCoords = new List<Coord>(allTileCoords);

        for (int i = 0; i < obstacleCount; i++)
        {
            Coord randomCoord = GetRandomCoord();
            obstacleMap[randomCoord.x, randomCoord.y] = true;
            currentObstacleCount++;

            if (randomCoord != playerSpawnPosition && MapIsFullyAccessible(obstacleMap, currentObstacleCount))
            {
                float obstacleHeight = Mathf.Lerp(minObstacleHeight, maxObstacleHeight, (float)prng.NextDouble());
                Vector3 obstaclePosition = CoordToPosition(randomCoord.x, randomCoord.y);

                Transform newObstacle = Instantiate(obstaclePrefab, obstaclePosition + Vector3.up * obstacleHeight / 2, Quaternion.identity) as Transform;
                newObstacle.parent = mapHolder;
                newObstacle.localScale = new Vector3(tileSize, obstacleHeight, tileSize);

                Renderer obstacleRenderer = newObstacle.GetComponent<Renderer>();
                Material obstacleMaterial = new Material(obstacleRenderer.sharedMaterial);
                float colourPercent = randomCoord.y / (float)mapSize;
                obstacleMaterial.color = Color.Lerp(foregroundColour, backgroundColour, colourPercent);
                obstacleRenderer.sharedMaterial = obstacleMaterial;

                allOpenCoords.Remove(randomCoord);
            }
            else {
                obstacleMap[randomCoord.x, randomCoord.y] = false;
                currentObstacleCount--;
            }
        }

        shufledOpenTileCoords = new Queue<Coord>(Utility.ShuffleArray(allOpenCoords.ToArray(), seed));

        TargetSpawner ts = FindObjectOfType<TargetSpawner>();
        bool doStaf = ts.SpawnDestination(mapSize, foregroundColour, backgroundColour);
        while (!doStaf)
        {
            doStaf = ts.SpawnDestination(mapSize, foregroundColour, backgroundColour);
        }/**/
    }

    bool MapIsFullyAccessible(bool[,] obstacleMap, int currentObstacleCount)
    {
        bool[,] mapFlags = new bool[obstacleMap.GetLength(0), obstacleMap.GetLength(1)];
        Queue<Coord> queue = new Queue<Coord>();

        queue.Enqueue(playerSpawnPosition);
        mapFlags[playerSpawnPosition.x, playerSpawnPosition.y] = true;

        int accessibleTileCount = 1;

        while (queue.Count > 0)
        {
            Coord tile = queue.Dequeue();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int neighbourX = tile.x + x;
                    int neighbourY = tile.y + y;
                    if (x == 0 || y == 0)
                    {
                        if (neighbourX >= 0 && neighbourX < obstacleMap.GetLength(0) && neighbourY >= 0 && neighbourY < obstacleMap.GetLength(1))
                        {
                            if (!mapFlags[neighbourX, neighbourY] && !obstacleMap[neighbourX, neighbourY])
                            {
                                mapFlags[neighbourX, neighbourY] = true;
                                queue.Enqueue(new Coord(neighbourX, neighbourY));
                                accessibleTileCount++;
                            }
                        }
                    }
                }
            }
        }

        int targetAccessibleTileCount = (int)(mapSize * mapSize - currentObstacleCount);
        return targetAccessibleTileCount == accessibleTileCount;
    }

    Vector3 CoordToPosition(int x, int y)
    {
        return new Vector3(-mapSize / 2f + 0.5f + x, 0, -mapSize / 2f + 0.5f + y) * tileSize;
    }

    public Coord GetRandomCoord()
    {
        Coord randomCoord = shufledTileCoords.Dequeue();
        shufledTileCoords.Enqueue(randomCoord);
        return randomCoord;
    }

    public Transform GetRandomOpenTile()
    {
        Coord randomCoord = shufledOpenTileCoords.Dequeue();
        shufledOpenTileCoords.Enqueue(randomCoord);
        return tileMap[randomCoord.x, randomCoord.y];
    }

    [System.Serializable]
    public struct Coord
    {
        public int x;
        public int y;

        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public static bool operator ==(Coord c1, Coord c2)
        {
            return c1.x == c2.x && c1.y == c2.y;
        }
        public static bool operator !=(Coord c1, Coord c2)
        {
            return !(c1 == c2);
        }
    }

    public Transform GetTileFromPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x / tileSize + (mapSize - 1) / 2f);
        int y = Mathf.RoundToInt(position.z / tileSize + (mapSize - 1) / 2f);
        x = Mathf.Clamp(x, 0, tileMap.GetLength(0) - 1);
        y = Mathf.Clamp(y, 0, tileMap.GetLength(1) - 1);
        return tileMap[x, y];
    }
}