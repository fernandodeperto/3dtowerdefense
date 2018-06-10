using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {
    public static BuildManager _instance;
    public GameObject _standardTurretPrefab;
    public GameObject _missileLauncherPrefab;
    public GameObject _laserBeamerPrefab;

    public Text _goldCountText;
    public int _goldCount = 10;

    private GameObject __selectedTurret;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Update()
    {
        _goldCountText.text = _goldCount.ToString();
    }

    public GameObject GetSelectedTurret()
    {
        return __selectedTurret;
    }

    public void SetSelectedTurret(GameObject turret)
    {
        __selectedTurret = turret;
    }
}
