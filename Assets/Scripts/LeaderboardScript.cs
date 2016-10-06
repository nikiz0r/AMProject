using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class LeaderboardScript : MonoBehaviour {

    private HandleScore _handleScore = new HandleScore();
    private bool resetLeaderboard = false; // CUIDADO AQUI

    // Use this for initialization
    void Start () {
        if (!resetLeaderboard)
        {
            //_handleScore.AddScore("TDP");

            var leaderboard = _handleScore.GetScore().OrderByDescending(x => x.score).ToList();

            for (int i = 0; i < leaderboard.Count; i++)
            {
                transform.Find("Names/Name" + i).GetComponent<Text>().text = leaderboard[i].name;
                transform.Find("Scores/Score" + i).GetComponent<Text>().text = leaderboard[i].score.ToString();
            }
        }
        else
            ResetLeaderboard();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void ResetLeaderboard()
    {
        PlayerPrefs.DeleteKey("leaderboard");
    }
}
