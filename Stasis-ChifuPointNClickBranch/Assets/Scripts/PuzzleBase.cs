using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class PuzzleBase : MonoBehaviour
{
    [SerializeField] private Image _blackPanel;
    [SerializeField] private Image _PuzzlePanel;
    private void OnEnable()
    {
        _blackPanel.DOFade(0.7f, 1).From(0);
        _PuzzlePanel.transform.DOScale(Vector3.one, 1).SetEase(Ease.OutExpo).From(Vector3.zero);
    }
    public void Exit()
    {
        Sequence exitSequence = DOTween.Sequence();
        exitSequence
            .Join(_blackPanel.DOFade(0, 1).From(0.7f))
            .Join(_PuzzlePanel.transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutExpo).From(Vector3.one));

        exitSequence.OnComplete(() =>
        {
            this.gameObject.SetActive(false);
        });
    }
}
