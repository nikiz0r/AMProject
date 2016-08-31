using UnityEngine;
using System.Collections;

public class Perola : MonoBehaviour {
    
    public Vector2 recoil;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        IsVisible();
	}

    /*void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.transform.tag)
        {
            case "enemy1":
                Destroy(col.gameObject);
                Destroy(this.gameObject);
                break;
        }
    }*/
    void IsVisible()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}
