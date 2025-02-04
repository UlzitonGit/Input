using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputSubscription _input;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpSpeed = 5f;

    private Rigidbody _rb;
    
    private CapsuleCollider _capsule;
    private Vector2 _playerMovement;
    // Start is called before the first frame update
    private void OnValidate()
    {
        
        _rb = GetComponent<Rigidbody>();
        _capsule = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (_input.JumpInput)
        {
            Jump();
        }
    }
    private void Move()
    {
        _playerMovement = new Vector2(_input.MoveInput.x, _input.MoveInput.y);
        _rb.velocity = new Vector2(_playerMovement.x * _speed, _rb.velocity.y);
        transform.DORotateQuaternion(Quaternion.Euler(transform.rotation.x, transform.rotation.y + _input.MoveInput.x * 90, transform.rotation.z), 1);
        
    }
    private void Jump()
    {
        transform.DOJump(transform.up * 5, 2, 1, 2);
    }
}
