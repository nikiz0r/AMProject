using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class HighScore : MonoBehaviour
{
    public bool gameOver;

    void Start()
    {
        gameOver = false;
    }
    
    void OnGameOver()
    {
        gameOver = true;
    }

    void OnGUI()
    {
        if (gameOver)
        {
            var leaderboard = new HandleScore().GetScore();

            for (int i = 0; i < leaderboard.Count; i++)
            {
                GUI.Box(new Rect(100, 75 * i, 150, 50), i + ". " + leaderboard[i].name + " - " + leaderboard[i].score);
            }
        }
    }
}

public class Score : IComparable<Score>
{
    public string name;
    public int score;

    public int CompareTo(Score other)
    {
        return score.CompareTo(other.score);
    }
}

public class HandleScore
{
    public static List<Score> scoreIndex = new List<Score>(5);

    public List<Score> GetScore()
    {
        if (PlayerPrefs.GetString("leaderboard") != "")
        {
            var arrRanking = PlayerPrefs.GetString("leaderboard").Split('|');

            foreach (var item in arrRanking)
            {
                if (item != "")
                {
                    var r = item.Split('&');

                    scoreIndex.Add(new Score
                    {
                        name = r[0].Substring(r[0].IndexOf('=') + 1, r[0].Length - (r[0].IndexOf('=') + 1)),
                        score = int.Parse(r[1].Substring(r[1].IndexOf('=') + 1, r[1].Length - (r[1].IndexOf('=') + 1)))
                    });
                }
            }
        }

        return scoreIndex;
    }

    public void AddScore(string name)
    {
        GetScore();

        scoreIndex.Add(new Score
        {
            name = name,
            score = ConfigurationScript.score
        });

        scoreIndex.Reverse();

        // serialize
        string leaderboard = "";
        foreach (var item in scoreIndex)
            leaderboard += "n=" + item.name + "&s=" + item.score + "|";
        
        PlayerPrefs.SetString("leaderboard", leaderboard);
    }
}