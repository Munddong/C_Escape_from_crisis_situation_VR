using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTrigger_yejin : MonoBehaviour //스토리 트리거
{
    public StoryData_yejin data;

    Story_yejin storyManager;

    void Awake()
    {
        //storyManager.NextButton = GameObject.Find("NextButton");
        //storyManager.NextButton.SetActive(false);
        storyManager = FindObjectOfType<Story_yejin>();
    }

    public void TriggerStory()
    {
        storyManager.StartStory(data);
        storyManager.NextButton.SetActive(true);
    }

}
