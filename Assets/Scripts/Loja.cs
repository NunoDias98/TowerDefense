using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loja : MonoBehaviour
{
    public TurretBlueprint turret1;
    public TurretBlueprint turret2;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    // Start is called before the first frame update
    public void SelecionarTorre1()
    {
        Debug.Log("Selecionei Torre 1");
        buildManager.SelectTurretToBuild(turret1);
    }
    public void SelecionarTorre2()
    {
        Debug.Log("Selecionei Torre 2");
        buildManager.SelectTurretToBuild(turret2);
    }
}
