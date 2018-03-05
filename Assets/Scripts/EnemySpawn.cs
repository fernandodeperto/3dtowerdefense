using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform _enemyPrefab;
    public Transform _spawnPoint;
    public float _timeBetweenWaves = 5f;

    private float __countdown = 2f;
    private int __waveIndex = 1;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if (__countdown <= 0f)
        {
            SpawnWave();

            __countdown = _timeBetweenWaves;
        }

        __countdown -= Time.deltaTime;
	}

    void SpawnWave()
    {
        for (int i = 0; i < __waveIndex; i++)
        {
            SpawnEnemy();
        }

        //__waveIndex++;
    }

    void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
