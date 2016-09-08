using UnityEngine;
using System.Collections;

public class CoinCollider : BaseBehaviour {

    public GameObject bixoBait;
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
            Destroy(bixoBait.gameObject);
            Destroy(gameObject);
            player.coinsCollected += 10;
            print(player.coinsCollected);
        }
    }
}
