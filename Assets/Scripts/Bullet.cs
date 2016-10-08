using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {
    private Player playerScript;

    void Start(){
        bossShCt = (BossShotControl)FindObjectOfType(typeof(BossShotControl));
        playerScript = (Player)FindObjectOfType(typeof(Player));
    }

    private BossShotControl bossShCt;

    void Update(){
        IsVisible();

        if (playerScript != null)
        {
            if (playerScript.leftSide)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
	
	void OnTriggerEnter2D(Collider2D col){
		switch (col.transform.tag) {
		case "enemy1":
			Destroy (col.gameObject);
            Destroy(this.gameObject);
            break;
        case "Boss":
            bossShCt.bossHp -= 1;
            Destroy(this.gameObject);
            break;
        }
	}

    void IsVisible(){
        if (!GetComponent<Renderer>().isVisible)
            Destroy(this.gameObject);
    }
}
