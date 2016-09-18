using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    private float spawnTime = 2f;
    private List<GameObject> spawnList = new List<GameObject>();
    private List<GameObject> coinPatternsList = new List<GameObject>();
	public bool paused;

    // Use this for initialization
    void Start () {
        var PrefabsGOs = Resources.LoadAll("Prefabs", typeof(GameObject));
        var CoinGOs = Resources.LoadAll("CoinPatterns", typeof(GameObject));

        foreach (GameObject GO in PrefabsGOs)
            spawnList.Add(GO);

        foreach (GameObject GO in CoinGOs)
            coinPatternsList.Add(GO);

        InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
        InvokeRepeating("SpawnCoins", spawnTime * 4.2f, spawnTime * 4.2f);

		paused = false;
    }
	
	// Update is called once per frame
	void Update () {
		Pause ();
	}

    void SpawnEnemies()
    {
        // pick randomly one gameObject
        GameObject selectedGO = spawnList[Random.Range(0, spawnList.Count)];

        Instantiate(selectedGO, new Vector2(8f, Random.Range(-2f, 3.3f)), selectedGO.transform.rotation);
    }

    void SpawnCoins()
    {
        GameObject selectedGO = coinPatternsList[Random.Range(0, coinPatternsList.Count)];

        Instantiate(selectedGO, new Vector2(8f, Random.Range(-2f, 3.3f)), selectedGO.transform.rotation);
    }

	void Pause(){
		if (Input.GetKeyDown(KeyCode.P) && paused == false) {
			Time.timeScale = 0;
			paused = true;
		}
		else if (Input.GetKeyDown(KeyCode.P) && paused == true) {
			Time.timeScale = 1;
			paused = false;
		}
	}

	public void Restart(){
        SceneManager.LoadScene("main");
	}
}
