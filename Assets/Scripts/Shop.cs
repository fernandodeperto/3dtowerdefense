using UnityEngine;

public class Shop : MonoBehaviour {
    private GameManager __gameManager;

	void Start () {
        __gameManager = GameManager._instance;
	}
	
	void Update () {
		
	}

    public void PurchaseStandardTurret()
    {
        __gameManager.SetSelectedTurret(__gameManager._standardTurretPrefab);
    }
}
