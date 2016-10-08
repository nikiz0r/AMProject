using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HudControl : MonoBehaviour {

    public PlayerBF playerBf;
    public BossShotControl boss;
    private Image playerSliderIm, bossSliderIm;
    public Slider bossSlider, playerSlider;
    private float playerPrevHp, bossPrevHp;
    // Use this for initialization
	void Start () {
        playerBf = (PlayerBF)FindObjectOfType(typeof(PlayerBF));
        boss = (BossShotControl)FindObjectOfType(typeof(BossShotControl));
        playerPrevHp = playerBf.hp;
        bossPrevHp = boss.bossHp;
        ResetValues();
        
	}
    void ResetValues()
    {
        bossSlider.maxValue = 30;
        bossSlider.minValue = 0;
        bossSlider.value = 30;
        boss.bossHp = bossSlider.maxValue;
        playerPrevHp = playerBf.hp;
        bossPrevHp = boss.bossHp;
    }
	// Update is called once per frame
	void Update () {
        if (playerBf.hp == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (boss.bossHp == 0)
        {
            SceneManager.LoadScene("Credits");
        }
        if (playerBf.hp != playerPrevHp)
        {
            playerSlider.value = playerBf.hp;
            playerPrevHp = playerBf.hp;
        }
        if (boss.bossHp != bossPrevHp)
        {
            bossSlider.value -= 1;
            bossPrevHp = boss.bossHp;
        }
	}
}
