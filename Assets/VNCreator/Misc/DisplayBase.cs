using System.Collections.Generic;
using UnityEngine;

namespace VNCreator
{
    public class DisplayBase : MonoBehaviour
    {
        [SerializeField] private StoryObject story;
        [SerializeField] private StoryObject storyRU;
        [SerializeField] private StoryObject storyEN;
        protected NodeData currentNode;
        protected bool lastNode;

        protected List<string> loadList = new List<string>();

        void Awake()
        {
            story = PlayerPrefs.GetInt("Language",0).Equals(1) ? storyRU : storyEN;
            if (PlayerPrefs.GetString(GameSaveManager.currentLoadName) == string.Empty)
            {
                currentNode = story.GetFirstNode();
                loadList.Add(currentNode.guid);
            }
            else
            {
                loadList = GameSaveManager.Load();
                if(loadList == null || loadList.Count == 0)
                {
                    currentNode = story.GetFirstNode();
                    loadList = new List<string>();
                    loadList.Add(currentNode.guid);
                }
                else
                {
                    currentNode = story.GetCurrentNode(loadList[loadList.Count - 1]);
                }
            }
        }

        protected virtual void NextNode(int _choiceId)
        {
            if (!lastNode) 
            {
                currentNode = story.GetNextNode(currentNode.guid, _choiceId);
                lastNode = currentNode.endNode;
                loadList.Add(currentNode.guid);
            }
        }

        protected virtual void Previous()
        {
            loadList.RemoveAt(loadList.Count - 1);
            currentNode = story.GetCurrentNode(loadList[loadList.Count - 1]);
            lastNode = currentNode.endNode;
        }

        protected void Save()
        {
            GameSaveManager.Save(loadList);
        }
    }
}
