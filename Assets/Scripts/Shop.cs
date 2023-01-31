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
}
