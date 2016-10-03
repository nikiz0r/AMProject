using UnityEngine;
using System.Collections;

public class PlayerBF : MonoBehaviour {

    private Rigidbody2D playerBFRb;
    private float directionX, directionY, speed, bulletSpeed;
    public int hp, bulletLimit;
    public Transform bfGun;
    public GameObject bullet;
    // Use this for initialization
	void Start () {
        playerBFRb = GetComponent<Rigidbody2D>();
        speed = 10;
        bulletSpeed = 200;
        hp = 10;
	}
	
	// Update is called once per frame
	void Update () {
        bulletLimit = GameObject.FindGameObjectsWithTag("Bullet").Length + 1;
        Move();
        Shoot();
	}

    void Shoot()
    {
        if (bulletLimit <= 3)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bfBullet = (GameObject)Instantiate(bullet, bfGun.position, bfGun.rotation);
                //bfBullet.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f);
                bfBullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
            }
        }
    }

    void Move()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical");
        playerBFRb.velocity = new Vector3(directionX * speed, directionY * speed, 0);
    }
}
