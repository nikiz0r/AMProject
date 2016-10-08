using UnityEngine;
using System.Collections;

public class LightArea : MonoBehaviour {
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
                playerBf.isParalyzed = true;
                break;
        }
    }
}
