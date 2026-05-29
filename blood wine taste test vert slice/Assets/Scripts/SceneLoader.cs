using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (sceneName == "Start Screen")
        {
            _sceneToGo = 1;
        }
        else if (sceneName == "Main Scene")
        {
            _sceneToGo = 2;
        }
        else if (sceneName == "Game Over")
        {
            _sceneToGo = 3;
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

}
