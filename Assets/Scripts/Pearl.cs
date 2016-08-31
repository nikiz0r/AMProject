using UnityEngine;
using System.Collections;

public class Pearl : MonoBehaviour {
    public Rigidbody2D pearlRb;
    public Player playerScript;
    public Vector2 recoil;

	// Use this for initialization
	void Start () {
        pearlRb = GetComponent<Rigidbody2D>();   
        playerScript = FindObjectOfType(typeof(Player)) as Player;
    }
	
	// Update is called once per frame
	void Update () {
       // transform.root.GetComponent<Oyster>().recoil = recoil;
        pearlRb.transform.position = Vector3.MoveTowards(pearlRb.transform.position, playerScript.transform.position, 2 * Time.deltaTime);
	}
}
