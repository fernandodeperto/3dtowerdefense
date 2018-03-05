using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float _range = 15f;
    public float _updatePeriod = 0.2f;
    public Transform _rotate;
    public float _rotationSpeed = 6f;

    private Transform __target;

	void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, _updatePeriod);
	}
	
	void Update()
    {
        if (__target == null)
        {
            return;
        }

        Vector3 direction = __target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_rotate.rotation, lookRotation, Time.deltaTime * _rotationSpeed).eulerAngles;
        _rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && shortestDistance <= _range)
        {
            __target = closestEnemy.transform;
        }
        else
        {
            __target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
