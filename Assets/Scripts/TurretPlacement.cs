using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacement : MonoBehaviour
{
    private float countdown = 3.5f;

    private Color corInicial;
    public Color cor;

    [Header("Opcional")]
    public GameObject turret;

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
        if(!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Não pode construir aqui");
            return;
        }
        buildManager.BuildTurretOn(this);
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
