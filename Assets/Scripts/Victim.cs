using UnityEngine;
using System.Collections;

public class Victim : MonoBehaviour {
	public GameObject victim;
	public Transform a, b;
	public float speed;
	private Vector3 way;
	private MainScript mainScript;
	private Rigidbody2D victimRB;

	void Start () {
		victimRB = GetComponent<Rigidbody2D> ();
		mainScript = (MainScript) FindObjectOfType(typeof(MainScript));
		way = b.position;
	}

	void Update () {
		Move ();
	}

	void Move(){
		//victimRB.velocity = new Vector3 (-1 * mainScript.speed, victimRB.velocity.y);
		victim.transform.position = Vector3.MoveTowards (victim.transform.position, way,speed * Time.deltaTime);
		if (victim.transform.position == way) {
			if (way == a.position) {
				b.position = new Vector3(b.position.x,Random.Range (-2, 2));
				way = b.position;
			}
			else if (way == b.position) {
				a.position = new Vector3(a.position.x,Random.Range (-2, 2));
				way = a.position;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		switch (col.transform.tag) {
		case "Player":
			Destroy (this.gameObject);
			break;
		}
	}
}
