using UnityEngine;
using System.Collections;

public class Coin : BaseBehaviour {

    private Player player;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        player = (Player)FindObjectOfType(typeof(Player));
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
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
}
