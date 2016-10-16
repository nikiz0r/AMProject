﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {

    private List<GameObject> spawnList = new List<GameObject>();
    private List<GameObject> coinPatternsList = new List<GameObject>();
    public GameObject VictimGO, DropZoneGO;
	public bool paused, dangerTimeVisibility, dangerFadeIn = false;
    public Text score, dangerTime, pauseTxt;
    public Image dashFill, pauseImg;
    private Player playerScript;

    // Use this for initialization
    void Start () {
        dangerTimeVisibility = false;
        playerScript = (Player)FindObjectOfType(typeof(Player));
        var PrefabsGOs = Resources.LoadAll("Prefabs", typeof(GameObject));
        var CoinGOs = Resources.LoadAll("CoinPatterns", typeof(GameObject));

        foreach (GameObject GO in PrefabsGOs)
            spawnList.Add(GO);

        foreach (GameObject GO in CoinGOs)
            coinPatternsList.Add(GO);

        InvokeRepeating("SpawnEnemies", ConfigurationScript.enemySpawnTime, ConfigurationScript.enemySpawnTime);
        InvokeRepeating("SpawnCoins", ConfigurationScript.coinSpawnTime, ConfigurationScript.coinSpawnTime);
        InvokeRepeating("SpawnVictims", ConfigurationScript.victimSpawnTime, ConfigurationScript.victimSpawnTime);
        InvokeRepeating("SpawnDropZones", ConfigurationScript.dropZoneSpawnTime, ConfigurationScript.dropZoneSpawnTime);
        InvokeRepeating("DifficultyUp", ConfigurationScript.difficultyUp, ConfigurationScript.difficultyUp);

        paused = false;
		pauseImg.gameObject.SetActive (false);
		pauseTxt.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        Pause ();
        Restart();
        DashControl();

        score.text = string.Format("Score: {0}", ConfigurationScript.score);

        if (Time.timeSinceLevelLoad >= ConfigurationScript.DangerTime && !dangerTimeVisibility)
            TriggerDanger();

        // Player morreu
        if (playerScript == null)
            StartCoroutine(GameOver());
        else
            EndGame();

        if (Input.GetKeyDown(KeyCode.F8))
        {
            SceneManager.LoadScene("BossFight");
        }
    }

    void TriggerDanger()
    {
        dangerTimeVisibility = true;
        InvokeRepeating("BlinkDanger", 0, 0.3f);
    }

    void BlinkDanger()
    {
        dangerFadeIn = !dangerFadeIn;
        dangerTime.gameObject.SetActive(dangerFadeIn);
    }

    void EndGame()
    {
        if (Time.timeSinceLevelLoad >= ConfigurationScript.EnterBossFight)
            SceneManager.LoadScene("BossFight");
    }
    void SpawnEnemies()
    {
        // pick randomly one gameObject
        GameObject selectedGO = spawnList[Random.Range(0, spawnList.Count)];

        Instantiate(selectedGO, new Vector2(8f, Random.Range(ConfigurationScript.minSpawnYPosition, ConfigurationScript.maxSpawnYPosition)), selectedGO.transform.rotation);
    }

    void SpawnCoins()
    {
        GameObject selectedGO = coinPatternsList[Random.Range(0, coinPatternsList.Count)];

        float yMinPosition = 0, yMaxPosition = 0;
        if (selectedGO.name == "CoinPattern1")
        {
            yMinPosition = -2.7f;
            yMaxPosition = 5f;
        }
        else if(selectedGO.name == "CoinPattern2")
        {
            yMinPosition = -3.5f;
            yMaxPosition = 0.5f;
        }
        else if(selectedGO.name == "CoinPattern3")
        {
            yMinPosition = -3.6f;
            yMaxPosition = 1.5f;
        }

        Instantiate(selectedGO, new Vector2(8f, Random.Range(yMinPosition, yMaxPosition)), selectedGO.transform.rotation);
    }

    void SpawnVictims()
    {
        Instantiate(VictimGO, new Vector2(8f, Random.Range(ConfigurationScript.minSpawnYPosition, ConfigurationScript.maxSpawnYPosition)), VictimGO.transform.rotation);
    }

    void SpawnDropZones()
    {
        Instantiate(DropZoneGO, new Vector2(8f, Random.Range(ConfigurationScript.minSpawnYPosition, ConfigurationScript.maxSpawnYPosition)), DropZoneGO.transform.rotation);
    }

    void Pause(){
		if (Input.GetButtonDown("Pause") && paused == false) {
			Time.timeScale = 0;
			paused = true;
			pauseImg.gameObject.SetActive (true);
			pauseTxt.enabled = true;
		}
		else if (Input.GetButtonDown("Pause") && paused == true) {
			Time.timeScale = 1;
			paused = false;
			pauseImg.gameObject.SetActive (false);
			pauseTxt.enabled = false;
		}
	}

	public void Restart(){
        if (Input.GetButtonDown("Start") && paused)
        {
            SceneManager.LoadScene("GameScene");
            Time.timeScale = 1;
            ResetStats();
        }
	}

    void DashControl(){
        if (playerScript.dashCount == 3){
            dashFill.fillAmount = 1;
        }
        else if (playerScript.dashCount > 2 && playerScript.dashCount < 3){
            dashFill.fillAmount = 0.66f;
        }
        else if (playerScript.dashCount > 1 && playerScript.dashCount < 2){
            dashFill.fillAmount = 0.33f;
        }
        else if (playerScript.dashCount < 1 && playerScript.dashCount > 0){
            dashFill.fillAmount = 0;
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("RankScene");
    }

    void DifficultyUp()
    {
        CancelInvoke("SpawnEnemies");
        CancelInvoke("SpawnCoins");
        CancelInvoke("SpawnVictims");

        ConfigurationScript.baseSpeed += ConfigurationScript.baseSpeed < 20 ? 1 : 0;
        ConfigurationScript.enemySpawnTime -= ConfigurationScript.enemySpawnTime > 0.5 ? 0.2f : 0;
        ConfigurationScript.coinSpawnTime -= ConfigurationScript.coinSpawnTime > 5 ? 0.1f : 0;
        ConfigurationScript.victimSpawnTime -= ConfigurationScript.coinSpawnTime > 5 ? 0.2f : 0;

        InvokeRepeating("SpawnEnemies", ConfigurationScript.enemySpawnTime, ConfigurationScript.enemySpawnTime);
        InvokeRepeating("SpawnCoins", ConfigurationScript.coinSpawnTime, ConfigurationScript.coinSpawnTime);
        InvokeRepeating("SpawnVictims", ConfigurationScript.victimSpawnTime, ConfigurationScript.victimSpawnTime);
    }

    public void ResetStats()
    {
        ConfigurationScript.baseSpeed = ConfigurationScript.staticBaseSpeed;
        ConfigurationScript.enemySpawnTime = ConfigurationScript.baseEnemySpawnTime;
        ConfigurationScript.coinSpawnTime = ConfigurationScript.baseCoinSpawnTime;
        ConfigurationScript.victimSpawnTime = ConfigurationScript.baseVictimSpawnTime;
        ConfigurationScript.score = 0;
        ConfigurationScript.victimsCollected = 0;
        ConfigurationScript.playerSpeed = ConfigurationScript.playerBaseSpeed;
        ConfigurationScript.jumpForce = ConfigurationScript.baseJumpForce;
        ConfigurationScript.jumpBoost = ConfigurationScript.baseJumpBoost;
    }
}
