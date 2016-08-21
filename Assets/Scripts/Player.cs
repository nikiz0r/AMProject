using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed, jumpForce, speedBullet;
    public Transform groundCheck, gun;
    public LayerMask ground;
    public GameObject bullet;
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

    void Shoot(){
        GameObject shoot = (GameObject)Instantiate(bullet, gun.position, transform.rotation);
		shoot.GetComponent<Rigidbody2D>().velocity = new Vector3(speedBullet, 0);
    }
}
