using System;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.RunAndDrink
{
    
    
    public class AnimalRun : MonoBehaviour
    {
        [SerializeField] private RectTransform centerPoint; 
        [SerializeField] private float radius = 100f; 
        [SerializeField] private float rotationSpeed = 50f; 
        
        public int RemainingDrinks { get; }
        
        private float currentAngle = 0f;

        private void Update()
        {
            currentAngle += rotationSpeed * Time.deltaTime;
            currentAngle %= 360f; 

           
            float angleRad = currentAngle * Mathf.Deg2Rad;
            float x = Mathf.Cos(angleRad) * radius;
            float y = Mathf.Sin(angleRad) * radius;
            
            transform.position = new Vector3(centerPoint.position.x + x, centerPoint.position.y + y, transform.position.z);
        }
    }
}