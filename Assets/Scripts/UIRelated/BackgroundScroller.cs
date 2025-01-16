using UnityEngine;
using UnityEngine.UI;

namespace CIRC.UIRelated
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] private RawImage _img;
        [SerializeField] private float _x, _y;
        
        void Update()
        {
            _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x*0.1f, _y*0.1f) * Time.deltaTime, _img.uvRect.size);
        }
    }
}