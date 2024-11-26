using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.Core.MiniGames.Sample.RunAndDrink
{
    public class AnimalRun : MonoBehaviour, IPointerClickHandler
    {   
        [Header("Mouvement")]
        [SerializeField] private RectTransform centerPoint; 
        [SerializeField] private float rotationSpeed = 50f; 
        private float radius; 
        private float currentAngle = 90f;
        
        [Header("Detection")]
        [SerializeField] private RectTransform transformAnimal;
        [SerializeField] private RectTransform transformZone;
        private bool isClicked;
        private bool hitCoolDown;
        private float timer;

        public int RemainingDrinks { get; private set; } = 3;

        private void Start()
        {
            radius = Screen.currentResolution.width * 0.25f;
        }

        private void Update()
        {
            if (!isClicked)
            {
                currentAngle += rotationSpeed * Time.deltaTime;
                currentAngle %= 360f; 
            
                float angleRad = currentAngle * Mathf.Deg2Rad;
                float x = Mathf.Cos(angleRad) * radius;
                float y = Mathf.Sin(angleRad) * radius;
            
                transform.position = new Vector3(centerPoint.position.x + x, centerPoint.position.y + y, transform.position.z);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isClicked || hitCoolDown)return;
            
            Bounds bounds1 = RectTransformToScreenSpace(transformAnimal);
            Bounds bounds2 = RectTransformToScreenSpace(transformZone);
            
            if (bounds1.Intersects(bounds2))
            {
                isClicked = true;
                hitCoolDown = true;
                RemainingDrinks--;
                StartCoroutine(HitCoolDown());
                Debug.Log("Les images se chevauchent.");
            }
            else
            {
                Debug.Log("t'es naze");
            }
            
        }
        
        private static Bounds RectTransformToScreenSpace(RectTransform rectTransform)
        {
            Vector3[] corners = new Vector3[4];
            rectTransform.GetWorldCorners(corners);

            Vector3 position = (corners[0] + corners[2]) / 2;
            Vector3 size = corners[2] - corners[0];

            return new Bounds(position, size);
        }

        private IEnumerator HitCoolDown()
        {
            yield return new WaitForSeconds(1f);
            isClicked = false;
            yield return new WaitForSeconds(3f);
            hitCoolDown = false;
        }
    }
}