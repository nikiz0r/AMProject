using UnityEngine;
using System.Collections;

public class Tinta : MonoBehaviour {

	public GameObject mancha;
    private BoxCollider2D tintaBc;
    private Rigidbody2D tintaRb;
    

    // Use this for initialization
	void Start () {
        tintaBc = GetComponent<BoxCollider2D>();
        tintaRb = GetComponent<Rigidbody2D>();
        tintaRb.velocity = new Vector3(-20, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            //print("achou tag...");
            Instantiate(mancha, new Vector3(0, 0, 0), transform.rotation);
            //GameObject manchatela = (GameObject)Instantiate(mancha, new Vector3(0,0,0), transform.rotation);
            Destroy(gameObject);
        }
            
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //print("entrou colisao");
        if (col.gameObject.tag == "Player")
        {
            //print("achou tag...");
            Instantiate(mancha, new Vector3(0,0,0), transform.rotation); 
            Destroy(gameObject);
        }
    }
}
