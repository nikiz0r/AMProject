using UnityEngine;
using System.Collections;

public class Shoal : MonoBehaviour {

    private Player playerScript;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerScript = (Player)FindObjectOfType(typeof(Player));
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Move());
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        playerScript.movementBlock = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        playerScript.movementBlock = false;
    }

    IEnumerator Move()
    {
        rb.velocity = new Vector2(ConfigurationScript.shoalMovementSpeed, rb.velocity.y);
        yield return new WaitForSeconds(ConfigurationScript.shoalDelayTime);
        rb.velocity = new Vector2(-ConfigurationScript.shoalMovementSpeed, rb.velocity.y);
        yield return new WaitForSeconds(ConfigurationScript.shoalDelayTime);
        playerScript.shoalExists = false;
        Destroy(gameObject);
    }
}