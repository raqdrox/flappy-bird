using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace flappybird
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerMovementScript : MonoBehaviour
    {
        public float flyvelocity = 200f;
        private Rigidbody body;
        public (float, float) constraintYAxis = (0.7f, -10.65f);
        private FlappyGameController gameController;
        public bool AllowMovement = false;
        public AudioClip jumpAudio;
        public AudioSource audSrc;

        public bool Haulted = true;
        public int haultcounter = 0;

        private void Awake()
        {
            jumpAudio = Resources.Load<AudioClip>("jump");
            audSrc = GetComponent<AudioSource>();
            body = GetComponent<Rigidbody>();
            body.useGravity = false;
        }

        private void OnTriggerEnter(Collider pipe)
        {
            if (pipe.gameObject.GetComponents<Pipe>() == null)
            {
                Physics.IgnoreCollision(pipe, GetComponent<Collider>());
            }
            else
            {
                body.velocity = Vector2.zero;
                gameController.EndGame();
            }
        }

        public void StartPlayer(FlappyGameController a)
        {
            gameController = a;
        }

        private void Update()
        {
            if (AllowMovement)
            {

                if (Input.GetKeyDown("space")|| Input.GetMouseButtonDown(0))
                {
                    audSrc.PlayOneShot(jumpAudio);
                    body.velocity = Vector2.zero;
                    body.AddForce(new Vector2(0, flyvelocity));
                }
                if (transform.position.y > constraintYAxis.Item1)
                {
                    Vector3 pos = transform.position;
                    pos.y = constraintYAxis.Item1;
                    transform.position = pos;
                }
                if (transform.position.y <= constraintYAxis.Item2)
                {
                    Debug.Log("endgame");
                    gameController.EndGame();
                }
            }
            else
            {
                if ((Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)) && gameController.inProgress && !Haulted)
                {
                    haultcounter = 0;
                    audSrc.PlayOneShot(jumpAudio);
                    enableMovement(true);
                    gameController.PlayerReady(true);
                }
                else if (haultcounter % 180 == 0f)
                {
                    Haulted = false;
                }
                else
                {
                    haultcounter++;
                }

            }




        }

        public void enableMovement(bool a)
        {
            if (a)
            {
                AllowMovement = true;
                body.useGravity = true;

            }
            else
            {
                AllowMovement = false;
                body.useGravity = false;

            }

        }
    }
}
