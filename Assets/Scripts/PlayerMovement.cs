using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
       [Header("Core")]
       [SerializeField] private Rigidbody rb;
       [SerializeField] private Transform groundCheck;
       [SerializeField] private LayerMask groundLayer;
       
       [Header("Player Settings")]
       [SerializeField] private float speed;
       [SerializeField] private float jumpPower;
       
       private float _horizontal;
       private bool _isFacingRight;

       private void Start()
       {
              _isFacingRight = true;
       }

       private void Update()
       {
              rb.velocity = new Vector3(_horizontal * speed, rb.velocity.y, rb.velocity.z);

              if (!_isFacingRight && _horizontal > 0f)
              {
                     Flip();
              }
              else if (_isFacingRight && _horizontal < 0f)
              {
                     Flip();
              }
       }

       private void Flip()
       {
              _isFacingRight = !_isFacingRight;
              Vector3 facingRight = transform.right;
              facingRight.x *= -1f;
              transform.right = facingRight;
       }

       private bool IsGrounded()
       {
              return rb.velocity.y == 0;
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
}
