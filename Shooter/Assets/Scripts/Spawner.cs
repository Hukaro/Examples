using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public int startAmount = 10;
    public float startSpawnTime = 3;

    public Wave[] waves;
    public Enemy enemy;

    LivingEntety playerEntety;
    Transform playerT;

    Wave currentWave;

    [HideInInspector]
    public int currentWaveNumber;

    int enemiesRemainingToSpawn;
    int enemyesRemainingAlive;
    float nextSpawnTime;

    MapGenerator map;

    float timeBetweenCampingChacks = 2;
    float campThreshHoldDistance = 1.5f;
    float nextCampCheckTime;
    Vector3 campPosOld;
    bool isCamping;
    [HideInInspector]
    public bool isDisabled;

    public event System.Action<int> OnNewWave;
    void Start()
    {
        playerEntety = FindObjectOfType<Player>();
        playerT = playerEntety.transform;
        nextCampCheckTime = timeBetweenCampingChacks + Time.time;
        campPosOld = playerT.position;
        playerEntety.OnDeath += OnPlayerDeath;

        for (int i = 0; i < waves.Length; i++)
        {
            if (i == 0)
            {
                waves[0].enemyCount = startAmount;
                waves[0].timeBetweenSpawns = startSpawnTime;
            }
            else
            {
                waves[i].enemyCount = waves[0].enemyCount + waves[0].enemyCount * i;
                waves[i].timeBetweenSpawns = waves[i - 1].timeBetweenSpawns - waves[0].timeBetweenSpawns / waves.Length;
            }
        }

        map = FindObjectOfType<MapGenerator>();
        NextWave();
    }

    void Update()
    {
        if (!isDisabled)
        {
            if (Time.time > nextCampCheckTime)
            {
                nextCampCheckTime = Time.time + timeBetweenCampingChacks;

                isCamping = (Vector3.Distance(playerT.position, campPosOld) < campThreshHoldDistance);
                campPosOld = playerT.position;
            }
            if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
            {
                enemiesRemainingToSpawn--;
                nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
                StartCoroutine(SpawnEnemy());
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        float spawnDelay = 1;
        float tileFlashSpeed = 4;

        Transform spawnTile = map.GetRandomOpenTile();
        if (isCamping)
        {
            spawnTile = map.GetTileFlorPosition(playerT.position);
        }
        Material tileMat = spawnTile.GetComponent<Renderer>().material;
        Color initialColour = tileMat.color;
        Color flashColour = Color.red;
        float spawnTimer = 0;
        while (spawnTimer < spawnDelay)
        {
            tileMat.color = Color.Lerp(initialColour, flashColour, Mathf.PingPong(spawnTimer * tileFlashSpeed, 1));
            spawnTimer += Time.deltaTime;
            yield return null;
        }
        Enemy spawnedEnemy = Instantiate(enemy, spawnTile.position + Vector3.up, Quaternion.identity) as Enemy;
        spawnedEnemy.OnDeath += OnEnemyDeath;
    }

    void OnEnemyDeath()
    {
        enemyesRemainingAlive--;
        if (enemyesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    void OnPlayerDeath()
    {
        isDisabled = true;
    }

    void NextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemyesRemainingAlive = enemiesRemainingToSpawn;
            if (OnNewWave != null)
            {
                OnNewWave(currentWaveNumber);
            }
            ResetPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        playerT.position = map.GetTileFlorPosition(Vector3.zero).position + Vector3.up * 3;
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}