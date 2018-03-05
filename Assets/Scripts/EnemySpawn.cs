using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public Transform _enemyPrefab;
    public Transform _spawnPoint;
    public float _timeBetweenWaves = 5f;

    private float __countdown = 2f;
    private int __waveIndex = 1;
    private float __waitTime = 0.5f;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if (__countdown <= 0f)
        {
            StartCoroutine(SpawnWave());

            __countdown = _timeBetweenWaves;
        }

        __countdown -= Time.deltaTime;
	}

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < __waveIndex; i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(__waitTime);
        }

        __waveIndex++;
    }

    void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
