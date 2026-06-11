using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public NPC Npc { get; private set; }

    public SceneLoader sceneLoader { get; private set; }

    public Slider _textSpeedSlider;

    public Slider _volumeSlider;

    private float _typingSpeed = 0.04f;

    public float _musicVolume = 1.0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject npcObj = GameObject.FindWithTag("NPC");

        if (npcObj != null)
        {
            Npc = npcObj.GetComponent<NPC>();
        }

        GameObject sceneLoaderObj = GameObject.FindWithTag("SceneLoader");
        sceneLoader = sceneLoaderObj.GetComponent<SceneLoader>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _typingSpeed = PlayerPrefs.GetFloat("textSpeed");
        _textSpeedSlider.value = _typingSpeed;

        _musicVolume = PlayerPrefs.GetFloat("volume");
        _volumeSlider.value = _musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("textSpeed", _typingSpeed);
        PlayerPrefs.SetFloat("volume", _musicVolume);
    }

    public void ChangeTextSpeed(float speed)
    {
        _typingSpeed = speed;
    }

    public void ChangeVolume(float volume)
    {
        _musicVolume = volume;
    }
}