using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;
    public GameObject buildEffect;

    public NodeUI nodeUI;
    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public void BuildTurretOn(Node node) 
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("to expensive");
        }
        else
        {
        PlayerStats.money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

            GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
            Destroy(effect, 1f);
            Debug.Log("object buy");
        }

    }

    public void SelectedNode(Node node)
    {
        if(node == selectedNode)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
