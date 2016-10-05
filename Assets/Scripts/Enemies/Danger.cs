using UnityEngine;
using System.Collections;

public class Danger : MonoBehaviour {

    private Player player;

    // Use this for initialization
    void Start () {
        player = (Player)FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y + ConfigurationScript.DangerYPos);

        Destroy(gameObject, 0.8f);
    }
}
