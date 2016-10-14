using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	
	public void StartBt(){
		SceneManager.LoadScene("GameScene");
	}

	public void RankBt(){
		SceneManager.LoadScene("RankScene");
	}

	public void ControlsBt(){
		SceneManager.LoadScene("ControlsScene");
	}

    public void QuitBt()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F8))
            SceneManager.LoadScene("Credits");
    }
}
