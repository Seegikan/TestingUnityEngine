using UnityEngine;

public class GroundingChecker : IGroundingChecker
{
    public float groundRayDistance { set; get; }

    public Vector3 groundRayPosition { set; get; }

    public LayerMask groundLayer { set; get; }

    public Color rayColor { set; get; }

    public bool GroundingByRaycast(Vector3 objectPosition) => Physics2D.Raycast(objectPosition + groundRayPosition, Vector2.down, groundRayDistance, groundLayer);
}

