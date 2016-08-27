using UnityEngine;
using System.Collections;

public class LimitsScene : MonoBehaviour {
	private Camera cam;
	private EdgeCollider2D collider;
	Vector2 downLeft,downRight,upLeft,upRight;

	void Start () {
		cam = Camera.main;
		collider = GetComponent<EdgeCollider2D> ();

		downLeft = cam.ScreenToWorldPoint (new Vector3 (0, 0));
		downRight = cam.ScreenToWorldPoint (new Vector3 (Screen.width, 0));
		upLeft = cam.ScreenToWorldPoint (new Vector3 (0, Screen.height));
		upRight = cam.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height));

		collider.points = new Vector2[5]{ downLeft, upLeft, upRight, downRight, downLeft };

	}
}
