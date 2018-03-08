using UnityEngine;

public class Node : MonoBehaviour
{
    public Color _hoverColor;
    public Vector3 _positionOffset;

    private Renderer __renderer;
    private Color __originalColor;
    private GameObject __turret;

	void Start()
    {
        __renderer = GetComponent<Renderer>();
        __originalColor = __renderer.material.color;
	}
	
	void Update()
    {
		
	}

    private void OnMouseEnter()
    {
        __renderer.material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        __renderer.material.color = __originalColor;
    }

    private void OnMouseDown()
    {
        if (__turret != null)
        {
            Debug.Log("got tower");
        }
        else
        {
            GameObject selectedTurret = BuildManager._instance.GetSelectedTurret();
            __turret = (GameObject) Instantiate(selectedTurret, transform.position + _positionOffset, transform.rotation);
        }
    }
}
