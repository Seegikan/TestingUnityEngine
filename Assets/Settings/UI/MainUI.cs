using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UIElements;

namespace UI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField]
        private UIDocument _IDocument;
        [SerializeField]
        private Label _lblScore;
        private IScore _score;

        private void Awake()
        {
            //_IDocument = GetComponent<UIDocument>();
            _lblScore = _IDocument.rootVisualElement.Q<Label>("lblScore"); //le damos la referencia de Jerarquia del UIDocument
            Inject(new Score());
        }

        public void Inject(IScore score) => _score = score;

        public void UpdateScore() => _lblScore.text = $"Score: {_score.ScorePoints}";

    }
}
