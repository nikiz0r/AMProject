using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerBF : MonoBehaviour {

    private Rigidbody2D playerBFRb;
    public Transform bfGun, startPoint;
    public GameObject bullet;
    private SpriteRenderer playerSp;
    private float directionX, directionY, speed, bulletSpeed, invTime, oldOpacity;
    public float prevHp, hp;
    private int bulletLimit;
    public bool isVulnerable, isParalyzed;
    public float opacity, invOpacity;
    // Use this for initialization
    void Start () {
        playerBFRb = GetComponent<Rigidbody2D>();
        playerSp = GetComponent<SpriteRenderer>();
        //heartPos.position = new Vector3(-5.5f, 4.25f);
        //opacity = GetComponent<Color>().a;
        //oldOpacity = opacity;
        //invOpacity = 0.5f;
        speed = 10;
        bulletSpeed = 200;
        hp = 10;
        prevHp = hp;
        invTime = 1f;
        isVulnerable = true;
        isParalyzed = false;
	}
	
	// Update is called once per frame
	void Update () {
        bulletLimit = GameObject.FindGameObjectsWithTag("Bullet").Length + 1;
        Move();
        Shoot();
        //Damage();
        if (!isVulnerable)
        {
            StartCoroutine(Normalize(invTime));
        }
	}
    //void Damage()
    //{
    //    if (prevHp != hp)
    //    {
    //        prevHp = hp;
    //    }
    //}
    
    IEnumerator Normalize(float delay)
    {
        playerSp.enabled = false;
        yield return new WaitForSeconds(delay/8);
        playerSp.enabled = true;
        yield return new WaitForSeconds(delay / 8);
        playerSp.enabled = false;
        yield return new WaitForSeconds(delay / 8);
        playerSp.enabled = true;
        yield return new WaitForSeconds(delay / 8);
        playerSp.enabled = false;
        yield return new WaitForSeconds(delay / 8);
        playerSp.enabled = true;
        yield return new WaitForSeconds(delay / 8);
        playerSp.enabled = false;
        yield return new WaitForSeconds(delay / 8);
        playerSp.enabled = true;
        isVulnerable = true;
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
        if (!isParalyzed)
        {
            directionX = Input.GetAxisRaw("Horizontal");
            directionY = Input.GetAxisRaw("Vertical");
            playerBFRb.velocity = new Vector3(directionX * speed, directionY * speed, 0);
        }
        else
        {
            isVulnerable = false;
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed/40);
        }
        if (transform.position == startPoint.position)
        {
            isParalyzed = false;
        }
    }
}
