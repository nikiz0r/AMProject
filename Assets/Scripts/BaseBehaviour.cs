using UnityEngine;
using System.Collections;

public class BaseBehaviour : MonoBehaviour {

    private bool becameVisible = false;
    public Rigidbody2D rb;
    private MainScript mainScript;
    public bool handleVisibilityOnly = false;

    // Use this for initialization
    public virtual void Start () {
        rb = GetComponent<Rigidbody2D>();
        mainScript = (MainScript)FindObjectOfType(typeof(MainScript));
    }
	
	// Update is called once per frame
	public virtual void Update () {
        if (becameVisible)
            IsVisible();

        if (!handleVisibilityOnly)
        {
            if (rb != null)
                rb.velocity = new Vector2(-1 * mainScript.speed, rb.velocity.y);
        }
    }

    void IsVisible()
    {
        if (!GetComponent<Renderer>().isVisible)
            Destroy(this.gameObject);
    }

    void OnBecameVisible()
    {
        becameVisible = true;
    }
}
