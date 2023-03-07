using UnityEngine;

namespace FlipSprite

{
    public interface ISpriteController
    {
        [SerializeField]
        public SpriteRenderer SprRenderer { get; set; }
        public bool IsFlippedOnX { get; set; }


        //public void FlipX(InputAction.CallbackContext ctx);
        //public void FlipX(bool flip);
    }
}
