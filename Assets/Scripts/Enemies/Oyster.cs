using UnityEngine;
using System.Collections;

public class Oyster : MonoBehaviour {

    public float oysterSpeed, pearlSpeed;
    private Rigidbody2D oysterRb;
    public Player playerScript;
    public GameObject perola;
    private float coolDown;
    public Vector2 recoil;
    private Vector2 direction;
    void Start()
    {
        oysterSpeed = 20;
        direction = new Vector2(-1, 0);
        oysterRb = GetComponent<Rigidbody2D>();
        //StartCoroutine(Move());
    }

    void Update()
    {
        oysterRb.AddForce(new Vector2(direction.x * oysterSpeed, direction.y * oysterSpeed));
    }


    IEnumerator Move()
    {
        while (true)
        {
            
            //transform.Translate(oysterSpeed * Vector3.right * Time.deltaTime, Camera.main.transform);
            //Debug.Log(Time.time);
            yield return new WaitForSeconds(1f);
        }
    }

    /*
    // Use this for initialization
	void Start () {

        playerScript = FindObjectOfType(typeof(Player)) as Player;
        oysterRb = GetComponent<Rigidbody2D>();
        //perolaRb = GetComponent<Rigidbody2D>();
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
            float forca = perolaClone.GetComponent<Rigidbody2D>().velocity.x;
            print("forca" + forca);
            KnockBack(forca);
            StopKnock();
            coolDown = Time.time + Random.Range(1,3);
        }
    }
    void KnockBack(float forca)
    {
        oysterRb.AddForce(new Vector2(-forca*10, 0));
    }
    void StopKnock()
    {
        oysterRb.velocity = Vector3.zero;
        oysterRb.angularVelocity = 0;
    }
    void Move()
    {
        transform.Translate(oysterSpeed * Vector3.right * Time.deltaTime, Camera.main.transform);
    }
    */
  
}