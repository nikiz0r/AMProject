using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col){
		switch (col.transform.tag) {
		case "Bomb":
			Destroy (col.gameObject);
            Destroy(this.gameObject);
            break;
		}
	}
}
