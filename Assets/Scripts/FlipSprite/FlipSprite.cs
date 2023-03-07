using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FlipSprite
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class FlipSprite : MonoBehaviour
    {
        [SerializeReference]
        private ISpriteController _spriteController;

        public FlipSprite()
        {
            Injet(new SpriteController());
        }

        private void Awake()
        {
            _spriteController.SprRenderer = GetComponent<SpriteRenderer>();
        }

        public void Injet(ISpriteController spriteController) => _spriteController = spriteController;  

        //public void Flip(Vector2 direction) => _spriteRenderer.flipX = direction.x > 0f ? false : direction.x < 0f ? true : _spriteRenderer.flipX;
        //public void Flip(InputAction.CallbackContext ctx) => _spriteRenderer.flipX = ctx.ReadValue<Vector2>().x > 0f ? false : ctx.ReadValue<Vector2>().x < 0f ? true : _spriteRenderer.flipX;

    }
}

