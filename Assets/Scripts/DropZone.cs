using UnityEngine;
using System.Collections;

public class DropZone : BaseBehaviour {

    private bool RescueActivated = false;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !RescueActivated)
        {
            RescueActivated = true;
            StartCoroutine(Rescue());
        }
    }

    IEnumerator Rescue()
    {
        // contabiliza os pontos para cada vitima, multiplicando para quanto mais tiverem sido coletadas
        int totalPts = ConfigurationScript.victimBaseValue * ConfigurationScript.victimsCollected * ConfigurationScript.victimsCollected * 2;
        
        yield return StartCoroutine(AddPoints(totalPts));
        rb.velocity = new Vector2(rb.velocity.x, ConfigurationScript.baseMovement * ConfigurationScript.baseSpeed);

        // reseta a qtde de vitimas e restaura os atributos base do player
        ConfigurationScript.victimsCollected = 0;
        ConfigurationScript.playerSpeed = ConfigurationScript.playerBaseSpeed;
        ConfigurationScript.jumpForce = ConfigurationScript.baseJumpForce;
        ConfigurationScript.jumpBoost = ConfigurationScript.baseJumpBoost;
    }

    IEnumerator AddPoints(int points)
    {
        Time.timeScale = 0;
        int x = points / 100;
        while (points > 0)
        {
            yield return new WaitForSecondsRealtime(0.02f);
            ConfigurationScript.score += x;
            points -= x;
        }

        Time.timeScale = 1;
    }
}
