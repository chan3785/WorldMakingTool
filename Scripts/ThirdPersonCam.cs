using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform target;
    public float dist = 5f;
    public float xSpeed = 220f, ySpeed = 100f;
    float x = 0f, y = 0f;

    public float yMinLimit = -20f, yMaxLimit = 80f;

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
    Transform cam;
    void Start()
    {
        cam = GetComponent<Transform>();
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        if (target)
        {
            dist -= 0.5f * Input.mouseScrollDelta.y;
            if (dist < 0.5f)
                dist = 0f;
            if (dist >= 10)
                dist = 10f;
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0f);
            Vector3 position = rotation * new Vector3(0f, 0.0f, -dist) + target.position + new Vector3(0.0f, 0f, 0.0f);

            transform.rotation = rotation;
            transform.position = position;
        }
    }

}