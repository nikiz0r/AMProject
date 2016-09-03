using UnityEngine;
using System.Collections;

public class Bixao : MonoBehaviour {

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(rb.velocity.x, -30f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            Destroy(col.gameObject);
    }
}
