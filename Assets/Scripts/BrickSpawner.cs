using UnityEngine;
using Random = UnityEngine.Random;

public class BrickSpawner : MonoBehaviour
{
    public static BrickSpawner Instance { get; private set; }
    
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private GameObject brickPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnBrick()
    {
        Instantiate(brickPrefab, spawnLocations[Random.Range(0, spawnLocations.Length)]);
    }
}
