using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	/* VALORES PARA MOVIMENTACAO PLAYER (PARA EFEITO DE PADRONIZACAO ESSAS VARIAVEIS NAO ESTAO
	 MAIS PUBLICAS E SIM SEUS VALORES JA INPUTADOS NO START).
	 * speed: 10
	 * speedBullet: 15
	 * jumpForce: 600
	 * jumpBoost: 40
	 * dashForce: 5000
	 */

	private float speed, jumpForce, speedBullet, speedBulletL, speedBulletR, direction, dashForce, jumpBoost;
	private bool grounded, leftSide, jumped;
	private int bulletLimit;
    public Transform groundCheck, gun;
    public LayerMask ground;
    public GameObject bullet,melee;
	private Rigidbody2D playerRb;
	private Transform playerTr;
    public int coinsCollected;
    private MainScript mainScript;
    public bool movementBlock = false;

    void Start () {
		speed = 10;
		jumpForce = 300;
		dashForce = 5000;
		speedBullet = 15;
		speedBulletR = speedBullet;
		speedBulletL = speedBullet * -1;

        mainScript = (MainScript)FindObjectOfType(typeof(MainScript));
		melee.SetActive (false);
        playerRb = GetComponent<Rigidbody2D>();
        playerTr = GetComponent<Transform>();
	}
	
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f,ground);

		//LIMITADOR DE BALAS NA TELA
		bulletLimit = GameObject.FindGameObjectsWithTag ("Bullet").Length + 1;

        Jump();
		Shoot();
		Dash ();
		MeleeAttack ();
	}

    void FixedUpdate(){
        Move();
        ShoalAction();
    }

    void Move(){
        direction = Input.GetAxisRaw("Horizontal");

        if (!movementBlock)
            playerRb.velocity = new Vector3(direction * speed, playerRb.velocity.y);

        if(direction < 0){
            playerTr.localScale = new Vector3(-1,1,1);
            leftSide = true;
        }
        else if(direction > 0)
        {
            playerTr.localScale = new Vector3(1,1,1);
            leftSide = false;
        }
    }

    void Jump(){
		if (Input.GetButtonDown("Jump") && grounded) {
            playerRb.AddForce(new Vector2(0, jumpForce));
			jumped = true;
        }
		if (Input.GetButton("Jump") && jumped){
			jumped = true;
			if (playerTr.position.y > -1 || playerTr.position.y > 3.99) {
				jumpBoost = 0;
			} else {
				jumpBoost = 40;
			}
            playerRb.AddForce(new Vector2(0, jumpBoost));
        }
		if (Input.GetButtonUp("Jump")&&jumped){
			jumped = false;
		}
    }

    void Shoot(){
		if (bulletLimit <= 3 && !mainScript.paused) {
			if (Input.GetButtonDown("Fire1")) {
				GameObject shoot = (GameObject)Instantiate(bullet, gun.position, transform.rotation);
				if(leftSide == true){
					shoot.GetComponent<Rigidbody2D>().velocity = new Vector3(speedBulletL, 0);
				}
				else if(leftSide == false && !mainScript.paused)
                {
					shoot.GetComponent<Rigidbody2D>().velocity = new Vector3(speedBulletR, 0);
				}
			}
		}
    }

	void Dash(){
		if (Input.GetButtonDown("Fire2") && !mainScript.paused && !movementBlock) {
			if (leftSide == false) {
				playerRb.AddForce (new Vector2 (dashForce, 0));
			}
			else if (leftSide == true) {
				playerRb.AddForce (new Vector2 (-dashForce, 0));
			}
		}
	}

	void MeleeAttack(){
        if (!mainScript.paused)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                melee.SetActive(true);
            }
            if (Input.GetButtonUp("Fire3"))
            {
                melee.SetActive(false);
            }
        }
	}

    void ShoalAction()
    {
        //TODO: instanciar o shoal
    }
}
