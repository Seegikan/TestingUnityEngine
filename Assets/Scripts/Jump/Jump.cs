using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _RigidBody;

    [SerializeField]
    private PlayerInput _playerInput;

    private IAirController _airController;
    private IGroundingChecker _groundingChecker;

    [SerializeField, Range(0f, 15f)]
    private float forceJump = 0f;

    [SerializeField]
    private UnityEvent Jumped;
    [SerializeField]
    private UnityEvent JumpStopped;

    [SerializeField]
    private UnityEvent<float> Fell;

    private IEnumerator jumpRoutine;

    public Jump()
    {
        Inject(new AirController());
        Inject(new GroundingChecker());

        _groundingChecker.groundRayPosition = Vector3.down * .2f;
        _groundingChecker.rayColor = Color.magenta;
        _groundingChecker.groundRayDistance = 0.1f;
    }

    public void Inject(IAirController airController) => _airController = airController;
    public void Inject(IGroundingChecker groundingChecker) => _groundingChecker = groundingChecker;

    private void Awake()
    {
        //implemnetacion de valores
       
        _groundingChecker.groundLayer = LayerMask.NameToLayer("Ground");


        jumpRoutine = JumpRoutine();

        _playerInput.actions["jump"].performed += _=>
        {
            _airController.IsGrounding = GroundingByRaycast;

            if (!_airController.Jumping && !_airController.IsGrounding)
            {
                Jumped.Invoke();
            }
        };
    }

    public void StartJumping()
    {
        AddImpulseVertical();
        _airController.Jumping = true;
        StartCoroutine(jumpRoutine);
    }

    private IEnumerator JumpRoutine()
    {
        while(true)
        {
            Fell.Invoke(_RigidBody.velocity.y);
            yield return null;
        }
    }

    public void AddImpulseVertical() => _RigidBody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
    public void StopJumping()
    {
        StopCoroutine(jumpRoutine);
        _airController.Jumping = false;
        _airController.IsFalling = false;
    }
    private bool GroundingByRaycast => Physics2D.Raycast(transform.position + _groundingChecker.groundRayPosition, Vector2.down, _groundingChecker.groundRayDistance, _groundingChecker.groundLayer);

    public void CheckGrounding(float velY)
    {
        if(GroundingByRaycast && velY == 0f)
        {
            JumpStopped.Invoke();
        }
    }

    public void ChechFalling(float velY) => _airController.IsFalling = !GroundingByRaycast && velY < 0f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _groundingChecker.rayColor;
        Gizmos.DrawRay(transform.position + _groundingChecker.groundRayPosition, Vector2.down * _groundingChecker.groundRayDistance);
    }
}
