using UnityEngine;
using UnityEngine.UI;

public class FriendshipBar : MonoBehaviour
{
    [SerializeField] private Slider _friendshipBar;

    private float _targetProgress = 0;
    private float _fillSpeed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (_friendshipBar.value < _targetProgress)
        {
            _friendshipBar.value += _fillSpeed * Time.deltaTime;
        }
        else if (_friendshipBar.value > _targetProgress)
        {
            _friendshipBar.value -= _fillSpeed * Time.deltaTime;
        }

        if (GameController.Instance.Npc._currentNode._lines[GameController.Instance.Npc._currentLine]._maxFriendship)
        {
            MaxOutBar();
        }
    }

    // Change the friendship bar based on the current level of friendship acquired
    public void ChangeFriendship(float friendship)
    {
        _targetProgress = friendship;
    }

    public void MaxOutBar()
    {
        _targetProgress = 50;
        _fillSpeed = 5;
    }
}