using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    private Sound _sound;

    private bool _open;

    private void Start()
    {
        _sound = GetComponent<Sound>();
    }

    public void Open()
    {
        if (_open == false)
        {
            transform.DORotate(new Vector3(0, 84, 0), 5);

            _sound.Play();

            _open = true;
        }
    }

    public void SetOpen()
    {
        _open = false;
    }
}
