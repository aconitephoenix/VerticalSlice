using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject _npcDialogueBox;
    [SerializeField] private GameObject _playerDialogueBox;
    [SerializeField] private TMP_Text _npcDialogueText;
    [SerializeField] private TMP_Text _npcNameText;
    [SerializeField] private TMP_Text _playerDialogueText;
    [SerializeField] private DialogueNode _currentNode;
    [SerializeField] private float _typingSpeed = 0.04f;

    private int _currentLine = 0;
    private string _npcName = "{NPC}";
    private string _playerName = "{???}";
    private Coroutine _typeLineCoroutine;
    private bool _isTyping;
    private bool _skipDialogue;
    private bool _canSkip;
    private string _dialogueLine;
    private bool _waitingForPlayerResponse;

    // Start is called before the first frame update
    void Start()
    {
        _npcDialogueBox.SetActive(true);
        _playerDialogueBox.SetActive(false);
        SetDialogue(_currentNode._lines[_currentLine]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_waitingForPlayerResponse && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)))
        {
            if (_isTyping && _canSkip)
            {
                _skipDialogue = true;
            }

            AdvanceDialogue();
        }
    }

    // Set the dialogue text
    private void SetDialogue(string dialogue)
    {
        if (dialogue.Contains(_playerName))
        {
            // Set player dialogue box active if the player's name is detected in the dialogue
            _playerDialogueBox.SetActive(true);
            _npcDialogueBox.SetActive(false);
            _dialogueLine = dialogue.Remove(0, _npcName.Length);
        }
        else if (dialogue.Contains(_npcName))
        {
            // Otherwise, set NPC dialogue box active if NPC name is detected
            _npcDialogueBox.SetActive(true);
            _playerDialogueBox.SetActive(false);
            _dialogueLine = dialogue.Remove(0, _playerName.Length);
        }

        if (_typeLineCoroutine != null)
        {
            StopCoroutine(_typeLineCoroutine);
        }

        _canSkip = false;

        if (dialogue.Contains(_playerName) || dialogue.Contains(_npcName))
        {
            _typeLineCoroutine = StartCoroutine(TypeLine(_dialogueLine));
        }
        else
        {
            _typeLineCoroutine = StartCoroutine(TypeLine(dialogue));
        }
    }

    private void AdvanceDialogue()
    {
        if (!_isTyping)
        {
            if (_currentLine < _currentNode._lines.Length - 1)
            {
                _currentLine++;
                SetDialogue(_currentNode._lines[_currentLine]);
            }
            else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
            {
                _waitingForPlayerResponse = true;
            }
        }
    }

    // type dialogue letter by letter
    private IEnumerator TypeLine(string dialogue)
    {
        _isTyping = true;
        _skipDialogue = false;

        if (_playerDialogueBox.activeSelf)
        {
            _playerDialogueText.text = dialogue;
            _playerDialogueText.maxVisibleCharacters = 0;
        } else if (_npcDialogueBox.activeSelf)
        {
            _npcDialogueText.text = dialogue;
            _npcDialogueText.maxVisibleCharacters = 0;
        }
            

        yield return new WaitForEndOfFrame();
        _canSkip = true;

        for (int i = 0; i < dialogue.Length + 1; i++)
        {
            if (_skipDialogue)
            {
                if (_playerDialogueBox.activeSelf)
                {
                    _playerDialogueText.maxVisibleCharacters = dialogue.Length + 1;
                } else if (_npcDialogueBox.activeSelf)
                {
                    _npcDialogueText.maxVisibleCharacters = dialogue.Length + 1;
                }
                _skipDialogue = false;
                _isTyping = false;
                yield break;
            }

            if (_playerDialogueBox.activeSelf)
            {
                _playerDialogueText.maxVisibleCharacters = i;
            } else if (_npcDialogueBox.activeSelf)
            {
                _npcDialogueText.maxVisibleCharacters = i;
            }
            yield return new WaitForSeconds(_typingSpeed);
        }

        _isTyping = false;
        _skipDialogue = false;
    }

    private void ShowPlayerOptions()
    {

    }
}
