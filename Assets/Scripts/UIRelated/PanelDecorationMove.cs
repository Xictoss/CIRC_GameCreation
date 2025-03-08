using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace CIRC.UIRelated
{
    public class PanelDecorationMove : MonoBehaviour
    {
        [SerializeField] private Transform[] plants;
        [SerializeField] private float rotationDuration = 2f;
        [SerializeField] private float rotationAngle = 10f;
    
        // Optional: For a subtle horizontal sway
        [SerializeField] private float swayDuration = 3f;
        [SerializeField] private float swayDistance = 0.5f;

        private IEnumerator Start()
        {
            for (int index = 0; index < plants.Length; index++)
            {
                Transform plant = plants[index];
                
                float randomAdd = Random.Range(-0.25f, 0.25f);
                
                // Smooth rotation tween for wind effect
                plant.DOLocalRotate(new Vector3(0, 0, rotationAngle + randomAdd), rotationDuration + randomAdd)
                    .SetEase(Ease.InOutSine)
                    .SetLoops(-1, LoopType.Yoyo);

                // Optional: smooth horizontal movement for extra effect
                plant.DOLocalMoveX(plant.localPosition.x + swayDistance + randomAdd, swayDuration + randomAdd)
                    .SetEase(Ease.InOutSine)
                    .SetLoops(-1, LoopType.Yoyo);

                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
            }
        }
    }
}