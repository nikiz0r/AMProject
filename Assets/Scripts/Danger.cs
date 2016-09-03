using UnityEngine;
using System.Collections;

public class Danger : MonoBehaviour {

    private float lifeTime = 0.8f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(LifeTime(lifeTime));
    }

    IEnumerator LifeTime(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
