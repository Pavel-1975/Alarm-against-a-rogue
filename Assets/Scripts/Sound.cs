using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;

    private AudioSource _audioSource;
    private bool _soundPlay;

    private float currStrength = 0;
    private float maxStrength = 1;
    private float recoveryRate = 0.005f;

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
        if (_soundPlay && currStrength < 1)
        {
            currStrength = Mathf.MoveTowards(currStrength, maxStrength, recoveryRate);

            _audioSource.volume = currStrength;
        }
        else if (_soundPlay == false && currStrength > 0)
        {
            currStrength = Mathf.MoveTowards(currStrength, maxStrength, -recoveryRate);

            _audioSource.volume = currStrength;
        }
    }

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
