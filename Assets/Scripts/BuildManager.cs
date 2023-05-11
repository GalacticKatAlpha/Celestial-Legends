using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    public GameObject placementNode;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    public GameObject firstTurretPrefab;
    public GameObject secondTurretPrefab;
    public GameObject thirdTurretPrefab;

    private TowerBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null;} }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTowerOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Gold To Afford");
            placementNode.GetComponent<Renderer>().enabled = true;
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject tower = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position, Quaternion.identity);
        node.turret = tower;

        Debug.Log("Tower Purchased And Built. Money Left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TowerBlueprint tower)
    {
        turretToBuild = tower;
    }

}
