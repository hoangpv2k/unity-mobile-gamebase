using PrimeTween;
using UnityEngine;

public class EffectZoomInOut : MonoBehaviour
{
    public Vector3 currentScale;
    [Range(0,2f)]public float timeDelay;
    [Range(.1f,2f)]public float sizeScale = .1f;
    [Range(0,2f)]public float timeScale = .7f;
    public void Awake()
    {
        currentScale = transform.localScale;
    }

    public void OnEnable()
    {
        transform.localScale = currentScale;
        DoEffect(sizeScale,false);
    }
    
    public void DoEffect(float sizeScale, bool delay)
    {
        if (!gameObject.activeInHierarchy) return;
        Sequence.Create().ChainDelay(timeDelay*(delay ? 1 : 0)).ChainCallback(() =>
        {
            Tween.Scale(transform,new Vector3(transform.localScale.x + sizeScale, transform.localScale.y + sizeScale,
                    transform.localScale.z),
                timeScale, Ease.Linear).OnComplete(() =>
            {
                DoEffect(-sizeScale,!delay);
            });
        });
    }
}