using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    public GameObject turret1Prefab;
    public GameObject turret2Prefab;

    public GameObject buildEffect;


    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Mais que 1 BuildManager");
            return;
        }
        instance = this;
    }

    

    public bool CanBuild { get { return turretToBuild != null; } } //propriedade para ver se consigo construir
    public bool HasMoney { get { return WaveSpawnerLvl1.currency >= turretToBuild.cost; } } 


    public void BuildTurretOn(TurretPlacement turretSpot)
    {
        if(WaveSpawnerLvl1.currency < turretToBuild.cost)
        {
            Debug.Log("Dinheiro insuficiente");
            return;
        }

        WaveSpawnerLvl1.currency -= turretToBuild.cost;

        GameObject tempTurret = (GameObject)Instantiate(turretToBuild.turretPrefab, turretSpot.transform.position, Quaternion.identity); //variavel temporaria para guardar a torre
        turretSpot.turret = tempTurret;

        GameObject tempEffect = (GameObject)Instantiate(buildEffect, turretSpot.transform.position, Quaternion.identity);
        Destroy(tempEffect, 4f);
    }

    
    public void SelectTurretToBuild(TurretBlueprint turret){
        turretToBuild = turret;
    }
}
