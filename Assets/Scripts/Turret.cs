using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float _range = 15f;
    public float _updatePeriod = 0.2f;
    public Transform _rotate;
    public float _rotationSpeed = 6f;
    public float _fireRate = 1f;
    public GameObject _bulletPrefab;
    public Transform _firePoint;
    public int _goldCost = 10;

    private GameObject __target;
    private float __fireCountdown = 0f;

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

        Vector3 direction = __target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_rotate.rotation, lookRotation, Time.deltaTime * _rotationSpeed).eulerAngles;
        _rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (__fireCountdown <= Mathf.Epsilon)
        {
            Shoot();
            __fireCountdown = 1f / _fireRate;
        }
        else
        {
            __fireCountdown -= Time.deltaTime;
        }
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
            __target = closestEnemy;
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

    void Shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SetTarget(__target);
        }
    }
}
