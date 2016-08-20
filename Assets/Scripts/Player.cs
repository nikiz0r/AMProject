using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed, jumpForce;
    public Transform groundCheck;
    public LayerMask ground;
    Rigidbody2D playerRb;
    float direction;
    bool grounded;

    void Start () {
        playerRb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f,ground);
        Jump();
	}

    void FixedUpdate(){
        Move();
    }

    void Move(){
        direction = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector3(direction * speed, playerRb.velocity.y);
    }

    void Jump(){
        if (Input.GetButtonDown("Jump")&&grounded == true){
            playerRb.AddForce(new Vector2(0, jumpForce));
        }
    }
}
