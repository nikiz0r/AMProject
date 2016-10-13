using UnityEngine;
using System.Collections;

public class Plants : MonoBehaviour {

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < -18) {
			transform.position = new Vector3 (0, transform.position.y, 0);
		}

        if (Time.timeScale > 0)
            Move ();
	}

	void Move(){
		transform.Translate (ConfigurationScript.backGroundSpeed, 0, 0);
	}
}
