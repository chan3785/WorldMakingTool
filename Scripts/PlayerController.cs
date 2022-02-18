using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float walkSpeed;
    [SerializeField] float lookSensitivity, cameraRotationLimit, currentCameraRotationX;
    [SerializeField]
    Camera theCamera;
    bool isCollied;
    [SerializeField] LayerMask layermask;
    Rigidbody myRigid;
    Vector3 _velocity;
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
        MoveControl();
    }
    public void MoveControl()
    {
        Move();
        StopToWall();
        Freeze();
    }
    void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;
        if (!isCollied)
        {
            myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }
    }
    void StopToWall()
    {
        isCollied = Physics.Raycast(transform.position, _velocity, 1, layermask);
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
    public void InputW()
    {
        Vector3 _velocity = transform.forward * walkSpeed;
        if (!Physics.Raycast(transform.position, _velocity, 1, layermask))
        {
            myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }
    }
    public void InputS()
    {
        Vector3 _velocity = -transform.forward * walkSpeed;
        if (!Physics.Raycast(transform.position, _velocity, 1, layermask))
        {
            myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }
    }
    public void InputA()
    {
        Vector3 _velocity = -transform.right * walkSpeed;
        if (!Physics.Raycast(transform.position, _velocity, 1, layermask))
        {
            myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }
    }
    public void InputD()
    {
        Vector3 _velocity = transform.right * walkSpeed;
        if (!Physics.Raycast(transform.position, _velocity, 1, layermask))
        {
            myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }
    }
}