using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyPathing : MonoBehaviour
{
    public float speed = 3f;

    private Transform target;
    private int wavepointIndex = 0;

    public Text hp;
    private int hpEnemy = (WaveSpawnerLvl1.wave1 + 1) * 2;

    void Start()
    {
        target = Waypoints.waypoints[0];
        
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
        /*
        if (WaveSpawnerLvl1.vidas < 1)
        {
            Time.timeScale = 0f;
            //pop up perdeu
        }*/
    }

    void nextWayPoint()
    {
        if(wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            //WaveSpawnerLvl1.vidas--;
            Destroy(gameObject);   
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }
}
