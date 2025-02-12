using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _velocity;
    private Vector3 _playerMovementInput;
    private Vector2 _playerMouseInput;
    private float _xRot;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;

    private void Update()
    {
        _playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        _playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
