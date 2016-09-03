using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    private MainScript mainScript;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        mainScript = (MainScript)FindObjectOfType(typeof(MainScript));
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(-1 * mainScript.speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
