using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPathing : MonoBehaviour
{
    public float speed = 3f;


    private Transform target;
    private int wavepointIndex = 0;


    private int hpBoss = 50;
    private int worth = 50;

    void Start()
    {
        target = Waypoints.waypoints[0];
        Debug.Log(hpBoss);

    }

    public void TakeDamage(int amount)
    {

        hpBoss -= amount;
        if (hpBoss <= 0)
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

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            nextWayPoint();
        }

        if (WaveSpawnerLvl1.vidas < 1)
        {
            Time.timeScale = 0f;
            //pop up perdeu
        }
    }

    void nextWayPoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            WaveSpawnerLvl1.vidas--;
            Debug.Log(WaveSpawnerLvl1.vidas);
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }
}
