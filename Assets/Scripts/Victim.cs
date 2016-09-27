using UnityEngine;
using System.Collections;

public class Victim : BaseBehaviour {

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D col){
		switch (col.transform.tag) {
		case "Player":
			Destroy (gameObject);
			break;
		}
	}
}
