using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using DG.Tweening;

namespace TestProject.General
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _displayText;
        [SerializeField] private Button[] _numberButtons;
        [SerializeField] private Button _refreshButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Ease _animationEaseButton = Ease.OutBack;

        private const float DURATION_ANIM_BTN = 0.2f;

        public void SetDisplayText(string text)
        {
            _displayText.text = text;
        }

        public void AddButtonListeners(Action<int> onNumberButtonClick, Action onRefreshButtonClick, Action onExitClick)
        {
            for (int i = 0; i < _numberButtons.Length; i++)
            {
                int temp = i;
                _numberButtons[temp].onClick.AddListener(() => {
                    AnimationButton(_numberButtons[temp], onNumberButtonClick, temp);
                });
            }

            _refreshButton.onClick.AddListener(() => {
                AnimationButton(_refreshButton, onRefreshButtonClick);
            });

            _exitButton.onClick.AddListener(() => {

                AnimationButton(_exitButton, onExitClick);
            });
        }

        private void AnimationButton(Button button, Action callback)
        {
            AnimateScale(button, callback);
        }

        private void AnimationButton<T>(Button button, Action<T> callback, T parameter)
        {
            AnimateScale(button, () => callback(parameter));
        }

        private void AnimateScale(Button button, Action onComplete)
        {
            button.transform.DOScale(Vector3.one * .7f, DURATION_ANIM_BTN).SetEase(_animationEaseButton)
                .OnComplete(() =>
                    button.transform.DOScale(Vector3.one, DURATION_ANIM_BTN).SetEase(_animationEaseButton).OnComplete(() => onComplete.Invoke()));
        }
    }
}