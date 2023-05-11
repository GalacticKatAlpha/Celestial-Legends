using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        this.GetComponent<Renderer>().enabled = true;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        
        if (turret != null) 
        {
            Debug.Log("Unable to build here...");
            return;
        }

        buildManager.BuildTowerOn(this);
        if (buildManager.CanBuild)
        {
            this.GetComponent<Renderer>().enabled = false;
            if(turret == null)
            {
                this.GetComponent<Renderer>().enabled = true;
                return;
            }

        }
    }



    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }


    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
