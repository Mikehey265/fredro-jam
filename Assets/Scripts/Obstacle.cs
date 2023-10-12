using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public static Obstacle Instance { get; private set; }
    
    [SerializeField] private Transform respawnPoint;
    
    private void Awake()
    {
        Instance = this;
    }

    public void RespawnPlayer(GameObject player, float time)
    {
        StartCoroutine(WaitBeforeRespawnPlayer(player, time));
    }
    
    IEnumerator WaitBeforeRespawnPlayer(GameObject player, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        player.transform.position = respawnPoint.position;
    }
}
