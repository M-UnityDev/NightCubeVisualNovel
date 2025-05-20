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
        [SerializeField] private TMP_Dropdown resolutionDrop;
        [SerializeField] private Button backButton;
        [Header("Menu Objects")]
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject PPCamera;
        [SerializeField] private VNCreator_SfxSource SfxSource;
        [SerializeField] private VNCreator_MusicSource MusicSource;
        [SerializeField] private ScriptableRendererData Renderer;
        [SerializeField] private GlobalTextLocalizer GlobalTextLocalizer;
        private Vector2Int CurrentResolution;
        private void Start()
        {
            GameOptions.InitilizeOptions();
            UpdateCRT(false);
            UpdateResolution(GameOptions.chosenResolution);
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
            if (resolutionDrop != null)
            {
                resolutionDrop.value = GameOptions.chosenResolution;
                resolutionDrop.onValueChanged.AddListener(GameOptions.SetResolution);
                resolutionDrop.onValueChanged.AddListener(UpdateResolution);
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
        public void UpdateResolution(int index)
        {
            Application.targetFrameRate = 25;
            switch (GameOptions.chosenResolution)
            {
                case 1:
                    CurrentResolution.Set(640, 480);
                    break;
                case 2:
                    CurrentResolution.Set(800, 600);
                    break;
                case 3:
                    CurrentResolution.Set(960, 540);
                    break;
                case 4:
                    CurrentResolution.Set(1024, 768);
                    break;
                case 5:
                    CurrentResolution.Set(1280, 720);
                    break;
                case 6:
                    CurrentResolution.Set(1920, 1080);
                    break;
            }
            Screen.SetResolution(CurrentResolution.x, CurrentResolution.y, FullScreenMode.ExclusiveFullScreen, new RefreshRate() { numerator = 25, denominator = 1 });
        }
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
