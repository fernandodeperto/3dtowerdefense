using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager _instance;
    public GameObject _standardTurret;

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
        __selectedTurret = _standardTurret;
    }

    public GameObject GetSelectedTurret()
    {
        return __selectedTurret;
    }
}
