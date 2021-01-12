using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerLvl1 : MonoBehaviour
{
    public Transform enemy;
    public Transform spawn;
    

    public float timeWave = 5f;
    private float countdown = 2f;


    public static int wave1;
    private int wave = 0;
    public Text WaveTxt;
    private int numberOfWaves = 10;

    public static int currency;
    private int money = 300;

     
    public static int vidas;
    public int startHp = 10;

    public Text hpTxt;
    public Text moneyTxt;

    // Start is called before the first frame update
    void Start()
        
    {
        vidas = startHp;
        hpTxt.text = vidas.ToString();

        wave1 = wave;

        currency = money;
        moneyTxt.text = currency.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
     
        if(countdown <= 0f && wave < numberOfWaves)
        {
            StartCoroutine(StartWave());
            countdown = timeWave;

        }
        countdown -= Time.deltaTime;

        hpTxt.text = vidas.ToString();
        moneyTxt.text = currency.ToString() + "$";
    }

    IEnumerator StartWave()
    {
        wave++;
        wave1 = wave;
        WaveTxt.text = "Wave: " + wave.ToString() + "/" + numberOfWaves.ToString();
        for (int i = 0; i < wave * 5; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.7f);
        }
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemy, spawn.position, spawn.rotation);
    }

    
}
