using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using System.Linq;

public class Scoring : MonoBehaviour
{
    public class HighScore: IComparable<HighScore>
    {
        public int score { get; set; }
        public string person { get; set; }
        public int CompareTo(HighScore other)
        {
            return score.CompareTo(other.score);
        }
    }

    
    public List<HighScore> highScore = new List<HighScore>();
    public PlayerMove player;
    public GameObject highScorePanel;
    public GameObject highScoreSubmitPanel;
    public GameObject startPanel;
    public Text[] highScoreResultText = new Text[10];
    public InputField highScoreName;
    public Text highScoreNumberText;

    // Start is called before the first frame update
    void Awake()
    {
        highScorePanel.SetActive(false);
        highScoreSubmitPanel.SetActive(false);
        player = FindObjectOfType<PlayerMove>();
        if (highScore.Count == 0)
        {
            StreamReader readScore = new StreamReader("Resources/HighScore.txt");
            StreamReader readName = new StreamReader("Resources/HighScoreName.txt");
            int reverse = 9;
            for (int i = 0; i < 10; i++)
            {
                highScore.Add(new HighScore { score = int.Parse(readScore.ReadLine()), person = readName.ReadLine() });
                highScoreResultText[reverse].text = highScore[i].person + ": " + highScore[i].score.ToString();
                reverse--;
            }
        }
    }

    void GetHighScore()
    {
        StreamReader readScore = new StreamReader("Resources/HighScore.txt");
        StreamReader readName = new StreamReader("Resources/HighScoreName.txt");
        for (int i = 0; i < 10; i++)
        {
            highScore.Add(new HighScore { score = int.Parse(readScore.ReadLine()), person = readName.ReadLine() });
        }
    }

    public void CheckHighScore()
    {
        if (player.points > highScore[0].score)
        {
            highScoreNumberText.text = "you scored " + player.points + " points!";
            highScoreSubmitPanel.SetActive(true);
        }
        else
            highScorePanel.SetActive(true);
    }


    public void OnHighScoreSumbitButtonClick()
    {
        highScore.Add(new HighScore { score = player.points, person = highScoreName.text});
        highScore.Sort();
        highScore.Remove(highScore[0]);
        StreamWriter writeScore = new StreamWriter("./Resources/HighScore.txt", false);
        StreamWriter writeName = new StreamWriter("./Resources/HighScoreName.txt", false);
        for (int i = 0; i < highScore.Count; i++)
        {
            writeScore.WriteLine(highScore[i].score);
            writeName.WriteLine(highScore[i].person);
        }
        writeScore.Close();
        writeName.Close();
        int reverse = 9;
        for (int i = 0; i < highScore.Count; i++)
        {
            highScoreResultText[i].text = highScore[reverse].person + ": " + highScore[reverse].score;
            reverse--;
        }
        highScoreSubmitPanel.SetActive(false);
        highScorePanel.SetActive(true);
    }

    public void OnHighScoreButtonClick()
    {
        highScorePanel.SetActive(true);
    }

    public void OnHighScoreCloseButtonClick()
    {
        highScorePanel.SetActive(false);
        if(startPanel == false)
        {
            startPanel.SetActive(true);
        }
    }


}
