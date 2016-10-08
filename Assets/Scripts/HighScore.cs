using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class Score : IComparable<Score>
{
    public string name;
    public int score;
    public int rank;

    public int CompareTo(Score other)
    {
        return score.CompareTo(other.score);
    }
}

public class HandleScore
{
    public List<Score> GetScore()
    {
        List<Score> list = new List<Score>(5);

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
                        score = int.Parse(r[1].Substring(r[1].IndexOf('=') + 1, r[1].Length - (r[1].IndexOf('=') + 1))),
                        rank = int.Parse(r[2].Substring(r[2].IndexOf('=') + 1, r[2].Length - (r[2].IndexOf('=') + 1))),
                    });
                }
            }
        }

        return list;
    }

    public void AddScore(string name)
    {
        List<Score> scoreIndex = GetScore();

        scoreIndex.Add(new Score
        {
            name = name,
            score = ConfigurationScript.score
        });

        scoreIndex = scoreIndex.OrderByDescending(x => x.score).ToList();

        // serialize
        string leaderboard = "";
        for (int i = 0; i < scoreIndex.Count && i < 5; i++)
        {
            leaderboard += "n=" + scoreIndex[i].name + "&s=" + scoreIndex[i].score + "&i=" + i + "|";
        }

        PlayerPrefs.SetString("leaderboard", leaderboard);
    }
}