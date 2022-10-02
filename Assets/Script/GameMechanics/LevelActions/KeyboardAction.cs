using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardAction : LevelAction
{
    public Transform KeysContainer;

    //-1 is no code is wrote.
    private int CodeWritten = -1;

    public TextMeshProUGUI CodeText;

    public int CodeAsked = -1;
    public string CodeTextAsked = $"Enter the date on the pad";
    public static int DigitsIn(int code) { return (int)Mathf.Log10(code) + 1; }

    private void Awake()
    {
        int i = 0;
        foreach (Button b in KeysContainer.GetComponentsInChildren<Button>())
        {
            int id = i;
            b.onClick.AddListener(() => ClickedOnButton(id));
            b.GetComponentInChildren<TextMeshProUGUI>().text = i + string.Empty;
            b.gameObject.name = "Key" + i;
            i++;
        }
    }
    public void ClickedOnButton(int id)
    {
        if (CodeWritten == -1)
        {
            CodeWritten = id;
        }
        else
        {
            CodeWritten *= 10;
            CodeWritten += id;
        }
        CodeText.text = CodeWritten.ToString();

        if (DigitsIn(CodeAsked) == DigitsIn(CodeWritten))
        {
            if (CodeAsked == CodeWritten)
            {
                FinishAction();
            }
            else
            {
                ResetActionSpecific();
            }
        }
    }

    protected override void FinishActionSpecific()
    {
    }

    protected override void ResetActionSpecific()
    {
        CodeWritten = -1;
        CodeText.text = string.Empty;
    }

    protected override void StartActionSpecific()
    {
        CodeWritten = -1;
        CodeText.text = string.Empty;
    }

    public override string ToString()
    {
        return CodeTextAsked;
    }

}
