using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    private TurretPlacement TurretSpotSelected;

    public TowerSelection towerSelection;

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


    public void SelectTurretSpot(TurretPlacement TP)
    {
        if(TurretSpotSelected == TP)
        {
            DeselectTurretSpot();
            return;
        }
        TurretSpotSelected = TP;
        turretToBuild = null;

        towerSelection.setTarget(TP);
    }
    
    public void DeselectTurretSpot()
    {
        TurretSpotSelected = null;
        towerSelection.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret){
        turretToBuild = turret;

        DeselectTurretSpot();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
