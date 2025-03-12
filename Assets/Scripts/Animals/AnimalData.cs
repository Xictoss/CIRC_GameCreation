using UnityEngine;

namespace CIRC.Animals
{
    [CreateAssetMenu(menuName = "CIRC/Animals/Data", fileName = "NewAnimalData")]
    public class AnimalData : ScriptableObject
    {
        public string animalName;
        public string[] animalDialogs;

        public float dialogDuration;
        public float dialogCooldown;
    }
}