using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialoguePanelConfig dialoguePanel;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private String playerName = "player";
    [SerializeField] private Sprite playerPortrait;
    [SerializeField] private List<Character> characters;

    private Story _story;
    private static DialogueManager _instance;
    public static DialogueManager Instance => _instance;
    
    private int _choiceIndex = 0;
    private List<GameObject> _choiceButtons = new();
    
    // Singleton. Check for existing _instance of the class
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("There is already an _instance of DialogueManager in the scene");
        }
    }
    private void Start() {
        dialoguePanel.gameObject.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (_choiceButtons.Count > 0) {
                _story.ChooseChoiceIndex(_choiceIndex);
            }
            DisplayNextSentence();
        }else if (Input.GetKeyDown(KeyCode.W) && _choiceButtons.Count > 1) {
            _choiceButtons[_choiceIndex].GetComponent<ButtonSelectionHelper>().OnDeselected();
            _choiceIndex = _choiceIndex == 0 ? _choiceButtons.Count - 1 : _choiceIndex - 1;
            _choiceButtons[_choiceIndex].GetComponent<ButtonSelectionHelper>().OnSelected();

        }else if (Input.GetKeyDown(KeyCode.S) && _choiceButtons.Count > 1) {
            _choiceButtons[_choiceIndex].GetComponent<ButtonSelectionHelper>().OnDeselected();
            _choiceIndex = (_choiceIndex + 1) % _choiceButtons.Count;
            _choiceButtons[_choiceIndex].GetComponent<ButtonSelectionHelper>().OnSelected();
        }
    }

    public void StartDialogue(TextAsset dialogue) {
        _story = new Story(dialogue.text);
        dialoguePanel.gameObject.SetActive(true);
        DisplayNextSentence();
    }
    
    public void DisplayNextSentence() {
        _choiceIndex = 0;
        if (_story.canContinue) {
            string text = _story.Continue();
            // slice the speaker name if it exists
            if (text.Contains(':')) {
                string[] parts = text.Split(':');
                dialoguePanel.SpeakerName.text = parts[0];
                text = parts[1];
                // set speaker portrait if it exists
                if (parts[0].ToLower().Equals(playerName.ToLower()))  {
                    dialoguePanel.SpeakerPortrait.sprite = playerPortrait;
                } else {
                    foreach (Character character in characters) {
                        if (character.CharacterName.ToLower().Equals(parts[0].ToLower())) {
                            dialoguePanel.SpeakerPortrait.sprite = character.CharacterPortrait;
                        }
                    }
                }
            }
            dialoguePanel.SpeakerText.text = text;
            
            // clear choices first
            _choiceButtons.Clear();
            foreach (Transform child in dialoguePanel.ChoicesParent.transform) {
                Destroy(child.gameObject);
            }
            
            // create button for each choice
            List<Choice> choices = _story.currentChoices;
            foreach (Choice choice in choices) {
                GameObject button = Instantiate(choicePrefab, dialoguePanel.ChoicesParent.transform);
                button.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
                _choiceButtons.Add(button);
            }
            if(_choiceButtons.Count > 0) _choiceButtons[0].GetComponent<ButtonSelectionHelper>().OnSelected();
        } else {
            ExitDialogue();
        }
    }
    
    public void ExitDialogue() {
        dialoguePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
