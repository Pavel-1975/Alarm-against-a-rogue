using UnityEngine;


public class Colision : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Sound _sound;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.TryGetComponent<ColisionDoor>(out _))
        {
            _door.Open();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<ColisionHouse>(out _))
        {
            _sound.Stop();
            _door.SetOpen();
        }
    }
}
