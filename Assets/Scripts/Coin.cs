using UnityEngine;

public class Coin : BaseBehaviour {
	private AudioSource coinSd;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
		coinSd = GetComponent<AudioSource> ();
		coinSd.Stop ();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
			coinSd.Play ();
            Destroy(gameObject,0.1f);
            ConfigurationScript.score += ConfigurationScript.regularCoinValue;
        }
    }
}
