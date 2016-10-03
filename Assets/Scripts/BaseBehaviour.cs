using UnityEngine;

public class BaseBehaviour : MonoBehaviour {

    private bool becameVisible = false;
    public Rigidbody2D rb;
    public bool handleVisibilityOnly = false;

    // Use this for initialization
    public virtual void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	public virtual void Update () {
        if (becameVisible)
            IsVisible();

        if (!handleVisibilityOnly)
        {
            if (rb != null)
                rb.velocity = new Vector2(-ConfigurationScript.baseMovement * ConfigurationScript.baseSpeed, rb.velocity.y);
        }
    }

    void IsVisible()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);

            // se tem parent destroi ele tambem
            if (gameObject.transform.parent != null)
                Destroy(gameObject.transform.parent.gameObject);
        }
    }

    void OnBecameVisible()
    {
        becameVisible = true;
    }
}
