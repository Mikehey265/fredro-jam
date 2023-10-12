using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
   private bool _isPlayerDamaged;

   private void Start()
   {
      _isPlayerDamaged = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Damageable"))
      {
         _isPlayerDamaged = true;
         if(GameManager.Instance.IsGameOver()) return;
         Obstacle.Instance.RespawnPlayer(gameObject, 2f);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Damageable"))
      {
         _isPlayerDamaged = false;
      }
   }

   public bool GetIsPlayerDamaged()
   {
      return _isPlayerDamaged;
   }
}
