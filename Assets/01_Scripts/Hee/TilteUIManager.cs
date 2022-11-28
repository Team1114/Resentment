using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TilteUIManager : MonoBehaviour
{
    [SerializeField] private float _moveTime = 2;
    private RectTransform _titleText;

    private void Awake()
    {
        _titleText = GetComponent<RectTransform>();
        MoveUD(50f);
    }

    private void MoveUD(float index)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_titleText.DOAnchorPosY(_titleText.anchoredPosition.y + index, _moveTime));
        seq.OnComplete(() =>
        {
            MoveUD(index * -1);
        });
    }
}
