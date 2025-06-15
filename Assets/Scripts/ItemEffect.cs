using UnityEngine;
using DG.Tweening;

public class ItemEffect : MonoBehaviour
{
    public Transform shadowTransform;
    public float floatDistance = 10f;
    public float floatDuration = 1.5f;
    public float shadowMinScale = 0.7f;
    public float shadowMaxScale = 1.0f;
    public Ease floatEase = Ease.InOutSine;

    private Vector3 originalItemPos;
    private Vector3 originalShadowScale;

    void Start()
    {
        originalItemPos = transform.localPosition;
        originalShadowScale = shadowTransform.localScale;

        transform.DOLocalMoveY(originalItemPos.y + floatDistance, floatDuration)
            .SetEase(floatEase)
            .SetLoops(-1, LoopType.Yoyo);

        shadowTransform.DOScale(originalShadowScale * shadowMinScale, floatDuration)
            .SetEase(floatEase)
            .SetLoops(-1, LoopType.Yoyo);
    }

    void OnDisable()
    {
        transform.DOKill();
        shadowTransform.DOKill();
    }
}
