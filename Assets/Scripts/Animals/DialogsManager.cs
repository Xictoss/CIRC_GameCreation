using System.Collections.Generic;
using LTX.Singletons;
using UnityEngine;

namespace CIRC.Animals
{
    public class DialogsManager : MonoSingleton<DialogsManager>
    {
        [SerializeField] private Dialog dialogPrefab;
        private List<Dialog> currentDialogs = new List<Dialog>();

        public void SpawnDialog(AnimalData data, Vector3 position)
        {
            Dialog dialog = Instantiate(dialogPrefab, position + new Vector3(0, 2.75f, 0), Quaternion.identity);

            int index = Random.Range(0, data.animalDialogs.Length);
            dialog.Initialize(data, index);
            
            currentDialogs.Add(dialog);
        }

        public void RemoveDialog(Dialog dialog)
        {
            currentDialogs.Remove(dialog);
            Destroy(dialog.gameObject);
        }
    }
}