using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action PressedButton;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))        
            PressedButton?.Invoke();    
    }
}
