using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
       [Header("Core")]
       [SerializeField] private Rigidbody rb;
       [SerializeField] private Transform objectHolder;
       [SerializeField] private Transform groundCheck;
       [SerializeField] private LayerMask groundLayer;
       
       [Header("Player Settings")]
       [SerializeField] private float speed;
       [SerializeField] private float jumpPower;
       
       private float _horizontal;
       private float _currentSpeed;
       private bool _isFacingRight;
       private bool _isHoldingObject;

       private void Start()
       {
              _currentSpeed = speed;
              _isFacingRight = true;
              _isHoldingObject = false;
       }

       private void Update()
       {
              rb.velocity = new Vector3(_horizontal * speed, rb.velocity.y, rb.velocity.z);
              HoldingBrickBehavior(_isHoldingObject);

              Debug.Log(_currentSpeed);
              if (!_isFacingRight && _horizontal > 0f)
              {
                     Flip();
              }
              else if (_isFacingRight && _horizontal < 0f)
              {
                     Flip();
              }
       }
       
       public void Move(InputAction.CallbackContext ctx)
       {
              _horizontal = ctx.ReadValue<Vector2>().x;
       }

       public void Jump(InputAction.CallbackContext ctx)
       {
              if (ctx.performed && IsGrounded())
              {
                     rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
              }
       }

       public void Interact(InputAction.CallbackContext ctx)
       {
              if (ctx.performed && PickUp.Instance.IsInRange() && !_isHoldingObject)
              {
                     _isHoldingObject = true;
                     PickUp.Instance.gameObject.transform.SetParent(objectHolder);
                     PickUp.Instance.SetIsHold(true, objectHolder.transform.position);
                     Debug.Log(PickUp.Instance.name);
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
              if (!_isHoldingObject) return;

              _currentSpeed = speed / 2f;
       }

       private bool IsGrounded()
       {
              return rb.velocity.y == 0;
       }
}
