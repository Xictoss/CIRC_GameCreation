using UnityEngine;
using UnityEngine.UI;

namespace CIRC.UIRelated
{
    public class AlphaThreshold : MonoBehaviour
    {
        [SerializeField] private float alphaThreshold = 0.1f; // Ignore very low transparency

        private void Awake()
        {
            Image img = GetComponent<Image>();
            if (img != null && img.sprite != null)
            {
                img.alphaHitTestMinimumThreshold = alphaThreshold;
            }
        }
    }
}