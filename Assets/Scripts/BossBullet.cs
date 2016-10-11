using UnityEngine;

public class BossBullet : MonoBehaviour {

    private Rigidbody2D bulletRb;
    public float speed;
    private PlayerBF playerBf;

    // Use this for initialization
	void Start () {
        bulletRb = GetComponent<Rigidbody2D>();
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
            Destroy(gameObject);
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
