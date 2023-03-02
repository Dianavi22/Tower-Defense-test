using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;    
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

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public bool canBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
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
        }
       

        Debug.Log("object buy");
    }
}
