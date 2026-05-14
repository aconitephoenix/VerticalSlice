using JetBrains.Annotations;
using UnityEngine;

public enum DialogueType
{
    Neutral,
    Nice,
    Mean
}

public enum Speaker
{
    Narrator,
    Player,
    NPC
}

[System.Serializable]
public struct Line
{
    public Speaker _speaker;
    public Sprite _charSprite;

    public string _dialogueLine;
}

[System.Serializable]
public struct Options
{
    public DialogueType _choiceType;

    public string _optionText;
}

[CreateAssetMenu(fileName = "DialogueLine", menuName = "ScriptableObjects/DialogueLine", order = 1)]

public class DialogueNode : ScriptableObject
{
    // whether this is a nice, mean, or neutral piece of dialogue
    //public DialogueType _dialogueType = DialogueType.Neutral;

    // lines of dialogue
    //public string[] _lines;
    public Line[] _lines;

    // potential player replies
    //public string[] _playerReplyOptions;

    public Options[] _playerReplyOptions;

    // player reply outcomes
    public DialogueNode[] _npcReplies;
}