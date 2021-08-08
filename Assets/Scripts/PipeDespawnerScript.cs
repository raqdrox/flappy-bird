using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace flappybird
{
    public class PipeDespawnerScript : MonoBehaviour
    {

        private void OnTriggerEnter(Collider pipe)
        {
            Destroy(pipe.gameObject);
        }
    }
}