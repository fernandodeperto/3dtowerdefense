using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager _instance;
    public GameObject _standardTurretPrefab;
    public GameObject _missileLauncherPrefab;
    public GameObject _laserBeamerPrefab;

    public Text _goldCountText;
    public Text _lifeCountText;
    public int _goldCount = 10;
    public int _lifeCount = 10;

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
        _lifeCountText.text = _lifeCount.ToString();
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
