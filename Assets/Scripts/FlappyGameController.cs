using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace flappybird
{
    [RequireComponent(typeof(PipeSpawnerScript))]
    [RequireComponent(typeof(AudioSource))]
    public class FlappyGameController : MonoBehaviour
    {
        private PlayerMovementScript playerObj;
        private PipeSpawnerScript pipeSpawner;
        [SerializeField] private Transform SpawnContainer;
        public GameObject playerPrefab;
        public Transform playerSpawnPoint;
        public ScoreScript scorer;
        public BgScrollscript bg1;
        public BgScrollscript bg2;
        public bool inProgress = false;
        [SerializeField] private UIHandler uiHandler;
        public AudioClip failAudio;
        public AudioClip gameoverAudio;
        public AudioSource audSrc;

        public int Score;
        public int highScore = 0;

        public int Lives = 2;

        public void ScoreAdd()
        {
            Score++;
            uiHandler.AddScore();
        }

        private void Awake()
        {
            highScore = PlayerPrefs.GetInt("highscore", 0);
            gameoverAudio = Resources.Load<AudioClip>("gameover");
            failAudio = Resources.Load<AudioClip>("fail");
            audSrc = GetComponent<AudioSource>();
            pipeSpawner = GetComponent<PipeSpawnerScript>();

        }


        public void SpawnPlayer()
        {
            playerObj = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity).GetComponent<PlayerMovementScript>();
        }

        private void Start()
        {
            SpawnPlayer();
            playerObj.StartPlayer(this);
            scorer.initGameObj(this);
        }

        private void ResetStage()
        {
            pipeSpawner.initPipeSpawning(playerObj.gameObject.transform);
            playerObj.transform.position = playerSpawnPoint.position;
            playerObj.enableMovement(false);

        }


        public void PlayerReady(bool status)
        {

            if (status)
            {
                pipeSpawner.spawn = true;

                bg1.scroll = true;
                bg2.scroll = true;
            }
            else
            {
                pipeSpawner.spawn = false;
                bg1.scroll = false;
                bg2.scroll = false;
            }
        }
        public void StartGame()
        {
            Lives = 3;
            uiHandler.RemoveStartScreen();
            Score = 0;
            ResetStage();
            PlayerReady(false);
            inProgress = true;
            playerObj.haultcounter = 0;
        }

        private void ContainerDestroyer()
        {
            foreach (Transform child in SpawnContainer)
            {
                Destroy(child.gameObject);
            }
        }

        public void CheckScore()
        {
            if (Score != 0 && Score > highScore)
            {
                highScore = Score;
                uiHandler.SetHighScore(highScore);
                PlayerPrefs.SetInt("highscore", highScore);
                PlayerPrefs.Save();
            }
        }
        public void EndGame()
        {
            if (Lives == 0)
            {
                audSrc.PlayOneShot(gameoverAudio);
                CheckScore();
                pipeSpawner.spawn = false;
                inProgress = false;
                ContainerDestroyer();
                uiHandler.DisplayEndScreen();
                ResetStage();
                PlayerReady(false);
                playerObj.transform.position = playerSpawnPoint.position;
            }
            else
            {
                audSrc.PlayOneShot(failAudio);
                Lives--;
                uiHandler.AddLives(-1);
                PlayerReady(false);
                playerObj.haultcounter = 0;
                ContainerDestroyer();
                ResetStage();

            }
        }
    }
}