using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace flappybird
{
    public class ScoreUI : MonoBehaviour
    {
        private int currScore;
        private int highScore;
        [SerializeField] private Text currScoretext;
        [SerializeField] private Text highScoretext;



        public void UpdateScore(int score)
        {

            currScore = score;
            currScoretext.text = score.ToString();
        }

        public void UpdateHighScore(int score)
        {
            if (score != -1)
                highScore = score;
            Debug.Log(score);
            highScoretext.text = highScore.ToString();
        }

        public int GetScore()
        {
            return currScore;
        }
        public void Add(int score)
        {
            currScore += score;
            currScoretext.text = currScore.ToString();
        }
    }
}