using UnityEngine;

public class TrackingPlayer : MonoBehaviour
{
    [SerializeField] Transform _trackedTransform;

    Vector3 _newPosition;

    void Start()
    {
        if (_trackedTransform == null)
        {
            Debug.LogWarning("No transform assigned to track! Destroying script.");
            Destroy(this);
        }
    }

    void Update()
    {

        _newPosition = transform.position;

        _newPosition.x = _trackedTransform.position.x;
        _newPosition.y = _trackedTransform.position.y;
        
        transform.position = _newPosition;
    }
}
