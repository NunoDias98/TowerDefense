using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacement : MonoBehaviour
{
    private float countdown = 3.5f;

    private Color corInicial;
    public Color cor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        corInicial = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (countdown <= 0f)
        {
            countdown = 3f;
            
        }
        countdown -= Time.deltaTime;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }

    private void OnMouseDown()
    {

        
        if (turret != null)
        {
            buildManager.SelectTurretSpot(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint TB)
    {
        if (WaveSpawnerLvl1.currency < TB.cost)
        {
            Debug.Log("Dinheiro insuficiente");
            return;
        }

        WaveSpawnerLvl1.currency -= TB.cost;

        GameObject tempTurret = (GameObject)Instantiate(TB.turretPrefab, transform.position, Quaternion.identity); //variavel temporaria para guardar a torre
        turret = tempTurret;

        turretBlueprint = TB;

        GameObject tempEffect = (GameObject)Instantiate(buildManager.buildEffect, transform.position, Quaternion.identity);
        Destroy(tempEffect, 4f);
    }

    public void UpgradeTurret()
    {
        if (WaveSpawnerLvl1.currency < turretBlueprint.upgradeCost)
        {
            Debug.Log("Dinheiro insuficiente para dar upgrade a torre");
            return;
        }

        WaveSpawnerLvl1.currency -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject tempTurret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, transform.position, Quaternion.identity); //variavel temporaria para guardar a torre
        turret = tempTurret;

        GameObject tempEffect = (GameObject)Instantiate(buildManager.buildEffect, transform.position, Quaternion.identity);
        Destroy(tempEffect, 4f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        WaveSpawnerLvl1.currency += turretBlueprint.GetSellAmout();

        isUpgraded = false;

        Destroy(turret);
        turretBlueprint = null;
    }

    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
            
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = corInicial;

    }

}
