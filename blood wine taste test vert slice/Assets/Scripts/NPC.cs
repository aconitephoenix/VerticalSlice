using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private DialogueNode _currentNode;
    [SerializeField] private DialogueUI _dialogue;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _currentLine;
    private List<DialogueNode> _selectedOptions = new List<DialogueNode>();
    private int _sameOptionCount;
    private float _friendshipValue;

    // Start is called before the first frame update
    void Start()
    {
        _friendshipValue = 0.0f;
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
                _selectedOptions.Add(_currentNode);

                if (_selectedOptions.Count > 1 && _selectedOptions[_selectedOptions.IndexOf(_currentNode) - 1]._dialogueType == _selectedOptions[_selectedOptions.IndexOf(_currentNode)]._dialogueType)
                {
                    _sameOptionCount++;
                }
                else
                {
                    _sameOptionCount = 0;
                }

                if (_currentNode._dialogueType == DialogueType.Nice)
                {
                    if (_sameOptionCount > 2)
                    {
                        _friendshipValue--;
                    }
                    else
                    {
                        _friendshipValue++;
                    }
                }
                else if (_currentNode._dialogueType == DialogueType.Mean)
                {
                    if (_sameOptionCount < 2)
                    {
                        _friendshipValue++;
                    }
                    else
                    {
                        _friendshipValue--;
                    }
                }
                AdvanceDialogue();
                Debug.Log(_friendshipValue);
            }
        }
    }

    // Changes NPC sprite based on emotion
    public void ChangeEmotion(string emotion)
    {
        if (emotion == "angry")
        {
            _spriteRenderer.color = Color.red;
        }
        else if (emotion == "happy")
        {
            _spriteRenderer.color = Color.yellow;
        }
    }
}
