using UnityEngine;
using System.Collections;

public class CoinCollider : MonoBehaviour {

    public GameObject bixoBait;
    private Player player;
    private bool becameVisible = false;

    // Use this for initialization
    void Start () {
        player = (Player)FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
        if (becameVisible)
            IsVisible();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(bixoBait.gameObject);
            Destroy(gameObject);
            player.coinsCollected += 10;
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
