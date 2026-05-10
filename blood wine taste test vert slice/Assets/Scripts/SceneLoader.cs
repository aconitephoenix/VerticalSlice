using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
    public Animator _fadeAnimator;
    private int _sceneToGo; // Index of scene to switch to

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScene(string sceneName)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (sceneName == "Start Screen")
        {
            _sceneToGo = 0;
        } else if (sceneName == "Main Scene")
        {
            _sceneToGo = 1;
        }

        StartCoroutine(AnimateFade(_sceneToGo));
        SceneManager.LoadScene(_sceneToGo);
    }

    
    public IEnumerator AnimateFade(int scene)
    {
        if (scene == 0)
        {
            _fadeAnimator.SetTrigger("start");
        } else if (scene == 1) { 
        }
        {
            _fadeAnimator.SetTrigger("end");
        }
        
        yield return new WaitForSeconds(2.0f);
    }
    
}
