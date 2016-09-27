using UnityEngine;

public class CoinCollider : BaseBehaviour {

    public GameObject bixoBait;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
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
            ConfigurationScript.coinsCollected += ConfigurationScript.superCoinValue;
        }
    }
}
