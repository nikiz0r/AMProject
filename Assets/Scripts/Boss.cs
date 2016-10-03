using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour {
    private Rigidbody2D bossRb;
    private List<Vector3> moveArray = new List<Vector3>();
    private BossShotControl bossShCt;
    // Use this for initialization
    void Start()
    {
        bossShCt = (BossShotControl)FindObjectOfType(typeof(BossShotControl));
        bossRb = GetComponent<Rigidbody2D>();
        moveArray.Add(new Vector3(0, 2f, 0));
        moveArray.Add(new Vector3(0, -2f, 0));
        InvokeRepeating("movement", 2f, 2f);
    }


    void movement()
    {
        if (bossShCt.routIsRunning == false)
        {
            if (transform.position.y >= 2.8)
            {
                transform.Translate(new Vector3(0, -2f, 0));
            }
            else if (transform.position.y <= -2.7)
            {
                transform.Translate(new Vector3(0, 2f, 0));
            }
            else
            {
                transform.Translate(moveArray[Random.Range(0, moveArray.Count)]);
            }
        }
    }
}
