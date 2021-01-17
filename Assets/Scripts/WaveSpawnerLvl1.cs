using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawnerLvl1 : MonoBehaviour
{
    public Transform enemy;
    public Transform boss;
    public Transform spawn;   

    private float timeWave = 5f;
    private float countdown = 1f;

    public static int wave1;
    private int wave = 1;
    public Text WaveTxt;
    private int numberOfWaves = 10;

    public static int currency;
    private int money = 500;

     
    public static int vidas;
    public int startHp = 10;

    public Text hpTxt;
    public Text moneyTxt;

    public GameObject wonCanvas;
    public GameObject loseCanvas;
    public GameObject pauseCanvas;
    

    public GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
        
    {
        vidas = startHp;
        hpTxt.text = vidas.ToString();

        wave1 = wave;

        currency = money;
        moneyTxt.text = currency.ToString() + "$";
        pauseCanvas.SetActive(true);
        loseCanvas.SetActive(false);
        wonCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1f;


        if (countdown <= 0f && wave <= numberOfWaves)
        {
            StartCoroutine(StartWave());
            countdown = timeWave;

        }
        countdown -= Time.deltaTime;

        hpTxt.text = vidas.ToString();
        moneyTxt.text = currency.ToString() + "$";

        enemies = GameObject.FindGameObjectsWithTag("Enemy");


        if (WaveSpawnerLvl1.vidas < 1)
        {

            Lose();
        }

    }

    IEnumerator StartWave()
    {
        
        if (wave < numberOfWaves)
        {
            wave++;
            wave1 = wave;
            WaveTxt.text = "Wave: " + wave.ToString() + "/" + numberOfWaves.ToString();
            for (int i = 0; i < wave * 3; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.7f);
            }

        }

        if (wave == numberOfWaves && enemies.Length < 1)
        {
            won();
        }


    }

    void SpawnEnemy()
    {
        Instantiate(enemy, spawn.position, spawn.rotation);
    }

    public void won()
    {
        
        wonCanvas.SetActive(true);
        pauseCanvas.SetActive(false);

    }

    public void Lose()
    {
        loseCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

}
