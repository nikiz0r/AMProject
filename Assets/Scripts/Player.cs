using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed, jumpForce, speedBulletL, speedBulletR;
    public Transform groundCheck, gun;
    public LayerMask ground;
    public GameObject bullet;
    Rigidbody2D playerRb;
    Transform playerTr;
    float direction;
    bool grounded, leftSide;

    void Start () {
        playerRb = GetComponent<Rigidbody2D>();
        playerTr = GetComponent<Transform>();
	}
	
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f,ground);
        Jump();
		Shoot();
	}

    void FixedUpdate(){
        Move();
    }

    void Move(){
        direction = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector3(direction * speed, playerRb.velocity.y);
        if(direction < 0){
            playerTr.localScale = new Vector3(-1,1,1);
            leftSide = true;
        }
        else if(direction > 0){
            playerTr.localScale = new Vector3(1,1,1);
            leftSide = false;
        }
    }

    void Jump(){
        if (Input.GetButtonDown("Jump")&&grounded == true){
            playerRb.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Shoot(){
		if (Input.GetButtonDown("Fire1")) {
			GameObject shoot = (GameObject)Instantiate(bullet, gun.position, transform.rotation);
            if(leftSide == true){
                shoot.GetComponent<Rigidbody2D>().velocity = new Vector3(speedBulletL, 0);
            }
            else if(leftSide == false){
                shoot.GetComponent<Rigidbody2D>().velocity = new Vector3(speedBulletR, 0);
            }
		}
    }
}
