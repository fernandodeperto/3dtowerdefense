using UnityEngine;

public class Bullet : MonoBehaviour {
    public float _speed = 70f;
    public GameObject _bulletImpact;
    private float __effectDuration = 2f;

    private GameObject __target;

	void Start () {
	}
	
	void Update () {
		if (__target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = __target.transform.position - transform.position;
        float moveDistance = _speed * Time.deltaTime;

        if (direction.magnitude <= moveDistance)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * moveDistance, Space.World);
	}

    public void SetTarget(GameObject target)
    {
        __target = target;
    }

    void HitTarget()
    {
        Enemy enemy = __target.GetComponent<Enemy>();
        GameManager._instance._goldCount += enemy._goldBounty;

        GameObject effectGameObject = Instantiate(_bulletImpact, transform.position, transform.rotation);

        Destroy(effectGameObject, __effectDuration);
        Destroy(gameObject);
        Destroy(__target.gameObject);
    }
}
