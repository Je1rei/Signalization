using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;
    [SerializeField] private float _speed;

    private float _maxVolume = 1.0f;
    private float _minVolume = 0f;

    private IEnumerator _currentCoroutine;

    public void SignalizationOn()
    {
        _signal.Play();

        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = ChangeVolume(_maxVolume);
        StartCoroutine(_currentCoroutine);
    }

    public void SignalizationOff()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = ChangeVolume(_minVolume);

        if (_currentCoroutine == null)
        {
            _signal.Stop();
        }

        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while(_signal.volume != volume)
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, volume, _speed * Time.deltaTime);
            yield return null;
        }

        _signal.volume = volume;
        _currentCoroutine = null;
    }
}
