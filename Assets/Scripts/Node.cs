using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startColor;
    public Color notEnoughtMoneyColor;
    public GameObject turret;
    private BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            return;
        }
        buildManager.BuildTurretOn(this);
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.canBuild)
        {
            return;
        }
        if (buildManager.hasMoney)
        {
            rend.material.color = hoverColor;

        }
        else
        {
            rend.material.color = notEnoughtMoneyColor;

        }
    }

    private void OnMouseExit()
    {
       
        rend.material.color = startColor;
    }
}
