using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
public class IntroDirector : MonoBehaviour
{
    [SerializeField] private Sprite[] Sprites;
    private Image Image;
    private void Awake()
    {
        Image = GetComponent<Image>();
        StartCoroutine(nameof(Anim));
    }
    private IEnumerator Anim()
    {
        foreach (Sprite s in Sprites)
        {
            Image.sprite = s;
            yield return new WaitForSeconds(0.05f);
        }
        Image.DOColor(new Color(1, 1, 1, 0), 1);
    }
}
