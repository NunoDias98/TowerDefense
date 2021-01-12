using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacement : MonoBehaviour
{
    private float countdown = 3.5f;

    private Color corInicial;

    private GameObject turret1;

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
    private void OnMouseDown()
    {
        if(buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if (turret1 != null)
        {
            Debug.Log("Não pode construir aqui");
            return;
        }
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret1 = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    private void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        GetComponent<Renderer>().material.color = Color.gray;
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = corInicial;

    }

}
