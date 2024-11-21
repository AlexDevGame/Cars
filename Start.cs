using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public GameHandler gameHandler;

    private void OnTriggerEnter(Collider other)
    {
        gameHandler.StartTimer();
    }
}
