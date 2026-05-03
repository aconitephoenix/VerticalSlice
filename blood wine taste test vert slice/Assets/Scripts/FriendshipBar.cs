using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendshipBar : MonoBehaviour
{
    [SerializeField] private Slider _friendshipBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Change the friendship bar based on the current level of friendship acquired
    public void ChangeFriendship(float friendship)
    {
        _friendshipBar.value = friendship;
    }
}
