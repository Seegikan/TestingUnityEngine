using UnityEngine;
using UnityEngine.Events;
using DefaultNamespace;

namespace Collectable
{
    public class Coin : MonoBehaviour, ICollectable<int>
    {
        [SerializeField]
        public int _value;

        [SerializeField]
        private UnityEvent<int> OnCollected;

        public int Value => _value;
        public void Collect()
        {
            GameManager.Instance.Score.AddPoints(Value);
            GameManager.Instance.GetMainUI.UpdateScore();
            Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //if(!collision.com)
        }
    }
}