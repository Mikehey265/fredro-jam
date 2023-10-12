using UnityEngine;

public class PlayerInput : MonoBehaviour
{
       [Header("Core")]
       [SerializeField] private Rigidbody rb;
       [SerializeField] private Transform objectHolder;
       
       [Header("Player Settings")]
       [SerializeField] private float speed;
       [SerializeField] private float jumpPower;

       [Header("Ground check")]
       [SerializeField] private Vector3 boxSize;
       [SerializeField] private float maxDistance;
       [SerializeField] private LayerMask layerMask;

       private PlayerControls _playerControls;
       private PlayerCollision _playerCollision;
       private float _horizontal;
       private float _currentSpeed;
       private bool _isFacingRight;
       private bool _isHoldingObject;

       private void Awake()
       {
              _playerControls = new PlayerControls();
              _playerCollision = GetComponent<PlayerCollision>();
              _playerControls.Enable();
       }

       private void Start()
       {
              _currentSpeed = speed;
              _isFacingRight = true;
              _isHoldingObject = false;
       }

       private void FixedUpdate()
       {
              if(!GameManager.Instance.IsGamePlaying() || _playerCollision.GetIsPlayerDamaged()) return;
              MovePerformed();
              JumpPerformed();
              InteractPerformed();
              
              HoldingBrickBehavior(_isHoldingObject);
              
              if (!_isFacingRight && _horizontal > 0f)
              { 
                     Flip();
              }
              else if (_isFacingRight && _horizontal < 0f)
              {
                     Flip();
              }
       }
       
       private void MovePerformed()
       {
             _horizontal = _playerControls.Player.Move.ReadValue<float>();
              rb.velocity = new Vector2(_horizontal * _currentSpeed * Time.deltaTime, rb.velocity.y);
    }

    private void JumpPerformed()
       {
              if (_playerControls.Player.Jump.IsPressed() && IsGrounded())
              {
                     rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
              }
       }

       private void InteractPerformed()
       {
              if (_playerControls.Player.Interact.IsPressed())
              {
                     if (!_isHoldingObject)
                     {
                            if(!PickUp.Instance.IsInPickUpRange()) return;
                            _isHoldingObject = true;
                            GameManager.OnBrickPickedUp?.Invoke();
                            PickUp.Instance.gameObject.transform.SetParent(objectHolder);
                            PickUp.Instance.SetIsHold(true);
                            PickUp.Instance.gameObject.transform.position = objectHolder.position;
                     } 
                     
                     if (_isHoldingObject)
                     {
                            if(!Wall.Instance.IsInWallRange()) return;
                            Wall.Instance.AddHealth();
                            GameManager.OnWallHpModified?.Invoke();
                            PickUp.Instance.SetIsHold(false);
                            _isHoldingObject = false;
                            Destroy(PickUp.Instance.gameObject);
                            BrickSpawner.Instance.SpawnBrick();
                     }
              }
       }

       private void Flip()
       {
              _isFacingRight = !_isFacingRight;
              Vector3 facingRight = transform.right;
              facingRight.x *= -1f;
              transform.right = facingRight;
       }

       private void HoldingBrickBehavior(bool isHoldingObject)
       {
              _isHoldingObject = isHoldingObject;
              if (_isHoldingObject)
              {
                     _currentSpeed = speed / 2f;      
              }
              else
              {
                     _currentSpeed = speed;
              }
       }

       private void OnDrawGizmos()
       {
              Gizmos.color = Color.red;
              Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
       }

       private bool IsGrounded()
       {
              if (Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, layerMask))
              {
                     return true;
              }

              return false;
       }
}
