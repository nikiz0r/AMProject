using UnityEngine;
using System.Collections;

public class Baiacu : MonoBehaviour {
    private Player playerScript;
    public float baiacuSpeed, distanceX, distanceY;
    private Rigidbody2D baiacuRb;
    //private SpriteRenderer baiacuSprite;
    public Sprite baiacu, baiacuzao;
    //private BoxCollider2D baiacuCr;
    //private int baiacuHp;
	// Use this for initialization
	void Start () {
        baiacuRb = GetComponent<Rigidbody2D> ();
        //baiacuSprite = GetComponent<SpriteRenderer>();
        playerScript = FindObjectOfType(typeof(Player)) as Player;
        //baiacuCr = GetComponent<BoxCollider2D>();
        
        //print("localscale " + transform.localScale);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Inflate();
        
	}

    
    void Move()
    {

        baiacuRb.velocity = new Vector3(-1 * baiacuSpeed, baiacuRb.velocity.y);
        //print("Baiacu " + baiacuRb.transform.position.x);

    }
    
    void Inflate()
    {
        if(playerScript.transform.position.x > baiacuRb.transform.position.x)
        {
            distanceX = playerScript.transform.position.x - baiacuRb.transform.position.x;
        }
        else if(playerScript.transform.position.x < baiacuRb.transform.position.x)
        {
            distanceX = baiacuRb.transform.position.x - playerScript.transform.position.x ;
        }
        if(playerScript.transform.position.y > baiacuRb.transform.position.y)
        {
            distanceY = playerScript.transform.position.y - baiacuRb.transform.position.y;
        }
        else if(playerScript.transform.position.y < baiacuRb.transform.position.y)
        {
            distanceY = baiacuRb.transform.position.y - playerScript.transform.position.y;
        }
        //print("Distance " + distance);
        if(distanceX < 1.2 && distanceY < 1.2)
        {
            /*Codigo para trocar o sprite e mudar o tamanho do hitbox
            baiacuSprite.sprite = baiacuzao;
            baiacuCr.size = new Vector3(0.6f,0.6f);*/
            transform.localScale = new Vector3(3, 3);
        }
    }
}
