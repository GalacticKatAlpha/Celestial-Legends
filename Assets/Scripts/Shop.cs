using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint firstTurret;
    public TowerBlueprint secondTurret;
    public TowerBlueprint thirdTurret;
    public TowerBlueprint fourthTurret;
    public TowerBlueprint fifthTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectFirstSlotTurret()
    {
        Debug.Log("Test Purchase");
        buildManager.SelectTurretToBuild(firstTurret);
    }

    public void SelectSecondSlotTurret()
    {
        Debug.Log("Test Second Purchase");
        buildManager.SelectTurretToBuild(secondTurret);
    }

    public void SelectThirdSlotTurret()
    {
        Debug.Log("Test Third Slot Purchase");
        buildManager.SelectTurretToBuild(thirdTurret);
    }

    public void SelectfourthSlotTurret()
    {
        Debug.Log("Test fourth Slot Purchase");
        buildManager.SelectTurretToBuild(fourthTurret);
    }

    public void SelectfifthSlotTurret()
    {
        Debug.Log("Test fifth Slot Purchase");
        buildManager.SelectTurretToBuild(fifthTurret);
    }
}
