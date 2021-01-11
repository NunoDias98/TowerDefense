using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1Script : MonoBehaviour
{
    public Transform enemy;
    public float range;
    public Transform head;
    public Transform firePos1;
    public Transform firePos2;
    public GameObject bala;
    public float rate = 0.3f;
    public float nextAttack;

    private int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("FindTarget", 0f, 0.7f);
        nextAttack = Time.time + rate;
    }


    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;
        GameObject enemyClose = null;

        foreach (GameObject enemy in enemies)
        {
            float distToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distToEnemy < minDistance)
            {
                minDistance = distToEnemy;
                enemyClose = enemy;
            }
        }

        if (minDistance <= range && enemyClose != null)
        {
            enemy = enemyClose.transform;
        }
        else
        {
            enemy = null;
        }

        if (enemy == null)
        {
            return;
        }

        Vector3 difToEnemy = enemy.position - transform.position;
        Vector3 dirToEnemy = difToEnemy.normalized;
        head.transform.forward = Vector3.Slerp(head.transform.forward, dirToEnemy, Time.deltaTime * 20f);
        float dot = Vector3.Dot(head.transform.forward, dirToEnemy);
        if (dot > 0.8)
        {
            if (Time.time > nextAttack)
            {
                Shoot(head.transform.forward);
                nextAttack = Time.time + rate;
            }


        }

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot(Vector3 dir)
    {
        /*
        Animator anim = GetComponent<Animator>();
        anim.Play("Take 001");*/

        GameObject disparoBala1 = (GameObject)Instantiate(bala, firePos1.position, firePos1.rotation);
        GameObject disparoBala2 = (GameObject)Instantiate(bala, firePos2.position, firePos2.rotation);
        BalaMovement bala1 = disparoBala1.GetComponent<BalaMovement>();
        BalaMovement bala2 = disparoBala2.GetComponent<BalaMovement>();
        if ( bala1 != null && bala2 != null)
        {
            bala1.shootTarget(enemy);
            bala2.shootTarget(enemy);
        }
        
    }
}


