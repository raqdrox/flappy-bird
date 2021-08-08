using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace flappybird
{
    public class UIHandler : MonoBehaviour
    {

        [SerializeField] private LivesUI livesUI;
        [SerializeField] private StartButton startButton;
        [SerializeField] private ScoreUI scoreUI;
        [SerializeField] private Text gameOver;

        public void SetScore(int score = 0)
        {
            scoreUI.UpdateScore(score);
        }
        public void SetHighScore(int score = 0)
        {
            scoreUI.UpdateHighScore(score);
        }



        public void AddScore(int i = 1)
        {
            scoreUI.Add(i);
        }

        public void SetLives(int i = 3)
        {
            livesUI.SetLives(i);
        }

        public void AddLives(int i = -1)
        {
            livesUI.AddLives(i);
        }
        public void ResetButton()
        {
            startButton.gameObject.SetActive(true);
        }
        public void SetButton()
        {
            startButton.gameObject.SetActive(false);
        }

        public void DisplayEndScreen()
        {
            gameOver.gameObject.SetActive(true);
            SetScore(scoreUI.GetScore());
            SetHighScore(-1);
            ResetButton();
        }
        public void RemoveStartScreen()
        {
            gameOver.gameObject.SetActive(false);
            SetButton();
            SetScore();
            SetLives();
        }
    }
}