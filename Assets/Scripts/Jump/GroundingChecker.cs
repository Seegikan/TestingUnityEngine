using UnityEngine;
using System;

namespace Jomp
{
    [Serializable]
    public class GroundingChecker : IGroundingChecker
    {
        [SerializeField, Range(0f, 5f)]
        private float _groundRayDistance;
        [SerializeField]
        private Vector3 _groundRayPosition;
        [SerializeField]
        private LayerMask _groundLayer;
        [SerializeField]
        private Color _rayColor;
        public float groundRayDistance {  get => _groundRayDistance; set => _groundRayDistance = value; }

        public Vector3 groundRayPosition { get => _groundRayPosition; set => _groundRayPosition = value; }

        public LayerMask groundLayer { get => _groundLayer; set => _groundLayer = value; }

        public Color rayColor { get => _rayColor; set => _rayColor = value; }

        public bool GroundingByRaycast(Vector3 objectPosition) => Physics2D.Raycast(objectPosition + groundRayPosition, Vector2.down, groundRayDistance, groundLayer);
    }
}

