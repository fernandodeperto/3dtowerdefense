using UnityEngine;

public class Shop : MonoBehaviour {
    private BuildManager __buildManager;

	void Start () {
        __buildManager = BuildManager._instance;
	}
	
	void Update () {
		
	}

    public void PurchaseStandardTurret()
    {
        __buildManager.SetSelectedTurret(__buildManager._standardTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        __buildManager.SetSelectedTurret(__buildManager._missileLauncherPrefab);
    }

    public void PurchaseLaserBeamer()
    {
        __buildManager.SetSelectedTurret(__buildManager._laserBeamerPrefab);
    }
}
