using UnityEngine;
using System.Collections;

public class Oyster : MonoBehaviour {

    public float oysterSpeed, pearlSpeed;
    private Rigidbody2D oysterRb, perolaRb;
    public Player playerScript;
    public GameObject perola;
    private float coolDown;
    
    // Use this for initialization
	void Start () {

        playerScript = FindObjectOfType(typeof(Player)) as Player;
        oysterRb = GetComponent<Rigidbody2D>();
        perolaRb = GetComponent<Rigidbody2D>();
        //StartCoroutine("Move");
        coolDown = Random.Range(1, 3);
        InvokeRepeating("Move", 0.5f, 2f);

    }
	
	// Update is called once per frame
	void Update () {
        Shoot();
    }
    void Shoot()
    {
        
        if (Time.time >= coolDown)
        {
            GameObject perolaClone = (GameObject)Instantiate(this.perola, this.transform.position, this.transform.rotation);
            perolaClone.GetComponent<Rigidbody2D>().velocity = new Vector3(oysterSpeed, 0);
            //perolaClone.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(perolaClone.transform.position, playerScript.transform.position, pearlSpeed * Time.deltaTime);
            //perolaClone.transform.position = Vector3.MoveTowards(perolaClone.transform.position, playerScript.transform.position,  * Time.deltaTime);
            //perolaClone.transform.position = new Vector3(oysterSpeed * perolaClone.transform.position.x, perolaClone.transform.position.y, perolaClone.transform.position.z);
            coolDown = Time.time + Random.Range(1,3);
        }
    }
    void Move()
    {
        transform.Translate(oysterSpeed * Vector3.right * Time.deltaTime, Camera.main.transform);
    }
  
}