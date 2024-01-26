using UnityEngine;
using System.Collections;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;
    [SerializeField] private float _speed;

    private float _maxVolume = 1.0f;
    private float _minVolume = 0f;

    private Coroutine _currentCoroutine;

    public void SignalizationOn()
    {
        _signal.Play();

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void SignalizationOff()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (_signal.volume != volume)
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, volume, _speed * Time.deltaTime);
            yield return null;
        }

        _signal.volume = volume;

        if (volume == _minVolume)
        {
            _signal.Stop();
        }
    }
}
