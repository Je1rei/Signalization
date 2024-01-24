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
        _signal.volume = Mathf.MoveTowards(_signal.volume, _maxVolume, _speed * Time.deltaTime);

        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
    }

    public void SignalizationOff()
    {
        _currentCoroutine = DecreaseVolume();
        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator DecreaseVolume()
    {
        while(_signal.volume > _minVolume)
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, _minVolume, _speed * Time.deltaTime);
            yield return null;
        }

        _signal.Stop();
        _signal.volume = _minVolume;

        _currentCoroutine = null;
    }
}
