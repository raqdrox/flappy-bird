using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace flappybird
{
    public class PipeSpawnerScript : MonoBehaviour
    {
        private Transform playerTransform;
        [SerializeField] private GameObject pipePrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform SpawnContainer;

        [SerializeField] public (float, float) constraintYAxis = (2.35f, -10.65f);
        public float maxOffset = 2f;

        public bool spawn = false;
        private int spawnCycle = 0;
        public int spawnRate = 180;

        public void initPipeSpawning(Transform player)
        {
            playerTransform = player;
        }

        private Vector3 CalculateCoords()
        {
            Vector3 position = spawnPoint.position;
            float upperDiff = constraintYAxis.Item2 - playerTransform.position.y;
            float lowerDiff = playerTransform.position.y - constraintYAxis.Item1;
            if (upperDiff < lowerDiff && upperDiff < maxOffset)
            {
                float randomY = Random.Range(-maxOffset, 0f);
                position.y += randomY;
                return position;
            }
            else if (lowerDiff < upperDiff && lowerDiff < maxOffset)
            {
                float randomY = Random.Range(0f, maxOffset);
                position.y += randomY;
                return position;
            }
            else
            {
                float randomY = Random.Range(-maxOffset, maxOffset);
                position.y += randomY;
                return position;
            }
        }

        private GameObject SpawnPipe(Vector3 position)
        {
            GameObject pipe = Instantiate(pipePrefab, position, Quaternion.identity, SpawnContainer);
            pipe.GetComponent<Pipe>().StartMoving();
            return pipe;
        }

        private void FixedUpdate()
        {
            if (spawn && spawnCycle % spawnRate == 0f)
            {

                SpawnPipe(CalculateCoords());
                spawnCycle = 0;
            }
            spawnCycle++;
        }
    }
}