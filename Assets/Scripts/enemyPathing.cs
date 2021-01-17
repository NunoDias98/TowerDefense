using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyPathing : MonoBehaviour
{
    public float speed = 3f;


    private Transform target;
    private int wavepointIndex = 0;


    private float hpEnemy = WaveSpawnerLvl1.wave1 * 55;
    private float currenthealth;
    private int worth = 15 + (WaveSpawnerLvl1.wave1 * 2);

    public Image healthBar;


    void Start()
    {
        target = Waypoints.waypoints[0];
        Debug.Log(hpEnemy);
        currenthealth = hpEnemy;

    }

    public void TakeDamage(int amount)
    {

        currenthealth -= amount;

        healthBar.fillAmount = currenthealth / hpEnemy;
        if(currenthealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        WaveSpawnerLvl1.currency += worth;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.LookAt(dir + transform.position);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            nextWayPoint();
        }
        
        //if (WaveSpawnerLvl1.vidas < 1)
        //{
        
        //    Lose();
        //}
    }

    void nextWayPoint()
    {
        if(wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            WaveSpawnerLvl1.vidas--;
            Debug.Log(WaveSpawnerLvl1.vidas);
            Destroy(gameObject);   
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    //public void Lose()
    //{
    //    SceneManager.LoadScene("Menu");
    //}
}
