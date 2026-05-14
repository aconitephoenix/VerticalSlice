using UnityEngine;

public enum DialogueType
{
    Neutral,
    Nice,
    Mean
}

public enum Speaker
{
    Player,
    NPC,
    Narrator
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
    // lines of dialogue
    public Line[] _lines;

    // potential player replies
    public Options[] _playerReplyOptions;

    // player reply outcomes
    public DialogueNode[] _npcReplies;
}