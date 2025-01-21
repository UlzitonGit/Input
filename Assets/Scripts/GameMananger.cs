using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    InputSubscription _input;
    private void Awake()
    {
        _input = GetComponent<InputSubscription>();
    }
}
