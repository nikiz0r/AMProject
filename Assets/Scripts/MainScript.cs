using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainScript : MonoBehaviour {

    private float spawnTime = 2f;
    private List<GameObject> spawnList = new List<GameObject>();
    public float speed = 7;

    // Use this for initialization
    void Start () {
        var GOs = Resources.LoadAll("Prefabs", typeof(GameObject));

        foreach (GameObject GO in GOs)
            spawnList.Add(GO);

        InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
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
}
