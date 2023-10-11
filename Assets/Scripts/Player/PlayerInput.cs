using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
       [Header("Core")]
       [SerializeField] private Rigidbody rb;
       [SerializeField] private Transform objectHolder;
       
       [Header("Player Settings")]
       [SerializeField] private float speed;
       [SerializeField] private float jumpPower;

       private PlayerControls _playerControls;
       private float _horizontal;
       private float _currentSpeed;
       private bool _isFacingRight;
       private bool _isHoldingObject;

       private void Awake()
       {
              _playerControls = new PlayerControls();
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
              if (_playerControls.Player.Interact.IsPressed() && PickUp.Instance.IsInRange() && !_isHoldingObject)
              {
                     _isHoldingObject = true;
                     PickUp.Instance.gameObject.transform.SetParent(objectHolder);
                     PickUp.Instance.SetIsHold(true, objectHolder.transform.position);
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

       private bool IsGrounded()
       {
              return rb.velocity.y == 0;
       }
}
