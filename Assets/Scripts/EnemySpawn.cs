using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public Transform _enemyPrefab;
    public float _timeBetweenWaves = 5f;

    private float __countdown = 2f;

	void Start () {
		
	}
	
	void Update () {
		if (__countdown <= 0f)
        {
            SpawnWave();

            __countdown = _timeBetweenWaves;
        }

        __countdown -= Time.deltaTime;
	}

    void SpawnWave()
    {
        Debug.Log("wave incoming");
    }
}
