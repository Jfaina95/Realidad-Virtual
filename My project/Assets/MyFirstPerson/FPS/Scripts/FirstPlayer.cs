using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayer : MonoBehaviour
{
    public Transform headPosition;

    [Range(0.1f, 25f)] public float movementSpeed = 5;
    [Range(1, 600)] public float mouseSensitivity = 500;

    public Rigidbody rgbd;

    FirstPlayerCamera _myCam;

    float _mouseX;

    float _inputMouseX, _inputMouseY, _inputVertical, _inputHorizontal;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

       if(rgbd == null) rgbd = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (_myCam == null) _myCam = Camera.main.GetComponent<FirstPlayerCamera>();

        if( _myCam != null ) 
        {
            _myCam.SetPlayersHead(headPosition);
        }
    }

    void Update()
    {
        _inputMouseX = Input.GetAxisRaw("Mouse X");
        _inputMouseY = Input.GetAxisRaw("Mouse Y");

        _inputVertical = Input.GetAxis("Vertical");
        _inputHorizontal = Input.GetAxis("Horizontal");

        if (_inputMouseX != 0 || _inputMouseY != 0)
        {
            Rotation(_inputMouseX, _inputMouseY);
        }
    }

    private void FixedUpdate()
    {
        if (_inputVertical != 0 || _inputHorizontal != 0)
        {
            Movement(_inputHorizontal, _inputVertical);
        }
    }

    public void Rotation(float rotX, float rotY)
    {
        _mouseX += rotX * mouseSensitivity * Time.deltaTime;

        if (_mouseX >= 360 || _mouseX >= -360)
        {
            _mouseX -= 360 * Mathf.Sign(_mouseX);
        }

        rotY *= mouseSensitivity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, _mouseX, 0);

        _myCam?.Rotate(_mouseX, rotY);
    }

    public void Movement(float horizontalAxi, float verticalAxi)
    {
        Vector3 direction = transform.forward * verticalAxi + transform.right * horizontalAxi;

        if (direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }

        rgbd.MovePosition(rgbd.position + direction * (movementSpeed * Time.fixedDeltaTime));
    }
}
