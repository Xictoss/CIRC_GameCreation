using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.Core.MiniGames.Sample.Core.MiniGames.Sample.PipePuzzle
{
    public class RotatingPiece : MonoBehaviour, IPointerClickHandler
    {
        [field : SerializeField] public PieceState PieceState { get; private set; }
        [field : SerializeField] public PieceState WantedState { get; private set; }
        [SerializeField] private RectTransform rt;
        [SerializeField] private float turnCooldown;

        private int stateIndex;
        
        private bool canTurn;
        private float  currentTimer;

        private void Update()
        {
            if (!canTurn)
            {
                currentTimer += Time.deltaTime;
                if (currentTimer >= turnCooldown)
                {
                    currentTimer = 0;
                    canTurn = true;
                    Debug.Log($"{(PieceState)(1 << stateIndex)} => {PieceState}");
                    PieceState = (PieceState)(1 << stateIndex);
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!canTurn) return;
            
            CalculateState();
            RotatePiece();
        }
        
        public void CalculateState()
        {
            stateIndex = (int)PieceState;
            stateIndex++;
            if (stateIndex == 5) stateIndex = 1;
        }

        private void RotatePiece()
        {
            rt.DORotate(new Vector3(0, 0, rt.rotation.z + 90f * stateIndex), turnCooldown);
            canTurn = false;
        }
    }

    [Flags]
    public enum PieceState
    {
        up = 1,
        left = 2,
        down = 3,
        right = 4,
        
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