using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendshipBar : MonoBehaviour
{
    [SerializeField] private Slider _friendshipBar;

    private float _targetProgress = 0;
    private float _fillSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }

    // Change the friendship bar based on the current level of friendship acquired
    public void ChangeFriendship(float friendship)
    {
        _targetProgress = friendship;
    }
}
