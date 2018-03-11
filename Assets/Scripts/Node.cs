﻿using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color _hoverColor;
    public Vector3 _positionOffset;

    private Renderer __renderer;
    private Color __originalColor;
    private GameObject __turret;
    private BuildManager __buildManager;

	void Start()
    {
        __renderer = GetComponent<Renderer>();
        __originalColor = __renderer.material.color;
        __buildManager = BuildManager._instance;
	}
	
	void Update()
    {
		
	}

    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && __buildManager.GetSelectedTurret() != null)
        {
            __renderer.material.color = _hoverColor;
        }
    }

    private void OnMouseExit()
    {
        __renderer.material.color = __originalColor;
    }

    private void OnMouseDown()
    {
        if (__buildManager.GetSelectedTurret() == null || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (__turret == null)
        {
            GameObject selectedTurret = BuildManager._instance.GetSelectedTurret();
            __turret = (GameObject) Instantiate(selectedTurret, transform.position + _positionOffset, transform.rotation);
        }
    }
}
