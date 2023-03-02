using UnityEngine;

public interface IGroundingChecker 
{
    //Raycasting
    
    float groundRayDistance { set; get; }

    Vector3 groundRayPosition { set; get; }

    LayerMask groundLayer { set; get; }

    Color rayColor { set; get; }

    bool GroundingByRaycast(Vector3 objectPosition);
}

