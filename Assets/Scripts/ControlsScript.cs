using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("IntroScene");
        }
    }
}
