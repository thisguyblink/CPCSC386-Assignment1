using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyObject;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;

    [SerializeField] private Transform[] spawnPoints;

    private float _timeUntilSpawn;

    private Transform chosenSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            SetSpawnTime();
            SpawnEnemy();
        }
    }

    private void SetSpawnTime()
    {
        int num = ScoreManager.Instance.score;
        if (num == 10 || num == 20 || num == 30 || num == 40)
        {
            _maximumSpawnTime /= 2;
            ScoreManager.Instance.Multiplier();
        }
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
        int index = Random.Range(0, spawnPoints.Length);
        chosenSpawn = spawnPoints[index];
    }
    private void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned to EnemySpawner!");
            return;
        }

        // Pick a random spawn point
        Instantiate(_enemyObject, chosenSpawn.position, Quaternion.identity);
    }
}
