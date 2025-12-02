using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;

    public event Action Changed;

    private int _numberCounter;
    private bool _isPressedButton;
    private float _elapsedTime;

    public int NumberCounter => _numberCounter;

    private void Update()
    {
        OnMouseButton();
    }

    private void OnMouseButton()
    {
        if (Input.GetMouseButtonDown(0) && _isPressedButton)
            _isPressedButton = false;
        else if (Input.GetMouseButtonDown(0) && _isPressedButton == false)
            _isPressedButton = true;

        StartCoroutine(ChangeNumberCounter());
    }

    private IEnumerator ChangeNumberCounter()
    {
        if (_isPressedButton == false)
            yield break;

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _delay)
        {
            _numberCounter++;
            Changed?.Invoke();

            _elapsedTime = 0;
        }
    }
}
