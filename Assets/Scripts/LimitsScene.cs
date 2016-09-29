using UnityEngine;

public class LimitsScene : MonoBehaviour {
	private Camera cam;
	private EdgeCollider2D colider;
	Vector2 downLeft,downRight,upLeft,upRight;

	void Start () {
		cam = Camera.main;
		colider = GetComponent<EdgeCollider2D> ();

		downLeft = cam.ScreenToWorldPoint (new Vector3 (0, 0));
		downRight = cam.ScreenToWorldPoint (new Vector3 (Screen.width, 0));
		upLeft = cam.ScreenToWorldPoint (new Vector3 (0, Screen.height));
		upRight = cam.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height));

		colider.points = new Vector2[5]{ downLeft, upLeft, upRight, downRight, downLeft };
	}
}
