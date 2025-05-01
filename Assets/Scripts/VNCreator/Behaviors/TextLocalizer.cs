using UnityEngine;
using TMPro;
public class TextLocalizer : MonoBehaviour
{
    [SerializeField] private string TextEN;
    [SerializeField] private string TextRU;
    private void Awake() => CheckText();
    public void CheckText() => GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("Language",0).Equals(1) ? TextRU : TextEN;
}
