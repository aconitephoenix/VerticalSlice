using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    //[SerializeField] private float _typingSpeed = 0.04f;
    [SerializeField] private Image _continueIndicator;
    [SerializeField] private Image _cgDisplay;

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
    }

    // Set the dialogue text
    public void SetDialogue(Line dialogue)
    {
        _dialogueLine = dialogue._dialogueLine;

        // Change the dialogue box based on the current speaker
        if (dialogue._speaker == Speaker.Player)
        {
            _playerDialogueBox.SetActive(true);
            _npcDialogueBox.SetActive(false);
        }
        else if (dialogue._speaker == Speaker.NPC)
        {
            _playerDialogueBox.SetActive(false);
            _npcDialogueBox.SetActive(true);
            _npcNameText.text = "Jessi Atwood";
            GameController.Instance.Npc._spriteRenderer.sprite = dialogue._charSprite;
        }
        else if (dialogue._speaker == Speaker.Narrator)
        {
            _npcDialogueBox.SetActive(true);
            _playerDialogueBox.SetActive(false);
            _npcNameText.text = "";
        }

        if (dialogue._CG != null)
        {
            _cgDisplay.gameObject.SetActive(true);
            _cgDisplay.sprite = dialogue._CG.sprite;
        } else
        {
            _cgDisplay.gameObject.SetActive(false);
        }

            _playerOptions.SetActive(false);

        if (_typeLineCoroutine != null)
        {
            StopCoroutine(_typeLineCoroutine);
        }

        _canSkip = false;

        if (gameObject.activeInHierarchy)
        {
            _typeLineCoroutine = StartCoroutine(TypeLine(_dialogueLine));
        }
    }

    // type dialogue letter by letter
    private IEnumerator TypeLine(string dialogue)
    {
        _isTyping = true;
        _skipDialogue = false;
        _continueIndicator.gameObject.SetActive(false);

        if (_playerDialogueBox.activeSelf)
        {
            _playerDialogueText.text = dialogue;
            _playerDialogueText.maxVisibleCharacters = 0;
        }
        else if (_npcDialogueBox.activeSelf)
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
                }
                else if (_npcDialogueBox.activeSelf)
                {
                    _npcDialogueText.maxVisibleCharacters = dialogue.Length + 1;
                }
                _continueIndicator.gameObject.SetActive(true);
                _skipDialogue = false;
                _isTyping = false;
                yield break;
            }

            if (_playerDialogueBox.activeSelf)
            {
                _playerDialogueText.maxVisibleCharacters = i;
            }
            else if (_npcDialogueBox.activeSelf)
            {
                _npcDialogueText.maxVisibleCharacters = i;
            }
            yield return new WaitForSeconds(0.1f - PlayerPrefs.GetFloat("textSpeed"));
        }

        _isTyping = false;
        _skipDialogue = false;
        _continueIndicator.gameObject.SetActive(true);
    }

    public void ShowPlayerOptions(Options[] options)
    {
        _playerOptions.SetActive(true);

        _option1.text = options[0]._optionText;

        if (options.Length >= 2)
        {
            _option2.transform.parent.gameObject.SetActive(true);
            _option2.text = options[1]._optionText;
        }
        else
        {
            _option2.transform.parent.gameObject.SetActive(false);
        }
    }
}
