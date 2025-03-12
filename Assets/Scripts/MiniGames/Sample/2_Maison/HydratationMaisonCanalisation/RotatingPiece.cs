using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class RotatingPiece : MonoBehaviour, IPointerClickHandler
    {
        [Header("PieceState")]
        [field: SerializeField] public PieceState PieceState { get; private set; }
        [field: SerializeField] public PieceState WantedState { get; private set; }
        private int logicalIndex;
        
        [Header("Rect")]
        [SerializeField] private RectTransform rt;
        
        [Header("Cooldown")]
        [SerializeField] private float turnCooldown;
        private bool canTurn = true;

        private void Start()
        {
            logicalIndex = GetIndexFromPieceState(PieceState);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!canTurn) return;
            
            CalculateState();
            RotatePiece();
        }
        
        private void CalculateState()
        {
            logicalIndex = (logicalIndex + 1) % 4; // Cycle through 0 to 3
        }

        private PieceState GetPieceStateFromIndex(int index)
        {
            switch (index)
            {
                case 0: return PieceState.up;
                case 1: return PieceState.right;
                case 2: return PieceState.down;
                case 3: return PieceState.left;
                
                default: return PieceState.up;
            }
        }
        
        private int GetIndexFromPieceState(PieceState pieceState)
        {
            switch (pieceState)
            {
                case PieceState.up: return 0;
                case PieceState.right: return 1;
                case PieceState.down: return 2;
                case PieceState.left: return 3;
                
                default: return 0;
            }
        }

        private void RotatePiece()
        {
            canTurn = false;
            float targetRotation = rt.rotation.eulerAngles.z - 90f;
            
            Sequence rotationSequence = DOTween.Sequence();
            rotationSequence.Append(rt.DORotate(new Vector3(0, 0, Mathf.FloorToInt(targetRotation)), turnCooldown))
                            .OnComplete(() =>
                            {
                                PieceState = GetPieceStateFromIndex(logicalIndex);
                                canTurn = true;
                            });
            rotationSequence.Play();
        }
    }

    [Flags]
    public enum PieceState
    {
        up = 1 << 0,    // 1
        right = 1 << 1, // 2
        down = 1 << 2,  // 4
        left = 1 << 3,  // 8
        
        Horizontal = right | left,
        Vertical = up | down
    }

    public static class PieceStateExtensions
    {
        public static bool HasFlagFast(this PieceState value, PieceState flag)
        {
            return (value & flag) != 0;
        }
    }
}