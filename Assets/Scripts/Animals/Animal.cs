using System.Collections;
using UnityEngine;

namespace CIRC.Animals
{
    public class Animal : MonoBehaviour
    {
        [field : SerializeField] public AnimalData AnimalData { get; private set; }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(AnimalData.dialogCooldown + AnimalData.dialogDuration);
                
                DialogsManager.Instance.SpawnDialog(AnimalData, transform.position);
            }
        }
    }
}