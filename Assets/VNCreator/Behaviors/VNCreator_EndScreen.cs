using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_EndScreen : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainMenuButton;
        [Scene]
        [SerializeField] private string mainMenu;

        private void Start()
        {
            restartButton.onClick.AddListener(Restart);
            mainMenuButton.onClick.AddListener(MainMenu);
        }

        private void Restart()
        {
            GameSaveManager.NewLoad("MainGame");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        private void MainMenu()
        {
            SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
        }
    }
}
