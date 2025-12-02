using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _delay;

    public event Action Changed;

    private float _elapsedTime;
    private bool _isCounterOpen;

    public int NumberCounter { get; private set; }

    private void OnEnable()
    {
        _inputReader.PressedButton += OnButtonClick;
    }

    private void OnDisable()
    {
        _inputReader.PressedButton -= OnButtonClick;
    }

    private void OnButtonClick()
    {
        if (_isCounterOpen == false)
        {
            Start();
            return;
        }

        Stop();
    }

    private void Start()
    {
        _isCounterOpen = true;

        StartCoroutine(ChangeNumberCounter());
    }

    private void Stop()
    {
        _isCounterOpen = false;
    }

    private IEnumerator ChangeNumberCounter()
    {
        while (_isCounterOpen)
        {
            _elapsedTime += Time.deltaTime;                    

            if (_elapsedTime >= _delay)
            {
                NumberCounter++;
                Changed?.Invoke();

                _elapsedTime = 0;
            }

            yield return null;
        }
    }
}
