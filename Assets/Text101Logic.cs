using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Text101Logic : MonoBehaviour
{
    [Header("Game Data")]
    public ChapterScriptableData FirstChapter;
    public ChapterScriptableData[] Chapters;
    public GameObject ChoicesButtonPrefab;

    [Header("Scene Objects")]
    public Image BackgroundImage;
    public Image BackgroundFrontImage;
    public GameObject CentralCanvas;
    public TextMeshProUGUI ChapterTitle;
    public TextMeshProUGUI ChapterText;
    public GameObject ChoicesViewport;
    public AudioSource AudioComponent;

    public ChapterScriptableData CurrentChapter;
    public int CurrentChapterPage;
    public int VirtueScore;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        CurrentChapter = Chapters[0];
        CurrentChapterPage = 0;
        LoadChapter(FirstChapter);
    }

    public void LoadChapter(ChapterScriptableData chapter)
    {
        ChapterTitle.text = chapter.ChapterName;
        BackgroundImage.sprite = chapter.ChapterBackground;
        if (chapter.ChapterBackgroundFront != null)
            BackgroundFrontImage.sprite = chapter.ChapterBackgroundFront;
        else
            BackgroundFrontImage.sprite = chapter.ChapterBackground;
        AudioComponent.clip = chapter.ChapterBGM;
        AudioComponent.Play();

        CurrentChapter = chapter;
        CurrentChapterPage = 0;
        LoadChapterPage(chapter, CurrentChapterPage);


    }

    public void LoadChapterPage(ChapterScriptableData chapter, int page)
    {
        ChapterText.text = chapter.ChapterPages[page].ChapterPage;
        LoadChoices();
    }

    public void LoadChoices()
    {
        //Clear previous
        for(int i= ChoicesViewport.transform.childCount -1; i>=0; i--)
        {
            Destroy(ChoicesViewport.transform.GetChild(i).gameObject);
        }

        if(CurrentChapterPage < CurrentChapter.ChapterPages.Length - 1)
        {
            GameObject temp;
            temp = Instantiate(ChoicesButtonPrefab, ChoicesViewport.transform);
            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Continue";
            temp.GetComponent<Button>().onClick.AddListener(delegate { NextPage(); });
        }
        else
        {
            if (CurrentChapter.PlayerChoices.Length > 0)
            {
                for(int i=0; i< CurrentChapter.PlayerChoices.Length;i++)
                {
                    PlayerChoices choice = CurrentChapter.PlayerChoices[i];
                    GameObject temp;
                    temp = Instantiate(ChoicesButtonPrefab, ChoicesViewport.transform);
                    temp.GetComponent<SelectionLogic>().Init(this, choice.ChoiceDescription, i);

                }
            }
            else
            {
                GameObject temp;
                temp = Instantiate(ChoicesButtonPrefab, ChoicesViewport.transform);
                temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "End. Your Virtue score was " + VirtueScore + ". Virtue will determine if you can reach the good ending in the full game. Play again to aim for a positive score or see alternative endings!";
                temp.GetComponent<Button>().onClick.AddListener(delegate { LoadChapter(FirstChapter); });
            }
        }
    }

    public void NextPage()
    {
        CurrentChapterPage++;
        LoadChapterPage(CurrentChapter, CurrentChapterPage);
    }

    public void ClickSelection(int choiceIndex)
    {
        Debug.Log(choiceIndex);
        //VirtueScore += CurrentChapter.PlayerChoices[choiceIndex].VirtueCounter;
        LoadChapter(CurrentChapter.PlayerChoices[choiceIndex].NextChapter);
    }

    public void SaveProgress()
    {

    }

    public void LoadProgress()
    {

    }
}
