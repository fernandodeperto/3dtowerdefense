using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color _hoverColor;
    public Vector3 _positionOffset;

    private Renderer __renderer;
    private Color __originalColor;
    private GameObject __turret;
    private GameManager __gameManager;

	void Start()
    {
        __renderer = GetComponent<Renderer>();
        __originalColor = __renderer.material.color;
        __gameManager = GameManager._instance;
	}
	
	void Update()
    {
		
	}

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (__gameManager.GetSelectedTurret() == null)
        {
            return;
        }

        __renderer.material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        __renderer.material.color = __originalColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (__gameManager.GetSelectedTurret() == null)
        {
            return;
        }

        if (__turret != null)
        {
            return;
        }

        GameObject selectedTurret = GameManager._instance.GetSelectedTurret();
        Turret turret = selectedTurret.GetComponent<Turret>();

        if (GameManager._instance._goldCount < turret._goldCost)
        {
            return;
        }

        GameManager._instance._goldCount -= turret._goldCost;
        
        __turret = (GameObject) Instantiate(selectedTurret, transform.position + _positionOffset, transform.rotation);
    }
}
