using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BossShotControl : MonoBehaviour {

    public GameObject bossShot;
    public Transform BulletSpawn;   
    private float fireRate, nextFire;
    private Rigidbody2D bossControlRb;
    private Transform angleLight;
    private float zRotation = 0.1f;
    private float angleRotation = 1f;
    private float angleRotation2 = -1f;
    private bool compTurn = false;
    private bool isMoving = false;
    public bool routIsRunning = false;
    private float endTime, angleCount;
    private int moveCount;
    public float bossHp, prevHp;
    public Slider bossSlider;

    private List<string> routList = new List<string>();

    //private List<Vector3> moveSide = new List<Vector3>();
    // Use this for initialization
    void Awake()
    {
        angleLight = GetComponent<Transform>();
    }
    void Start () {
        bossSlider = GetComponent<Slider>();
        bossHp = 30;
        prevHp = bossHp;
        bossControlRb = GetComponent<Rigidbody2D>();
        moveCount = 0;
        angleLight.eulerAngles = new Vector3(0, 0, zRotation);
        routList.Add("RotationL");
        routList.Add("RotationR");
        routList.Add("MultiForw");
        routList.Add("MultiWay");
        routList.Add("InvMultWay");
        StartCoroutine(routList[Random.Range(0, routList.Count)]);
    }
    IEnumerator MultiForw()
    {
        fireRate = 0.12f;
        nextFire = 0.06f;
        zRotation = 0.1f;
        isMoving = true;
        routIsRunning = true;
        while (compTurn == false)
        {
            if (moveCount <= 3)
            {
                angleLight.eulerAngles = new Vector3(0, 0, zRotation);
                zRotation += angleRotation;
                if (zRotation <= -50 || zRotation >= 50)
                {
                    angleRotation *= -1;
                    moveCount += 1;
                }
            }
            else
            {
                compTurn = true;
                isMoving = false; 
            }
            yield return new WaitForSeconds(0.01f);
        }
        routIsRunning = false;
        endTime = Time.time;
    }
    IEnumerator InvMultWay()
    {
        fireRate = 0.04f;
        nextFire = 0.06f;
        zRotation = 90f;
        isMoving = true;
        routIsRunning = true;
        angleRotation = 1f;
        angleCount = 0;
        while (compTurn == false)
        {
            if (angleCount <= 90)
            {
                angleLight.eulerAngles = new Vector3(0, 0, zRotation);
                if (zRotation > 0)
                {
                    zRotation -= angleRotation;
                }
                else
                {
                    zRotation += angleRotation;
                }
                zRotation *= -1;
                angleCount += 1;
            }
            else
            {
                compTurn = true;
                isMoving = false;
            }

            yield return new WaitForSeconds(0.01f);
        }
        routIsRunning = false;
        endTime = Time.time;
    }
    IEnumerator MultiWay()
    {
        fireRate = 0.04f;
        nextFire = 0.06f;
        zRotation = 0.1f;
        isMoving = true;
        routIsRunning = true;
        angleRotation = 1f;
        angleCount = 0;
        while (compTurn == false)
        {
            if (angleCount <= 90)
            {
                angleLight.eulerAngles = new Vector3(0, 0, zRotation);
                if (zRotation > 0)
                {
                    zRotation += angleRotation;
                }
                else
                {
                    zRotation += angleRotation2;
                }
                zRotation *= -1;
                angleCount += 1;
            }
            else
            {
                compTurn = true;
                isMoving = false;
            }

            yield return new WaitForSeconds(0.01f);
        }
        routIsRunning = false;
        endTime = Time.time;
    }
    IEnumerator RotationR()
    {

        fireRate = 0.08f;
        nextFire = 0.06f;
        zRotation = 0.3f;
        isMoving = true;
        routIsRunning = true;
        while (compTurn == false)
        {
            angleLight.eulerAngles = new Vector3(0, 0, zRotation);
            zRotation += -1f;
            if (zRotation <= -359.9 || zRotation >= 359.9)
            {
                compTurn = true;
                isMoving = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
        routIsRunning = false;
        endTime = Time.time;
    }
    IEnumerator RotationL()
    {
        fireRate = 0.08f;
        nextFire = 0.06f;
        zRotation = 0.3f;
        isMoving = true;
        routIsRunning = true;
        while (compTurn == false)
        {
            angleLight.eulerAngles = new Vector3(0, 0, zRotation);
            zRotation += 1f;
            if (zRotation <= -359.9 || zRotation >= 359.9)
            {
                compTurn = true;
                isMoving = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
        routIsRunning = false;
        endTime = Time.time;
    }
    void Update()
    {
        if (routIsRunning)
        {
            if (isMoving == true)
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(bossShot, BulletSpawn.position, BulletSpawn.rotation);
                }
            }
        }
        else
        {
            if (Time.time > (endTime + 2f))
            {
                compTurn = false;
                StartCoroutine(routList[Random.Range(0, routList.Count)]);
            }
        }
    }
}