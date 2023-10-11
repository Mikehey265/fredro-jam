using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public static Wall Instance { get; private set; }
    
    private bool _isInWallRange;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInWallRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInWallRange = false;
        }
    }
}
