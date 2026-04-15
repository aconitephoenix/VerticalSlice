using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLine", menuName = "ScriptableObjects/DialogueLine", order = 1)]

public class DialogueNode : ScriptableObject
{
    // lines of dialogue
    public string[] _lines;

    // potential player replies
    public string[] _playerReplyOptions;

    // player reply outcomes
    public DialogueNode[] _npcReplies;
}