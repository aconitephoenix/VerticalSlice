using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] public DialogueNode _startingNode;
    [SerializeField] private DialogueUI _dialogue;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private FriendshipBar _friendshipBar;

    public DialogueNode _currentNode;
    public int _currentLine;
    public List<Options> _selectedOptions = new List<Options>();
    public int _sameOptionCount;
    public float _friendshipValue;
    private bool _canContinue;

    // Start is called before the first frame update
    void Start()
    {
        _friendshipValue = 0.0f;
        _currentNode = _startingNode;
        _dialogue.SetDialogue(_currentNode._lines[_currentLine]);
        _canContinue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            if (!_dialogue._waitingForPlayerResponse && _currentLine < _currentNode._lines.Length)
            {
                if (_dialogue._isTyping && _dialogue._canSkip)
                {
                    _dialogue._skipDialogue = true;
                }

                AdvanceDialogue();
            }
            else if (_canContinue)
            {
                EndDialogue();
            }
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
                _canContinue = true;
            }
            else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
            {
                _dialogue._waitingForPlayerResponse = true;
                _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
                _canContinue = false;
            }
            else
            {
                EndDialogue();
                _canContinue = true;
            }
        }
    }

    private void EndDialogue()
    {
        GameController.Instance.sceneLoader.SwitchScene("Game Over");
    }

    // When player selects an option
    public void SelectedOption(int option)
    {
        if (!_dialogue._isTyping)
        {
            _currentLine = -1;
            _dialogue._waitingForPlayerResponse = false;
            _canContinue = true;

            if (option < _currentNode._npcReplies.Length)
            {
                _currentNode = _currentNode._npcReplies[option];
                _selectedOptions.Add(_currentNode._playerReplyOptions[option]);

                if (_selectedOptions.Count > 1 && _selectedOptions[_selectedOptions.IndexOf(_currentNode._playerReplyOptions[option]) - 1]._choiceType == _selectedOptions[_selectedOptions.IndexOf(_currentNode._playerReplyOptions[option])]._choiceType)
                {
                    // Checks if the chosen option's type matches the previous option's type and adds to the same option count
                    _sameOptionCount++;
                }
                else
                {
                    // Otherwise, reset the same option count
                    _sameOptionCount = 0;
                }

                Debug.Log("same option count:" + _sameOptionCount);

                if (_currentNode._playerReplyOptions[option]._choiceType == DialogueType.Nice)
                {
                    // Subtract from the friendship score if more than 2 nice choices have been made in a row,
                    // add to the friendship score if 2 or less nice choices have been made
                    if (_sameOptionCount > 2 && _friendshipValue > 0)
                    {
                        _friendshipValue -= 0.1f;
                    }
                    else
                    {
                        _friendshipValue += 0.1f;
                    }
                }
                else if (_currentNode._playerReplyOptions[option]._choiceType == DialogueType.Mean)
                {
                    // Add to the friendship score if less than 3 mean choices have been made in a row.
                    // subtract from the friendship score if 3 or more mean choices have been made
                    if (_sameOptionCount < 3)
                    {
                        _friendshipValue += 0.1f;
                    }
                    else if (_friendshipValue > 0)
                    {
                        _friendshipValue -= 0.1f;
                    }
                }

                _friendshipBar.ChangeFriendship(_friendshipValue);
                AdvanceDialogue();
                Debug.Log(_friendshipValue);
            }
            else
            {
                EndDialogue();
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
        else if (emotion == "neutral")
        {
            _spriteRenderer.color = Color.white;
        }
    }
}
