using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour {

    private List<GameObject> spawnList = new List<GameObject>();
    private List<GameObject> coinPatternsList = new List<GameObject>();
    public GameObject VictimGO;
	public bool paused;
    public Text score;
    public Image dashFill;
    private Player playerScript;

    // Use this for initialization
    void Start () {
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

        paused = false;
    }
	
	// Update is called once per frame
	void Update () {
		Pause ();
        Restart();
        DashControl();

        score.text = string.Format("Score: {0}", ConfigurationScript.score);
        //dashFill.fillAmount = playerScript.dashCount / 3;
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

        float yMinPosition = ConfigurationScript.minSpawnYPosition, yMaxPosition = ConfigurationScript.maxSpawnYPosition;
        if(selectedGO.name == "CoinPattern2")
        {
            yMinPosition = -3.5f;
            yMaxPosition = 0;
        }
        else if(selectedGO.name == "CoinPattern3")
        {
            yMinPosition = -3.5f;
            yMaxPosition = 1.2f;
        }

        Instantiate(selectedGO, new Vector2(8f, Random.Range(yMinPosition, yMaxPosition)), selectedGO.transform.rotation);
    }

    void SpawnVictims()
    {
        Instantiate(VictimGO, new Vector2(8f, Random.Range(ConfigurationScript.minSpawnYPosition, ConfigurationScript.maxSpawnYPosition)), VictimGO.transform.rotation);
    }

    void Pause(){
		if (Input.GetButtonDown("Pause") && paused == false) {
			Time.timeScale = 0;
			paused = true;
		}
		else if (Input.GetButtonDown("Pause") && paused == true) {
			Time.timeScale = 1;
			paused = false;
		}
	}

	public void Restart(){
        if (Input.GetButtonDown("Start") && paused)
        {
            SceneManager.LoadScene("Main");
            Time.timeScale = 1;
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
        else if (playerScript.dashCount < 1){
            dashFill.fillAmount = 0;
            playerScript.dashCount = 0;
        }
    }
}
