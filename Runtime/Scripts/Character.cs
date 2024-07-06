using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Character", menuName = "Character")]
public class Character : ScriptableObject
{
    [SerializeField] private String characterName;
    [SerializeField] private Sprite characterPortrait;
    [SerializeField] private TextAsset dialogues;
    
    public string CharacterName => characterName;
    public Sprite CharacterPortrait => characterPortrait;
    public TextAsset Dialogues => dialogues;
}
