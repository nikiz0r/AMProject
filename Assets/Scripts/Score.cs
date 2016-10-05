using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

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

    private void GetScore()
    {
        if (PlayerPrefs.GetString("leaderboard") != "")
        {
            var arrRanking = PlayerPrefs.GetString("leaderboard").Split('|');

            foreach (var item in arrRanking)
            {
                var r = item.Split('&');

                scoreIndex.Add(new Score
                {
                    name = r[0],
                    score = int.Parse(r[1])
                });
            }
        }
    }

    public void AddScore(string name)
    {
        GetScore();

        scoreIndex.Add(new Score
        {
            name = name,
            score = ConfigurationScript.score
        });

        scoreIndex.Sort();

        // serialize
        string leaderboard = "";
        foreach (var item in scoreIndex)
            leaderboard += "n=" + item.name + "&s=" + item.score + "|";
        
        PlayerPrefs.SetString("leaderboard", leaderboard);
    }
}