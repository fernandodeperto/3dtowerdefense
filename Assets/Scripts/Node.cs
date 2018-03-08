using UnityEngine;

public class Node : MonoBehaviour
{
    public Color _hoverColor;

    private Renderer __renderer;
    private Color __originalColor;

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
}
