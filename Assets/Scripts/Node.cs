using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startColor;
    public Color notEnoughtMoneyColor;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    private BuildManager buildManager;
    public TurretBlueprint blueprint;

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

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
        }
        else
        {
            PlayerStats.money -= blueprint.cost;
            turretBlueprint = blueprint;

            GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("upgrade impossible");
        }
        else
        {
            PlayerStats.money -= turretBlueprint.cost;
            Destroy(turret);
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 1f);
            isUpgraded = true;
            Debug.Log("object upgraded");
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectedNode(this);
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
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
