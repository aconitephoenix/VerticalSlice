using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject _npcDialogueBox;
    [SerializeField] private GameObject _playerDialogueBox;
    [SerializeField] private GameObject _playerOptions;
    [SerializeField] private TMP_Text _npcDialogueText;
    [SerializeField] private TMP_Text _npcNameText;
    [SerializeField] private TMP_Text _playerDialogueText;
    [SerializeField] private TMP_Text _option1;
    [SerializeField] private TMP_Text _option2;
    [SerializeField] private DialogueNode _currentNode;
    [SerializeField] private float _typingSpeed = 0.04f;

    private int _currentLine = 0;
    private string _npcName = "{NPC}";
    private string _playerName = "{???}";
    private Coroutine _typeLineCoroutine;
    public bool _isTyping;
    public bool _skipDialogue;
    public bool _canSkip;
    private string _dialogueLine;
    public bool _waitingForPlayerResponse;

    // Start is called before the first frame update
    void Start()
    {
        _npcDialogueBox.SetActive(true);
        _playerDialogueBox.SetActive(false);
        SetDialogue(_currentNode._lines[_currentLine]);
    }

    // Set the dialogue text
    public void SetDialogue(string dialogue)
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
            if (dialogue.Contains("{angry}"))
            {
                GameController.Instance.Npc.ChangeEmotion("angry");
                _dialogueLine = _dialogueLine.Remove(0, "{angry}".Length);
            } else if (dialogue.Contains("{happy}"))
            {
                GameController.Instance.Npc.ChangeEmotion("happy");
                _dialogueLine = _dialogueLine.Remove(0, "{happy}".Length);
            }
        }

        _playerOptions.SetActive(false);

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

    // type dialogue letter by letter
    public IEnumerator TypeLine(string dialogue)
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

    public void ShowPlayerOptions(string[] options)
    {
        _playerOptions.SetActive(true);

        _option1.text = options[0];

        if (options.Length >= 2)
        {
            _option2.transform.parent.gameObject.SetActive(true);
            _option2.text = options[1];
        }
        else
        {
            _option2.transform.parent.gameObject.SetActive(false);
        }
    }
}
