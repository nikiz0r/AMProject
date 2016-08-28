using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col){
		switch (col.transform.tag) {
		case "enemy1":
			Destroy (col.gameObject);
			break;
		}
		Destroy (this.gameObject);
	}
}
