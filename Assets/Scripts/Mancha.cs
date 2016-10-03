using UnityEngine;
using System.Collections;

public class Mancha : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, Random.Range(1,3));
    }
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(SomeMancha());
        
	}
    
}
