using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainScript : MonoBehaviour {

    private float spawnTime = 2f;
    private List<GameObject> spawnList = new List<GameObject>();
    private List<GameObject> coinPatternsList = new List<GameObject>();
    public float speed = 7;

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
    }
	
	// Update is called once per frame
	void Update () {
	    
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
}
