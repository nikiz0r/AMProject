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

	public void MenuS(){
		SceneManager.LoadScene("Menu");
	}
}
