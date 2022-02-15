using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float walkSpeed;
    [SerializeField] float lookSensitivity, cameraRotationLimit, currentCameraRotationX;
    [SerializeField]
    Camera theCamera;

    Rigidbody myRigid;
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            CameraRotation();
            CharacterRotation();
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Move();
        }
        else
        {
            Freeze();
        }
    }

    void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;
        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }

    void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    void Freeze()
    {
        myRigid.angularVelocity = Vector3.zero;
        myRigid.velocity = Vector3.zero;
    }
    void FixedUpdate()
    {
        Freeze();
    }
}