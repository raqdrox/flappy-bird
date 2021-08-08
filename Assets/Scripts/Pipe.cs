using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace flappybird
{
    public class Pipe : MonoBehaviour
    {
        public bool isMoving = false;
        public float pipeSpeed = 1f;


        public void StartMoving()
        {
            isMoving = true;
        }

        private void MovePipe()
        {
            transform.position += new Vector3(-1, 0, 0) * pipeSpeed * Time.deltaTime;
        }

        private void Update()
        {
            if (isMoving)
                MovePipe();
        }
    }
}