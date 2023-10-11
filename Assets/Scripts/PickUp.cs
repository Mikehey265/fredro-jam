using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static PickUp Instance { get; private set; }

    // [SerializeField] private Rigidbody rb;

    private BoxCollider _boxCollider;
    private bool _isInRange;
    private bool _isBeingHold;

    private void Awake()
    {
        Instance = this;
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInRange = true;
            Debug.Log(_isInRange);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInRange = false;
            Debug.Log(_isInRange);
        }
    }

    private void Update()
    {
        if (_isBeingHold)
        {
            _boxCollider.enabled = false;
        }
    }

    public void SetIsHold(bool isBeingHold, Vector3 parentPosition)
    {
        _isBeingHold = isBeingHold;
        transform.position = parentPosition;
    }

    public bool IsInRange()
    {
        return _isInRange;
    }
}
