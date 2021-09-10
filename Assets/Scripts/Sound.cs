using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;

    private AudioSource _audioSource;
    private bool _soundPlay;

    private float _currentStrength = 0;
    private float _maxStrength = 1;
    private float _recoveryRate = 0.005f;

    private void FixedUpdate()
    {
        SetVolume();
    }

    public void Play()
    {
        _audioSource.clip = _sound;

        _audioSource.Play();

        _soundPlay = true;
    }

    public void Stop()
    {
        _soundPlay = false;
    }

    private void SetVolume()
    {
        if (_soundPlay && _currentStrength < 1)
        {
            _currentStrength = Mathf.MoveTowards(_currentStrength, _maxStrength, _recoveryRate);

            _audioSource.volume = _currentStrength;
        }
        else if (_soundPlay == false && _currentStrength > 0)
        {
            _currentStrength = Mathf.MoveTowards(_currentStrength, _maxStrength, -_recoveryRate);

            _audioSource.volume = _currentStrength;
        }
    }

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
