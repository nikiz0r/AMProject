using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col){
        switch (col.gameObject.tag)
        {
            case "enemy1":
                Destroy(col.gameObject);
                break;
            default:
                break;
        }
	}
}
