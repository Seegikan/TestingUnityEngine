using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace FlipSprite 
{
    [Serializable]
    public class SpriteController : ISpriteController
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        public SpriteRenderer SprRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
        public bool IsFlippedOnX { get => SprRenderer.flipX; set => SprRenderer.flipX = value; } 


        //public void Flip(bool flip) => 
        //public void Flip(InputAction.CallbackContext ctx) => _spriteRenderer.flipX = ctx.ReadValue<Vector2>().x > 0f ? false : ctx.ReadValue<Vector2>().x < 0f ? true : _spriteRenderer.flipX;
    }
}
