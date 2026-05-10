using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int _sceneToGo; // Index of scene to switch to

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (sceneName == "Start Screen")
        {
            _sceneToGo = 0;
        } else if (sceneName == "Main Scene")
        {
            _sceneToGo = 1;
        }

        SceneManager.LoadScene(_sceneToGo);
    }
}
