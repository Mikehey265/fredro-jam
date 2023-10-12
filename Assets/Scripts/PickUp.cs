using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static PickUp Instance { get; private set; }

    private BoxCollider _boxCollider;
    private bool _isInPickUpRange;
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
            _isInPickUpRange = true;
            Debug.Log(_isInPickUpRange);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInPickUpRange = false;
            Debug.Log(_isInPickUpRange);
        }
    }

    private void Update()
    {
        if (_isBeingHold)
        {
            _boxCollider.enabled = false;
            _isInPickUpRange = false;
        }
    }

    public void SetIsHold(bool isBeingHold)
    {
        _isBeingHold = isBeingHold;
    }

    public bool IsInPickUpRange()
    {
        return _isInPickUpRange;
    }
}
