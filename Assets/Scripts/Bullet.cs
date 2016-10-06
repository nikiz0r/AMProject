using UnityEngine;

public class Bullet : MonoBehaviour {
    private Player playerScript;

    void Start(){
        playerScript = (Player)FindObjectOfType(typeof(Player));
    }

    void Update(){
        IsVisible();

        if (playerScript.leftSide){
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
	
	void OnTriggerEnter2D(Collider2D col){
		switch (col.transform.tag) {
		case "enemy1":
			Destroy (col.gameObject);
            Destroy(this.gameObject);
            break;
		}
	}

    void IsVisible(){
        if (!GetComponent<Renderer>().isVisible)
            Destroy(this.gameObject);
    }
}
