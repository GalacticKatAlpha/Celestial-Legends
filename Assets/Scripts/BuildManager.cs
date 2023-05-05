using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

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
        
    public void BuildTowerOn(Node node)
    {
        GameObject tower = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.GetBuildPosition(), Quaternion.identity);
        node.turret = tower;
    }

    public void SelectTurretToBuild(TowerBlueprint tower)
    {
        turretToBuild = tower;
    }

}
