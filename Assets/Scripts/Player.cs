using UnityEngine;

public class Player : MonoBehaviour {

	/* VALORES PARA MOVIMENTACAO PLAYER (PARA EFEITO DE PADRONIZACAO ESSAS VARIAVEIS NAO ESTAO
	 MAIS PUBLICAS E SIM SEUS VALORES JA INPUTADOS NO START).
	 * speed: 10
	 * speedBullet: 15
	 * jumpForce: 600
	 * jumpBoost: 40
	 * dashForce: 5000
	 */

	private float direction, jumpBoost;
	private bool grounded, jumped;
	private int bulletLimit;
    public Transform groundCheck, gun;
    public LayerMask ground;
    public GameObject bullet,melee;
	private Rigidbody2D playerRb;
	private Transform playerTr;
    private MainScript mainScript;
    public bool movementBlock = false;
    public bool leftSide;
    public ParticleSystem bubbles;
	private AudioSource jumpSound;

    public bool shoalExists = false;
    public GameObject shoal;

    public float dashCount = 3;

	void Awake(){
		bubbles.Stop();
	}

    void Start () {
		jumpSound = GetComponent<AudioSource> ();
        mainScript = (MainScript)FindObjectOfType(typeof(MainScript));
		melee.SetActive (false);
        playerRb = GetComponent<Rigidbody2D>();
        playerTr = GetComponent<Transform>();
        InvokeRepeating("DashSum", 1, 1);
		jumpSound.Stop ();
	}
	
	void Update () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f,ground);

		//LIMITADOR DE BALAS NA TELA
		bulletLimit = GameObject.FindGameObjectsWithTag("Bullet").Length + 1;

        Jump();
		Shoot();
		Dash();
		MeleeAttack();
        if (grounded){
            bubbles.Play();
        }
	}

    void FixedUpdate(){
        Move();
    }

    void Move(){
        direction = Input.GetAxisRaw("Horizontal");

        if (!movementBlock)
            playerRb.velocity = new Vector3(direction * ConfigurationScript.playerSpeed, playerRb.velocity.y);

        if(direction < 0){
            playerTr.localScale = new Vector3(-1,1,1);
            leftSide = true;
        }
        else if(direction > 0)
        {
            playerTr.localScale = new Vector3(1,1,1);
            leftSide = false;
        }

        if (transform.position.x <= ConfigurationScript.shoalTriggerPosition && !shoalExists)
            ShoalAction();
    }

    void Jump(){
		if (Input.GetButtonDown("Jump") && grounded) {
            playerRb.AddForce(new Vector2(0, ConfigurationScript.jumpForce));
			jumped = true;
            bubbles.Play();
			jumpSound.Play ();
        }
		if (Input.GetButton("Jump") && jumped){
			jumped = true;
			if (playerTr.position.y > -1 || playerTr.position.y > 3.99) {
				jumpBoost = 0;
			} else {
				jumpBoost = ConfigurationScript.jumpBoost;
			}
            playerRb.AddForce(new Vector2(0, jumpBoost));
        }
		if (Input.GetButtonUp("Jump") && jumped){
			jumped = false;
		}
    }

    void Shoot(){
		if (bulletLimit <= ConfigurationScript.bulletLimit && !mainScript.paused) {
			if (Input.GetButtonDown("Fire1")) {
				GameObject shoot = (GameObject)Instantiate(bullet, gun.position, transform.rotation);
				if(leftSide == true){
					shoot.GetComponent<Rigidbody2D>().velocity = new Vector3(ConfigurationScript.speedBulletL, 0);
				}
				else if(leftSide == false && !mainScript.paused)
                {
					shoot.GetComponent<Rigidbody2D>().velocity = new Vector3(ConfigurationScript.speedBulletR, 0);
				}
			}
		}
    }

	void Dash(){
        if (Input.GetButtonDown("Fire2") && !mainScript.paused && !movementBlock && dashCount > 0) {
			if (leftSide == false)
				playerRb.AddForce (new Vector2 (ConfigurationScript.dashForce, 0));
			else if (leftSide == true)
				playerRb.AddForce (new Vector2 (-ConfigurationScript.dashForce, 0));
            dashCount--;
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
        shoalExists = true;
        Instantiate(shoal, new Vector2(ConfigurationScript.shoalAwakeXPosition, 0), transform.rotation);
    }

    void DashSum(){
        if (dashCount < 3){
            dashCount += 0.15f;
        }
        else if (dashCount >= 3){
            dashCount = 3;
        }
    }
}

