using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the clip on this line is different, change the music (i know the if statement is really ugly but im really tired okay....)
        if (GameController.Instance.Npc._currentNode._lines[GameController.Instance.Npc._currentLine]._music != null && GameController.Instance.Npc._currentNode._lines[GameController.Instance.Npc._currentLine]._music != _musicPlayer.clip)
        {
            _musicPlayer.clip = GameController.Instance.Npc._currentNode._lines[GameController.Instance.Npc._currentLine]._music;
            _musicPlayer.Play();
        }

        _musicPlayer.volume = GameController.Instance._musicVolume;
    }
}
