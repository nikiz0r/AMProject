using UnityEngine;
using System.Collections;

public class Bixao : MonoBehaviour {

    private Rigidbody2D rb;
    private bool becameVisible = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(rb.velocity.x, -30f);

        if (becameVisible)
            IsVisible();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            Destroy(col.gameObject);
    }

    void IsVisible()
    {
        if (!GetComponent<Renderer>().isVisible)
            Destroy(this.gameObject);
    }

    void OnBecameVisible()
    {
        becameVisible = true;
    }
}
