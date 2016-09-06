using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    void Update(){
        IsVisible();
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
        {
            Destroy(this.gameObject);
        }
    }
}
