using I2.Loc;
using TMPro;
using UnityEngine;

namespace CIRC.Animals
{
    public class Dialog : MonoBehaviour
    {
        [field: SerializeField] public TMP_Text title { get; private set; }
        [field: SerializeField] public TMP_Text content { get; private set; }
        [field: SerializeField] public Localize localize { get; private set; }

        private AnimalData data;
        
        public void Initialize(AnimalData data, int dialogIndex)
        {
            this.data = data;
            title.text = data.animalName;
            content.text = data.animalDialogs[dialogIndex];
            
            localize.SetTerm(content.text);
            
            Invoke(nameof(EndDialog), data.dialogDuration);
        }

        public void EndDialog()
        {
            DialogsManager.Instance.RemoveDialog(this);
        }
    }
}