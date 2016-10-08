using UnityEngine;
using System.Collections;

public class BombExplosion : BaseBehaviour {

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Destroy(gameObject, 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Coin":
            case "Melee":
            case "LimitsScene":
                break;
            case "Player":
                Destroy(col.gameObject);
                break;
            default:
                break;
        }
    }
}
