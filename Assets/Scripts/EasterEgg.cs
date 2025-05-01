using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Game.Input;
public class EasterEgg : MonoBehaviour
{
    [SerializeField] private Image BackGround;
    [SerializeField] private Sprite[] AnimationSprites;
    private void Start() => StartCoroutine(nameof(EasterPegg));
    private IEnumerator EasterPegg()
    {
        yield return new WaitUntil(() => InputHandler.Inputs.UI.EasterEgg1.WasReleasedThisFrame());
        foreach (Sprite s in AnimationSprites)
        {
            BackGround.sprite = s;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
