using UnityEngine;
using TMPro;
using System;
[Serializable]
public struct TextLocale
{
    public TMP_Text TextToLocalize;
    public string TextEN;
    public string TextRU;
}
public class GlobalTextLocalizer : MonoBehaviour
{
    [SerializeField] private TextLocale[] TextLocales;
    private void Awake() => UpdateLocale();
    public void UpdateLocale()
    {
        foreach (TextLocale Locale in TextLocales)
            Locale.TextToLocalize.text = PlayerPrefs.GetInt("Language", 0).Equals(1) ? Locale.TextRU : Locale.TextEN;
    }
}
