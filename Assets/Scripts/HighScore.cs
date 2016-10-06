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

    public List<Score> GetScore()
    {
        List<Score> list = new List<Score>();

        if (PlayerPrefs.GetString("leaderboard") != "")
        {
            var arrRanking = PlayerPrefs.GetString("leaderboard").Split('|');

            foreach (var item in arrRanking)
            {
                if (item != "")
                {
                    var r = item.Split('&');

                    list.Add(new Score
                    {
                        name = r[0].Substring(r[0].IndexOf('=') + 1, r[0].Length - (r[0].IndexOf('=') + 1)),
                        score = int.Parse(r[1].Substring(r[1].IndexOf('=') + 1, r[1].Length - (r[1].IndexOf('=') + 1)))
                    });
                }
            }
        }

        return list;
    }

    public void AddScore(string name)
    {
        scoreIndex = GetScore();

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