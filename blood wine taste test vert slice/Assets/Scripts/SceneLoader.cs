using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator _fadeAnimator;
    private int _sceneToGo; // Index of scene to switch to

    public void SwitchScene(string sceneName)
    {
        if (sceneName == "Start Screen")
        {
            _sceneToGo = 1;
        }
        else if (sceneName == "Main Scene")
        {
            _sceneToGo = 2;
        }
        else if (sceneName == "Game Over 1")
        {
            _sceneToGo = 3;
        }
        else if (sceneName == "Game Over 2")
        {
            _sceneToGo = 4;
        }

        StartCoroutine(AnimateFade());
        SceneManager.LoadScene(_sceneToGo);
    }

    public IEnumerator AnimateFade()
    {
        _fadeAnimator.SetTrigger("outToIn");

        yield return new WaitForSeconds(2.0f);

        _fadeAnimator.SetTrigger("inToOut");

        yield return new WaitForSeconds(2.0f);
    }

    public void SetInitialValues()
    {
        PlayerPrefs.SetFloat("textSpeed", 0.04f);
        PlayerPrefs.SetFloat("volume", 1);
    }
}