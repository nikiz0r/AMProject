using UnityEngine;

public class BossCollider : MonoBehaviour {
    private PlayerBF playerBf;
    void Start()
    {
        playerBf = (PlayerBF)FindObjectOfType(typeof(PlayerBF));
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                playerBf.hp -= 1;
                playerBf.isVulnerable = false;
                playerBf.isParalyzed = true;
                break;
        }
    }
}
