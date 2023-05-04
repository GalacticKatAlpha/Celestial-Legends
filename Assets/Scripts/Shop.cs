using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Test Purchase");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseSecondaryTurret()
    {
        Debug.Log("Test Secondary Purchase");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }


}
