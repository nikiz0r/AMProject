using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 1);
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
