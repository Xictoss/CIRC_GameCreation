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

        public int RemainingDrinks { get; private set; }

        private void Start()
        {
            RemainingDrinks = GameController.Metrics.RunAndDrink_DrinksNumber;
            
            radius = Screen.currentResolution.width * 0.3f;
            transformZone.position += Vector3.down * radius;
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
            
            Bounds bounds1 = transformAnimal.RectTransformToScreenSpace();
            Bounds bounds2 = transformZone.RectTransformToScreenSpace();
            
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
        
        

        private IEnumerator HitCoolDown()
        {
            yield return new WaitForSeconds(1f);
            isClicked = false;
            yield return new WaitForSeconds(3f);
            hitCoolDown = false;
        }
    }
}