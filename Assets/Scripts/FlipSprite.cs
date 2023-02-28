using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipSprite : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    //public void Flip(Vector2 direction) => _spriteRenderer.flipX = direction.x > 0f ? false : direction.x < 0f ? true : _spriteRenderer.flipX;
    public void Flip(InputAction.CallbackContext ctx) => _spriteRenderer.flipX = ctx.ReadValue<Vector2>().x > 0f ? false : ctx.ReadValue<Vector2>().x < 0f ? true : _spriteRenderer.flipX;

}
