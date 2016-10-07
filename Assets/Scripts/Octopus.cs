using UnityEngine;
using System.Collections;

public class Octopus : BaseBehaviour {

    private float coolDown;
    public GameObject tinta;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        coolDown = 1;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Shoot();
    }

    void Shoot()
    {
        if (Time.time >= coolDown)
        {
            Instantiate(tinta, transform.position, transform.rotation);
            coolDown = Time.time + Random.Range(3, 5);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Player":
                Destroy(gameObject);
                Destroy(col.gameObject);
                break;
            case "Bullet":
            case "Melee":
                ConfigurationScript.score += ConfigurationScript.octopusValue;
                break;
            default:
                break;
        }
    }
}
