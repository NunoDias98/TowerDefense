using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loja : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    // Start is called before the first frame update
    public void ComprarTorre()
    {
        Debug.Log("Comprei Torre");
        buildManager.SetTurretToBuild(buildManager.turret1Prefab);
    }
}
