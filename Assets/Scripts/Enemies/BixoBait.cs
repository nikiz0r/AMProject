using UnityEngine;
using System.Collections;

public class BixoBait : BaseBehaviour {

    public GameObject bixao, danger;
    private bool bixaoInstanciado = false;

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
            if (!bixaoInstanciado)
            {
                Instantiate(danger, new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y + ConfigurationScript.DangerYPos), gameObject.transform.rotation);
                bixaoInstanciado = true;
                Instantiate(bixao, new Vector2(col.gameObject.transform.position.x, ConfigurationScript.BixaoYStartPos), gameObject.transform.rotation);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
