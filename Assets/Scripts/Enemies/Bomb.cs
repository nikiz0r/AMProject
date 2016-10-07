using UnityEngine;
using System.Collections;

public class Bomb : BaseBehaviour {

    public GameObject bombExplosion;

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
        switch (col.transform.tag)
        {
            case "Bullet":
            case "Player":
            case "Melee":
                TriggerExplosion();
                break;
            default:
                break;
        }
    }

    void TriggerExplosion()
    {
        ConfigurationScript.score += ConfigurationScript.bombValue;
        Instantiate(bombExplosion, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }
}
