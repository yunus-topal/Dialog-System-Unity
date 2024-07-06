using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanelConfig : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerText;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private Image speakerPortrait;
    [SerializeField] private GameObject choicesParent;

    public TextMeshProUGUI SpeakerText {
        get => speakerText;
        set => speakerText = value;
    }

    public TextMeshProUGUI SpeakerName {
        get => speakerName;
        set => speakerName = value;
    }

    public Image SpeakerPortrait {
        get => speakerPortrait;
        set => speakerPortrait = value;
    }

    public GameObject ChoicesParent {
        get => choicesParent;
        set => choicesParent = value;
    }
}
