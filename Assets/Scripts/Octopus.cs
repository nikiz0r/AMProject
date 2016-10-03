using UnityEngine;
using System.Collections;

public class Octopus : MonoBehaviour {

    public float octoSpeed;
    private float coolDown;
    private Rigidbody2D octoRb;
    public GameObject tinta;

    // Use this for initialization
	void Start () {
        octoRb = GetComponent<Rigidbody2D>();
        coolDown = 1;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Shoot();
	}

    void Move()
    {
        octoRb.velocity = new Vector3(octoSpeed, 0, 0);
    }

    void Shoot()
    {
        if (Time.time >= coolDown)
        {
            //GameObject tintatiro = (GameObject)Instantiate(tinta, transform.position, transform.rotation);
            //tintatiro.GetComponent<Rigidbody2D>().velocity = new Vector3(octoSpeed*2, 0);
            Instantiate(tinta, transform.position, transform.rotation);
            coolDown = Time.time + Random.Range(3, 5);
        }
    }
}
