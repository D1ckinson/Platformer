using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = _target.transform.position + _offset;
    }
}
