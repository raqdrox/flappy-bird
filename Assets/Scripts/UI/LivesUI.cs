using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace flappybird
{
    public class LivesUI : MonoBehaviour
    {
        private Image[] LivesDisplay;
        [SerializeField] private int livesCounter = 3;

        private void Start()
        {
            LivesDisplay = GetComponentsInChildren<Image>();
        }

        private void FixedUpdate()
        {
            foreach (Image image in LivesDisplay)
            {
                image.gameObject.SetActive(false);
            }
            for (int i = 0; i < livesCounter; i++)
            {
                LivesDisplay[i].gameObject.SetActive(true);
            }
        }

        public void SetLives(int l)
        {
            livesCounter = l;
        }

        public void AddLives(int l)
        {
            livesCounter += l;
        }
    }
}