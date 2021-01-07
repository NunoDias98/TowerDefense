﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerLvl1 : MonoBehaviour
{
    public Transform enemy;
    public Transform spawn;
    

    public float timeWave = 5f;
    private float countdown = 2f;

    private int wave = 0;
    public Text WaveTxt;
    private int numberOfWaves = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(StartWave());
            countdown = timeWave;

        }
        countdown -= Time.deltaTime;
    }

    IEnumerator StartWave()
    {
        wave++;
        WaveTxt.text = "Wave: " + wave.ToString() + "/" + numberOfWaves.ToString();
        for (int i = 0; i < wave * 2; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemy, spawn.position, spawn.rotation);
    }
}