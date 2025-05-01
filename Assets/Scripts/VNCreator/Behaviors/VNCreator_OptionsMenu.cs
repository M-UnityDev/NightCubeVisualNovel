using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using TMPro;
namespace VNCreator
{
    public class VNCreator_OptionsMenu : MonoBehaviour
    {
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;
        [SerializeField] private Slider readSpeedSlider;
        [SerializeField] private Toggle instantTextToggle;
        [SerializeField] private Toggle CRToggle;
	    [SerializeField] private TMP_Dropdown languageDrop;
        [SerializeField] private Button backButton;
        [Header("Menu Objects")]
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject PPCamera;
        [SerializeField] private VNCreator_SfxSource SfxSource;
        [SerializeField] private VNCreator_MusicSource MusicSource;
        [SerializeField] private ScriptableRendererData Renderer;
        [SerializeField] private GlobalTextLocalizer GlobalTextLocalizer;
        private void Start()
        {
            GameOptions.InitilizeOptions();
            UpdateCRT(false);
            if(musicVolumeSlider != null)
            {
                musicVolumeSlider.value = GameOptions.musicVolume;
                musicVolumeSlider.onValueChanged.AddListener(GameOptions.SetMusicVolume);
                musicVolumeSlider.onValueChanged.AddListener(MusicSource.UpdateSoundVolume);
            }
            if (sfxVolumeSlider != null)
            {
                sfxVolumeSlider.value = GameOptions.sfxVolume;
                sfxVolumeSlider.onValueChanged.AddListener(GameOptions.SetSFXVolume);
                sfxVolumeSlider.onValueChanged.AddListener(SfxSource.UpdateSoundVolume);
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
            if (CRToggle != null)
            {
                CRToggle.isOn = GameOptions.isCRT;
                CRToggle.onValueChanged.AddListener(GameOptions.SetCRT);
                CRToggle.onValueChanged.AddListener(UpdateCRT);
            }
            backButton.onClick.AddListener(Back);
	        UpdateLanguage(0);
        }
	    public void UpdateLanguage(int index) => GlobalTextLocalizer.UpdateLocale();
        public void UpdateCRT(bool index)
        {
            PPCamera.SetActive(GameOptions.isCRT);
            foreach (ScriptableRendererFeature feature in Renderer.rendererFeatures) if (feature.name.Equals("CRT")) feature.SetActive(GameOptions.isCRT);
        }
        private void Back()
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
	    }
    }
}
