using UnityEngine;
using System.Collections;

public class Victim : BaseBehaviour {

    private bool moveDown = true;
    private bool locationTop = true;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (rb.position.y < ConfigurationScript.victimBottomTopPosition)
            locationTop = false;
        
        Movement();
    }

    void Movement()
    {
        if (moveDown)
            rb.velocity = new Vector2(rb.velocity.x, -ConfigurationScript.victimSpeed);
        else
            rb.velocity = new Vector2(rb.velocity.x, ConfigurationScript.victimSpeed);

        if (locationTop)
        {
            if (rb.position.y > ConfigurationScript.victimTopTopPosition)
                moveDown = true;
            else if (rb.position.y < ConfigurationScript.victimTopBottomPosition)
                moveDown = false;
        }
        else
        {
            if (rb.position.y > ConfigurationScript.victimBottomTopPosition)
                moveDown = true;
            else if (rb.position.y < ConfigurationScript.victimBottomBottomPosition)
                moveDown = false;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col){
		switch (col.transform.tag) {
		case "Player":
			Destroy (gameObject);
			break;
		}
	}
}
