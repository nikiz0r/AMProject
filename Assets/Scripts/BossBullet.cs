using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossBullet : MonoBehaviour {

    //public Transform controlTr;
    private Rigidbody2D bulletRb;
    public float speed;
    private Transform bulletTr;
    private PlayerBF playerBf;
    // Use this for initialization
	void Start () {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletTr = GetComponent<Transform>();
        playerBf = (PlayerBF)FindObjectOfType(typeof(PlayerBF));
	}
	
	// Update is called once per frame
	void Update () {
        bulletRb.AddForce(transform.right * speed);
        IsVisible();
	}
    void IsVisible()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                if (playerBf.isVulnerable)
                {
                    Destroy(gameObject);
                    playerBf.hp -= 1;
                    playerBf.isVulnerable = false;
                }
                break;
        }
    }
}
