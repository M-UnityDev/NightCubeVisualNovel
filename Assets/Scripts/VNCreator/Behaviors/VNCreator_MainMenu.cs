using System.Collections;
using Unity.Burst;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace VNCreator
{
    [BurstCompile] public class VNCreator_MainMenu : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button newGameBtn;
        [SerializeField] private Button continueBtn;
        [SerializeField] private Button optionsMenuBtn;
        [SerializeField] private Button quitBtn;

        [Header("")]
        [Scene]
        [SerializeField] private string playScene;

        [Header("Menu Objects")]
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private DarkDirector dark;

        void Start()
        {
            if(newGameBtn != null)
                newGameBtn.onClick.AddListener(NewGame);
            if(optionsMenuBtn != null)
                optionsMenuBtn.onClick.AddListener(DisplayOptionsMenu);
            if(quitBtn != null)
                quitBtn.onClick.AddListener(Quit);
            if (continueBtn != null)
            {
                if (PlayerPrefs.HasKey("MainGame"))
                    continueBtn.onClick.AddListener(LoadGame);
                else
                    continueBtn.interactable = false;
            }
        }

        void NewGame()
        {
            GameSaveManager.NewLoad("MainGame");
            StartCoroutine(nameof(LoadScene));
        }

        void LoadGame()
        {
            GameSaveManager.currentLoadName = "MainGame";
            StartCoroutine(nameof(LoadScene));
        }

        void DisplayOptionsMenu()
        {
            optionsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }

        void Quit()
        {
            dark.Dark();
            Invoke(nameof(Application.Quit),1);
        }

        private IEnumerator LoadScene()
        {
            dark.Dark();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(playScene, LoadSceneMode.Single);
        }
    }
}
