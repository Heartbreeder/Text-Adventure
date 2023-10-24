using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChapter", menuName = "Text101/Chapter")]
public class ChapterScriptableData : ScriptableObject
{
    public string ChapterName;

    public Sprite ChapterBackground;
    public Sprite ChapterBackgroundFront;

    public AudioClip ChapterBGM;

    [SerializeField]
    public ChapterPages[] ChapterPages;

    [SerializeField]
    public PlayerChoices[] PlayerChoices;

}

[System.Serializable]
public class ChapterPages
{
    [TextArea(5, 15)]
    public string ChapterPage;

    public AudioClip TransitionSFX;
}

[System.Serializable]
public class PlayerChoices
{
    public string ChoiceDescription;
    public string ChoiceAnswer;
    public int VirtueCounter;
    public ChapterScriptableData NextChapter;
}
