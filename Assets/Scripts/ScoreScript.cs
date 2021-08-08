using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace flappybird
{
    public class ScoreScript : MonoBehaviour
    {
        private FlappyGameController controller;
        private void OnTriggerEnter(Collider pipe)
        {
            controller.ScoreAdd();
        }

        public void initGameObj(FlappyGameController a)
        {
            controller = a;
        }

    }
}