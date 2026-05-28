using UnityEngine;

// Type of choice
public enum ChoiceType
{
    Neutral,
    Nice,
    Mean
}

// Current speaker
public enum Speaker
{
    Player,
    NPC,
    Narrator
}

// Dialogue lines
[System.Serializable]
public struct Line
{
    public Speaker _speaker;
    public Sprite _charSprite;
    public Sprite _CG;
    public AudioClip _music;
    public bool _shakeCamera;
    public bool _triggerHeartbeat;

    [TextArea(3, 10)]
    public string _dialogueLine;
}

// Player options
[System.Serializable]
public struct Options
{
    public ChoiceType _choiceType;

    public string _optionText;
}

[CreateAssetMenu(fileName = "DialogueLine", menuName = "ScriptableObjects/DialogueLine", order = 1)]

public class DialogueNode : ScriptableObject
{
    // compare how many times the player has made the same type of choice
    public int _sameOptionTarget;

    // lines of dialogue
    public Line[] _lines;

    // potential player replies
    public Options[] _playerReplyOptions;

    // player reply outcomes
    public DialogueNode[] _npcReplies;

    // if this node ends the game
    public bool _gameEnd;
}