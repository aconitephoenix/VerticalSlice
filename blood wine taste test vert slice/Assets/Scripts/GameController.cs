using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public NPC Npc { get; private set; }

    public SceneLoader sceneLoader { get; private set; }

    public Slider _textSpeedSlider;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject npcObj = GameObject.FindWithTag("NPC");
        Npc = npcObj.GetComponent<NPC>();

        GameObject sceneLoaderObj = GameObject.FindWithTag("SceneLoader");
        sceneLoader = sceneLoaderObj.GetComponent<SceneLoader>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //_textSpeedSlider.value = PlayerPrefs.GetFloat("textSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("textSpeed", _textSpeedSlider.value);
    }

    public void ChangeTextSpeedSliderValue()
    {

    }
}
