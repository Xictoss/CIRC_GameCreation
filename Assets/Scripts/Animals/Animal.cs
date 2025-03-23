using System.Collections;
using UnityEngine;

namespace CIRC.Animals
{
    public class Animal : MonoBehaviour
    {
        [field : SerializeField] public AnimalData AnimalData { get; private set; }

        private IEnumerator Start()
        {
            GetComponent<SpriteRenderer>().sprite = AnimalData.animalSprite;
            
            while (true)
            {
                yield return new WaitForSeconds(AnimalData.dialogCooldown + AnimalData.dialogDuration + Random.Range(-2f, 2f));
                
                DialogsManager.Instance.SpawnDialog(AnimalData, transform.position);
            }
        }
    }
}