using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _counter.Changed += ChangeCounterText;
    }

    private void OnDisable()
    {
        _counter.Changed -= ChangeCounterText;
    }

    private void ChangeCounterText()
    {
        _text.text = _counter.NumberCounter.ToString();
    }
}
