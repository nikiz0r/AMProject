using UnityEngine;
using System.Collections;

public class Tinta : MonoBehaviour {

	public GameObject mancha;
    private Rigidbody2D tintaRb;

	void Start () {
        tintaRb = GetComponent<Rigidbody2D>();
        tintaRb.velocity = new Vector3(-20, 0);
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(mancha, new Vector3(0,0,0), transform.rotation); 
            Destroy(gameObject);
        }
    }
}
