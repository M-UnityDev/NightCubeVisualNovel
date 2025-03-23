using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;
public class IntroDirector : MonoBehaviour
{
    private float alpha = 1;
    private double duration;
    [SerializeField] private VideoPlayer intro;
    private void Awake()
    {
        duration = intro.clip.frameCount/intro.playbackSpeed/intro.clip.frameRate;
        print(duration);
        DOTween.To(() => alpha, x => alpha = x, 0, 1).OnUpdate(() => {intro.targetCameraAlpha = alpha;}).SetDelay((float)duration).OnComplete(() => {Destroy(gameObject);}).SetEase(Ease.InOutCubic);
    }
}
