using UnityEngine;
namespace VNCreator
{
    public enum Language {EN,RU}
    public static class GameOptions
    {
        public static float musicVolume = 0.5f;
        public static float sfxVolume = 0.5f;
        public static float readSpeed = 0.5f;
        public static bool isInstantText = false;
        public static bool isCRT = false;
        public static Language chosenLanguage;
        public static int chosenResolution;
        public static void InitilizeOptions()
        {
            if (PlayerPrefs.HasKey("MusicVolume"))
                musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            if (PlayerPrefs.HasKey("SfxVolume"))
                sfxVolume = PlayerPrefs.GetFloat("SfxVolume");
            if (PlayerPrefs.HasKey("ReadSpeed"))
                readSpeed = PlayerPrefs.GetFloat("ReadSpeed");
            if (PlayerPrefs.HasKey("InstantText"))
                isInstantText = PlayerPrefs.GetInt("InstantText").Equals(1);
	        if (PlayerPrefs.HasKey("Language"))
                chosenLanguage = PlayerPrefs.GetInt("Language").Equals(1) ? Language.RU : Language.EN;
            if (PlayerPrefs.HasKey("Resolution"))
                chosenResolution = PlayerPrefs.GetInt("Resolution");
            if (PlayerPrefs.HasKey("CRT"))
                isCRT = PlayerPrefs.GetInt("CRT").Equals(1);
        }
        public static void SetMusicVolume(float index)
        {
            musicVolume = index;
            PlayerPrefs.SetFloat("MusicVolume", index);
        }
        public static void SetSFXVolume(float index)
        {
            sfxVolume = index;
            PlayerPrefs.SetFloat("SfxVolume", index);
        }
        public static void SetReadingSpeed(float index)
        {
            readSpeed = index;
            PlayerPrefs.SetFloat("ReadSpeed", index);
        }
        public static void SetInstantText(bool index)
        {
            isInstantText = index;
            PlayerPrefs.SetInt("InstantText", index ? 1 : 0);
        }
        public static void SetCRT(bool index)
        {
            isCRT = index;
            PlayerPrefs.SetInt("CRT", index ? 1 : 0);
        }
	    public static void SetLanguage(int index)
        {
            chosenLanguage = index.Equals(1) ? Language.RU : Language.EN;
            PlayerPrefs.SetInt("Language", index);
        }
        public static void SetResolution(int index)
        {
            chosenResolution = index;
            PlayerPrefs.SetInt("Resolution", index);
        }
    }
}
