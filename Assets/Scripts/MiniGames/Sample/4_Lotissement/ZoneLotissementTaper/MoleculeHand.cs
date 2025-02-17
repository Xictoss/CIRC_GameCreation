using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class MoleculeHand : MonoBehaviour, IPointerClickHandler
    {
        
        public void OnPointerClick(PointerEventData eventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            Debug.Log(results.Count);
            
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.CompareTag("MiniGameZone1"))
                {
                    MoleculeManager.Instance.ChangeRemainingMolecules();
                    Death(result.gameObject);
                }

                if (result.gameObject.CompareTag("MiniGameZone2"))
                {
                    result.gameObject.transform.DOShakePosition(1, 10f, 300);
                }
            }
        }

        private void Death(GameObject gtd)
        {
            Destroy(gtd);
            //TODO PLAY VFX
        }
    }
}