using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    public GameObject bombExplosion;
    private Rigidbody2D rb;
    private MainScript mainScript;
    private bool becameVisible = false;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        mainScript = (MainScript)FindObjectOfType(typeof(MainScript));
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = new Vector2(-1 * mainScript.speed, rb.velocity.y);

        if (becameVisible)
            IsVisible();
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
        Instantiate(bombExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
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
