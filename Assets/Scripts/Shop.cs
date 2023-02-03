using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("BUY TURRET");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    public void PurchaseMissileLauncher()
    {
        Debug.Log("BUY MISSILE LAUNCHER");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
