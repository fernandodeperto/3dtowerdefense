using UnityEngine;

public class Bullet : MonoBehaviour {
    public float _speed = 70f;
    public GameObject _bulletImpact;
    private float __effectDuration = 2f;

    private Transform __target;

	void Start () {
		
	}
	
	void Update () {
		if (__target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 direction = __target.position - transform.position;
            float moveDistance = _speed * Time.deltaTime;

            if (direction.magnitude <= moveDistance)
            {
                HitTarget();
            }
            else
            {
                transform.Translate(direction.normalized * moveDistance, Space.World);
            }
        }

	}

    public void SetTarget(Transform target)
    {
        __target = target;
    }

    void HitTarget()
    {
        GameObject effectGameObject = Instantiate(_bulletImpact, transform.position, transform.rotation);

        Destroy(effectGameObject, __effectDuration);
        Destroy(gameObject);
        Destroy(__target.gameObject);
    }
}
