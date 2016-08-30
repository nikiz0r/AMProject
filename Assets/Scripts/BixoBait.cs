using UnityEngine;
using System.Collections;

public class BixoBait : MonoBehaviour {

    public GameObject bixao, danger;
    private MainScript mainScript;
    private bool bixaoInstanciado = false;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!bixaoInstanciado)
            {
                Instantiate(danger, new Vector2(gameObject.transform.position.x, 4.35f), gameObject.transform.rotation);
                bixaoInstanciado = true;
                Instantiate(bixao, new Vector2(gameObject.transform.position.x, 30f), gameObject.transform.rotation);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
