using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueNode _currentNode;
    [SerializeField] private DialogueUI _dialogue;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _currentLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_dialogue._waitingForPlayerResponse && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)))
        {
            if (_dialogue._isTyping && _dialogue._canSkip)
            {
                _dialogue._skipDialogue = true;
            }

            AdvanceDialogue();
        }
    }

    // Progresses dialogue
    private void AdvanceDialogue()
    {
        if (!_dialogue._isTyping)
        {
            if (_currentLine < _currentNode._lines.Length - 1)
            {
                _currentLine++;
                _dialogue.SetDialogue(_currentNode._lines[_currentLine]);
            }
            else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
            {
                _dialogue._waitingForPlayerResponse = true;
                _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
            }
        }
    }

    public void SelectedOption(int option)
    {
        if (!_dialogue._isTyping)
        {
            _currentLine = -1;
            _dialogue._waitingForPlayerResponse = false;

            if (option < _currentNode._npcReplies.Length)
            {
                _currentNode = _currentNode._npcReplies[option];
                AdvanceDialogue();
            }
        }
    }

    // Changes NPC sprite based on emotion
    public void ChangeEmotion(string emotion)
    {
        if (emotion == "angry")
        {
            _spriteRenderer.color = Color.red;
        } else if (emotion == "happy")
        {
            _spriteRenderer.color = Color.yellow;
        }
    }
}
