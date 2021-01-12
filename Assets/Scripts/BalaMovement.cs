using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovement : MonoBehaviour
{
    private Transform target;
    private float speed = 10f;

    private int dano = 1;
    // Start is called before the first frame update
    public void shootTarget(Transform alvo)
    {
        target = alvo;
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dirBala = target.position - transform.position;
        float dist = speed * Time.deltaTime;

        if(dirBala.magnitude <= dist)
        {
            HitTarget();
            return;
        }
        transform.Translate(dirBala.normalized * dist, Space.World);
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}
