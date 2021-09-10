using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;

    private AudioSource _audioSource;
    private bool _soundPlay;

    private float _currentStrength = 0;
    private float _maxStrength = 1;
    private const float _recoveryRate = 0.005f;

    public void Play()
    {
        _audioSource.clip = _sound;

        _audioSource.Play();

        _soundPlay = true;

        StartCoroutine(WaitForTime(_recoveryRate));
    }

    public void Stop()
    {
        _soundPlay = false;
    }

    private void SetVolume()
    {
        if (_soundPlay && _currentStrength <= 1)
        {
            _currentStrength = Mathf.MoveTowards(_currentStrength, _maxStrength, _recoveryRate);

            _audioSource.volume = _currentStrength;

            StartCoroutine(WaitForTime(_recoveryRate));
        }
        else if (_soundPlay == false && _currentStrength >= 0)
        {
            _currentStrength = Mathf.MoveTowards(_currentStrength, _maxStrength, -_recoveryRate);

            _audioSource.volume = _currentStrength;

            StartCoroutine(WaitForTime(_recoveryRate));
        }
    }

    private IEnumerator WaitForTime(float value)
    {
        yield return new WaitForSeconds(value);

        SetVolume();
    }

        private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
