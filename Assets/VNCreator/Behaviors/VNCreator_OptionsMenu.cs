using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace VNCreator
{
    public class VNCreator_OptionsMenu : MonoBehaviour
    {
        public Slider musicVolumeSlider;
        public Slider sfxVolumeSlider;
        public Slider readSpeedSlider;
        public Toggle instantTextToggle;
	public TMP_Dropdown languageDrop;
        public Button backButton;

        [Header("Menu Objects")]
        public GameObject optionsMenu;
        public GameObject mainMenu;

        void Start()
        {
            GameOptions.InitilizeOptions();

            if(musicVolumeSlider != null)
            {
                musicVolumeSlider.value = GameOptions.musicVolume;
                musicVolumeSlider.onValueChanged.AddListener(GameOptions.SetMusicVolume);
            }
            if (sfxVolumeSlider != null)
            {
                sfxVolumeSlider.value = GameOptions.sfxVolume;
                sfxVolumeSlider.onValueChanged.AddListener(GameOptions.SetSFXVolume);
            }
            if (readSpeedSlider != null)
            {
                readSpeedSlider.value = GameOptions.readSpeed;
                readSpeedSlider.onValueChanged.AddListener(GameOptions.SetReadingSpeed);
            }
            if (instantTextToggle != null)
            {
                instantTextToggle.isOn = GameOptions.isInstantText;
                instantTextToggle.onValueChanged.AddListener(GameOptions.SetInstantText);
            }
	    if (languageDrop != null)
            {
                languageDrop.value = GameOptions.chosenLanguage.Equals(Language.RU) ? 1 : 0;
                languageDrop.onValueChanged.AddListener(GameOptions.SetLanguage);
		languageDrop.onValueChanged.AddListener(UpdateLanguage);
            }
            backButton.onClick.AddListener(Back);
	    UpdateLanguage(0);
        }
	public void UpdateLanguage(int index)
	{
	    foreach(TextLocalizer text in FindObjectsByType<TextLocalizer>(FindObjectsInactive.Include, FindObjectsSortMode.None))
	    {
		text.CheckText();
	    }
	}
        void Back()
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
	}
    }
}
