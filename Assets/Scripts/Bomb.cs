using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    public GameObject bombExplosion;
    private Rigidbody2D rb;
    private MainScript mainScript;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        mainScript = (MainScript)FindObjectOfType(typeof(MainScript));
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = new Vector2(-1 * mainScript.speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.transform.tag)
        {
            case "Bullet":
            case "Player":
                TriggerExplosion();
                break;
            default:
                break;
        }
    }

    void TriggerExplosion()
    {
        Instantiate(bombExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
