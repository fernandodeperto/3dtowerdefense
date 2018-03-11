using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager _instance;
    public GameObject _standardTurretPrefab;
    public GameObject _missileLauncherPrefab;
    public GameObject _laserBeamerPrefab;

    private GameObject __selectedTurret;

    void Awake()
    {
        if (_instance != null)
        {
            Debug.Log("build manager already exists");
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
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
