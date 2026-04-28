using UnityEngine;

public enum DialogueType
{
    Neutral,
    Nice,
    Mean
}

[CreateAssetMenu(fileName = "DialogueLine", menuName = "ScriptableObjects/DialogueLine", order = 1)]

public class DialogueNode : ScriptableObject
{
    // whether this is a nice, mean, or neutral piece of dialogue
    public DialogueType _dialogueType = DialogueType.Neutral;

    // lines of dialogue
    public string[] _lines;

    // potential player replies
    public string[] _playerReplyOptions;

    // player reply outcomes
    public DialogueNode[] _npcReplies;
}