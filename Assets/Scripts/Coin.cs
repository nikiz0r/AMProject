using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    private MainScript mainScript;
    private Rigidbody2D rb;
    private Player player;
    private bool becameVisible = false;

    // Use this for initialization
    void Start () {
        mainScript = (MainScript)FindObjectOfType(typeof(MainScript));
        rb = GetComponent<Rigidbody2D>();
        player = (Player)FindObjectOfType(typeof(Player));
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(-1 * mainScript.speed, rb.velocity.y);

        if (becameVisible)
            IsVisible();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            player.coinsCollected += 1;
            print(player.coinsCollected);
        }
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
