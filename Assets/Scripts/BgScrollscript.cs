using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flappybird
{
    public class BgScrollscript : MonoBehaviour
    {
        public float speed = 0.5f;
        public bool scroll = false;

        // Update is called once per frame
        void Update()
        {
            if (true)
            {
                Vector2 offset = new Vector2(Time.time * speed, 0);
                GetComponent<Renderer>().material.mainTextureOffset = offset;
            }
        }
    }
}