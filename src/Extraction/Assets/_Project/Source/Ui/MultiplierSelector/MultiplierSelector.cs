using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public abstract class MultiplierSelector : MonoBehaviour
    {
        [SerializeField] private List<Button> _buttons;
        [SerializeField] private List<float> _multipliers = new List<float>();

        private int _activeIndex;
        private readonly Vector3 _defaultScale = new Vector3(.8f, .8f, 0);

        protected List<float> Multipliers => _multipliers;
        
        private const float AnimationDuration = .3f;

        private void Awake()
        {
            AddListeners();
        }

        protected virtual void SwitchMultiplier(int index)
        {
            UnselectButton(_activeIndex);
            SelectButton(index);

            _activeIndex = index;
        }

        private void AddListeners()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                int index = i;
                _buttons[i].onClick.AddListener(() => { SwitchMultiplier(index); });
            }
        }

        private void UnselectButton(int index)
        {
            _buttons[index].transform.DOScale(_defaultScale, AnimationDuration).SetEase(Ease.Linear);

            var highlightButton = _buttons[index].GetComponent<HighlightButton>();
            if(highlightButton)
                highlightButton.Deactivate();
        }

        private void SelectButton(int index)
        {
            _buttons[index].transform.DOScale(Vector3.one, AnimationDuration).SetEase(Ease.Linear);
            
            var highlightButton = _buttons[index].GetComponent<HighlightButton>();
            if(highlightButton)
                highlightButton.Activate();
        }
    }
}