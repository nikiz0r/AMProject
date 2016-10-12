using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudControl : MonoBehaviour {

    public PlayerBF playerBf;
    public BossShotControl boss;
    public Slider bossSlider, playerSlider;
    private float playerPrevHp, bossPrevHp;
    public Text score;

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
        score.text = string.Format("Score: {0}", ConfigurationScript.score);

        if (playerBf.hp == 0)
            StartCoroutine(GameOver());
        else if (boss.bossHp == 0)
        {
            StartCoroutine(Credits());
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

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("RankScene");
    }

    IEnumerator Credits()
    {
        yield return new WaitForSeconds(5);
        ConfigurationScript.score += ConfigurationScript.bossDeathValue;
        SceneManager.LoadScene("Credits");
    }
}
