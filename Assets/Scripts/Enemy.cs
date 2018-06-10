using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 10f;
    public int _goldBounty = 10;
    public int _lifePenalty = 1;

    private Transform __target;
    private int __waypointIndex = 0;
    private float __minPosition = 0.5f;

    void Start()
    {
        __target = Waypoints._points[0];
    }

    void Update()
    {
        Vector3 direction = __target.position - transform.position;

        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, __target.position) <= __minPosition)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (__waypointIndex >= Waypoints._points.Length - 1)
        {
            GameManager._instance._lifeCount -= _lifePenalty;

            Destroy(gameObject);
            return;
        }

        __target = Waypoints._points[++__waypointIndex];
    }
}
