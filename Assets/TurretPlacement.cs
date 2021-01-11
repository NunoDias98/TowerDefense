using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacement : MonoBehaviour
{
    public GameObject turretShop;
    private float countdown = 3f;

    private Color corInicial;
    // Start is called before the first frame update
    void Start()
    {
        corInicial = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            turretShop.SetActive(false);
            countdown = 3f;
            
        }
        countdown -= Time.deltaTime;
    }
    private void OnMouseDown()
    {
        turretShop.SetActive(true);       
    }
    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.gray;
    }
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = corInicial;

    }

}
