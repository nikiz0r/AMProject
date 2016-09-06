using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {

    private float explosionTime;

	// Use this for initialization
	void Start () {
        explosionTime = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(ExplosionLifeTime(explosionTime));
	}

    IEnumerator ExplosionLifeTime(float timeAlive)
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Coin":
            case "Melee":
                break;
            default:
                Destroy(col.gameObject);
                break;
        }
    }
}
