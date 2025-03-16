using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
namespace VNCreator
{
    public class VNCreator_DisplayUI : DisplayBase
    {
        [Header("Text")]
        [SerializeField] private TMP_Text characterNameTxt;
        [SerializeField] private TMP_Text dialogueTxt;
        [Header("Visuals")]
        [SerializeField] private Image characterImg;
        [SerializeField] private Image backgroundImg;
	[SerializeField] private Image characterNameImg;
	[SerializeField] private Color[] characterClrs;
        [Header("Audio")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource soundEffectSource;
        [Header("Buttons")]
        [SerializeField] private Button nextBtn;
        [SerializeField] private Button previousBtn;
        [SerializeField] private Button saveBtn;
        [SerializeField] private Button menuButton;
        [Header("Choices")]
        [SerializeField] private CanvasGroup choiceBtnParent;
        [SerializeField] private Button choiceBtn1;
        [SerializeField] private Button choiceBtn2;
        [SerializeField] private Button choiceBtn3;
        [SerializeField] private Button choiceBtn4;
        [Header("End")]
        [SerializeField] private GameObject endScreen;
        [Header("Main menu")]
        [Scene]
        [SerializeField] private string mainMenu;
        void Start()
        {
            nextBtn.onClick.AddListener(delegate { NextNode(0); });
            if(previousBtn != null)
                previousBtn.onClick.AddListener(Previous);
            if(saveBtn != null)
                saveBtn.onClick.AddListener(Save);
            if (menuButton != null)
                menuButton.onClick.AddListener(ExitGame);

            if(choiceBtn1 != null)
                choiceBtn1.onClick.AddListener(delegate { NextNode(0); });
            if(choiceBtn2 != null)
                choiceBtn2.onClick.AddListener(delegate { NextNode(1); });
            if(choiceBtn3 != null)
                choiceBtn3.onClick.AddListener(delegate { NextNode(2); });

            endScreen.SetActive(false);

            StartCoroutine(DisplayCurrentNode());
        }

        protected override void NextNode(int _choiceId)
        {
            if (lastNode)
            {
                endScreen.SetActive(true);
                return;
            }

            base.NextNode(_choiceId);
            StartCoroutine(DisplayCurrentNode());
        }

        IEnumerator DisplayCurrentNode()
        {
	    switch (currentNode.characterName)
	    {
		case "Кленси":
		characterNameImg.color = characterClrs[1];
		break;
		case "Clancy":
		characterNameImg.color = characterClrs[1];
		break;	
		case "Лирен":
		characterNameImg.color = characterClrs[2];
		break;			
		case "Liren":
		characterNameImg.color = characterClrs[2];
		break;	
		case "Борис":
		characterNameImg.color = characterClrs[3];
		break;	
		case "Boris":
		characterNameImg.color = characterClrs[3];
		break;
		case "Мэн":
		characterNameImg.color = characterClrs[4];
		break;	
		case "Man":
		characterNameImg.color = characterClrs[4];
		break;
		default:
		characterNameImg.color = characterClrs[0];
		break;
	    }
            characterNameTxt.text = currentNode.characterName;
            if (currentNode.characterSpr != null)
            {
                characterImg.sprite = currentNode.characterSpr;
                characterImg.color = Color.white;
            }
            else
            {
                characterImg.color = new Color(1, 1, 1, 0);
            }
            if(currentNode.backgroundSpr != null)
                backgroundImg.sprite = currentNode.backgroundSpr;

            if (currentNode.choices <= 1) 
            {
                nextBtn.gameObject.SetActive(true);
                choiceBtnParent.DOFade(0, 1);
                choiceBtn1.gameObject.SetActive(false);
                choiceBtn2.gameObject.SetActive(false);
                choiceBtn3.gameObject.SetActive(false);
                choiceBtn4.gameObject.SetActive(false);

                previousBtn.gameObject.SetActive(loadList.Count != 1);
            }
            else
            {
                nextBtn.gameObject.SetActive(false);

                choiceBtn1.gameObject.SetActive(true);
                choiceBtn1.transform.GetChild(0).GetComponent<TMP_Text>().text = currentNode.choiceOptions[0];

                choiceBtn2.gameObject.SetActive(true);
                choiceBtn2.transform.GetChild(0).GetComponent<TMP_Text>().text = currentNode.choiceOptions[1];

                if (currentNode.choices == 3)
                {
                    choiceBtn3.gameObject.SetActive(true);
                    choiceBtn3.transform.GetChild(0).GetComponent<TMP_Text>().text = currentNode.choiceOptions[2];
                }
                else if (currentNode.choices == 4)
                {
                    choiceBtn4.gameObject.SetActive(true);
                    choiceBtn4.transform.GetChild(0).GetComponent<TMP_Text>().text = currentNode.choiceOptions[3];
                }
                else
                {
                    choiceBtn3.gameObject.SetActive(false);
                    choiceBtn4.gameObject.SetActive(false);
                }
                choiceBtnParent.DOFade(1, 1);
            }

            if (currentNode.backgroundMusic != null)
                VNCreator_MusicSource.instance.Play(currentNode.backgroundMusic);
            if (currentNode.soundEffect != null)
                VNCreator_SfxSource.instance.Play(currentNode.soundEffect);

            dialogueTxt.text = string.Empty;
            if (GameOptions.isInstantText)
            {
                dialogueTxt.text = currentNode.dialogueText;
            }
            else
            {
                char[] _chars = currentNode.dialogueText.ToCharArray();
                string fullString = string.Empty;
                for (int i = 0; i < _chars.Length; i++)
                {
                    fullString += _chars[i];
                    VNCreator_SfxSource.instance.Play(currentNode.soundEffect);
                    dialogueTxt.text = fullString;
                    yield return new WaitForSeconds(0.01f/ GameOptions.readSpeed);
                }
            }
        }

        protected override void Previous()
        {
            base.Previous();
            StartCoroutine(nameof(DisplayCurrentNode));
        }

        void ExitGame()
        {
            SceneManager.LoadScene(mainMenu);
        }
    }
}
