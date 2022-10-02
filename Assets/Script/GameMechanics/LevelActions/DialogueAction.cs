using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueAction : LevelAction
{
    public TextMeshProUGUI patronTalk;
    public Button nextButton;
    public List<string> textToTalk = new List<string>();
    private int num = -1;

    protected void goNext()
    {
        num++;
        if (num >= textToTalk.Count)
        {
            FinishAction();
            return;
        }
        patronTalk.text = textToTalk[num];

        
    }

    protected override void FinishActionSpecific()
    {
        Time.timeScale = 1f;
    }

    protected override void ResetActionSpecific()
    {
        
    }

    protected override void StartActionSpecific()
    {
        nextButton.onClick.AddListener( goNext);
        Time.timeScale = 0f;
        goNext();
    }
}