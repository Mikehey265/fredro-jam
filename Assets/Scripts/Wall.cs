using UnityEngine;

public class Wall : MonoBehaviour
{
    public static Wall Instance { get; private set; }

    [SerializeField] private float startingHealth = 5;
    [SerializeField] private float maxHealth = 10;

    private float _currentHealth;
    private bool _isInWallRange;

    private void Awake()
    {
        Instance = this;
        _currentHealth = startingHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInWallRange = true;
            Debug.Log(_isInWallRange);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInWallRange = false;
            Debug.Log(_isInWallRange);
        }
    }

    public void AddHealth()
    {
        _currentHealth++;
        HealthBarUI.OnHealthModified?.Invoke();
    }

    public void RemoveHealth()
    {
        _currentHealth--;
        HealthBarUI.OnHealthModified?.Invoke();
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public bool IsInWallRange()
    {
        return _isInWallRange;
    }
}
