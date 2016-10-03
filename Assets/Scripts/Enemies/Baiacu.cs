using UnityEngine;

public class Baiacu : BaseBehaviour {
    private Player playerScript;
    public float distanceX, distanceY;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        playerScript = FindObjectOfType(typeof(Player)) as Player;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (playerScript != null)
            Inflate();
    }

    void Inflate()
    {
        if(playerScript.transform.position.x > rb.transform.position.x)
            distanceX = playerScript.transform.position.x - rb.transform.position.x;
        else if(playerScript.transform.position.x < rb.transform.position.x)
            distanceX = rb.transform.position.x - playerScript.transform.position.x ;
        if(playerScript.transform.position.y > rb.transform.position.y)
            distanceY = playerScript.transform.position.y - rb.transform.position.y;
        else if(playerScript.transform.position.y < rb.transform.position.y)
            distanceY = rb.transform.position.y - playerScript.transform.position.y;

        if (distanceX < 2.5 && distanceY < 2.5)
            transform.localScale = new Vector3(3, 3);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            Destroy(col.gameObject);
    }
}
