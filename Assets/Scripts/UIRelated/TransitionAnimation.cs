using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using LTX.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CIRC.UIRelated
{
    public class TransitionAnimation : MonoBehaviour
    {
        [SerializeField] private Transform target;
        
        [Header("Clouds")]
        [SerializeField] private int cloudNumber;
        // How far to move clouds in the horizontal direction
        [SerializeField] private float moveDistance = 100f;
        // Duration will be randomized between these values (in seconds)
        [SerializeField] private float minDuration = 20f;
        [SerializeField] private float maxDuration = 40f;
        // Vertical offset range for some randomness in height
        [SerializeField] private float verticalOffsetRange = 1f;
        [SerializeField] private Transform begin, middle, finish;
        [SerializeField] private Transform cloudPrefab;

        private List<Transform> clouds;
        private DynamicBuffer<Transform> cloudsBuffer;
        
        private IEnumerator Start()
        {
            clouds = new List<Transform>();
            cloudsBuffer = new DynamicBuffer<Transform>(64);
            
            MovePlanet();
            
            for (int i = 0; i < cloudNumber; i++)
            {
                SpawnCloud(true);
            }

            while (true)
            {
                SpawnCloud(false);
                yield return new WaitForSeconds(0.75f);
            }
        }

        private void Update()
        {
            cloudsBuffer.Clear();
            cloudsBuffer.CopyFrom(clouds);
            
            for (int i = 0; i < cloudsBuffer.Length; i++)
            {
                if (cloudsBuffer[i] == null) continue;
                if (cloudsBuffer[i].localPosition.x >= finish.localPosition.x)
                {
                    clouds.RemoveAt(i);
                    Destroy(cloudsBuffer[i].gameObject);
                }
            }
        }

        private void SpawnCloud(bool isStart)
        {
            Transform newCloud = Instantiate(cloudPrefab, isStart ? middle : begin);
            
            Vector3 pos;
            if (isStart)
            {
                pos = new Vector3(Random.Range(-1200, 1200), Random.Range(-800, 800), 0);
                newCloud.localPosition += pos;
            }
            else
            {
                pos = new Vector3(middle.localPosition.x, Random.Range(-800, 800), 0);
                newCloud.localPosition = pos;
            }
            
            clouds.Add(newCloud);
            
            MoveCloud(newCloud);
        }

        private void MoveCloud(Transform cloud)
        {
            // Randomize the duration and vertical offset
            float duration = Random.Range(minDuration, maxDuration);
            float yOffset = Random.Range(-verticalOffsetRange, verticalOffsetRange);

            // Calculate a destination position with a random vertical offset
            Vector3 destination = cloud.position + new Vector3(moveDistance, yOffset, 0);

            // Animate the cloud movement
            cloud.DOMove(destination, duration)
                .SetEase(Ease.Linear);
        }

        private void MovePlanet()
        {
            target.rotation = Quaternion.Euler(0, 0, Random.Range(0, -360));
            target.DORotate(new Vector3(0, 0, 360), 25, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}