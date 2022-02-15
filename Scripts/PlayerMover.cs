using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Vector2 position, com_Position;
    Vector3 first_position;
    Quaternion first_rotation;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject player;
    void Start()
    {
        mainCamera = Camera.main;
        position = com_Position = Vector2.zero;
        first_position = mainCamera.transform.position;
        first_rotation = mainCamera.transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Down();
        }
        else if (Input.GetMouseButton(0))
        {
            Moved(Input.mousePosition);
        }
    }
    void Down()
    {
        first_position = mainCamera.transform.position;
        first_rotation = mainCamera.transform.rotation;
        position = Input.mousePosition;
    }

    void Moved(Vector2 touchPosition)
    {
        com_Position = touchPosition;
        mainCamera.transform.RotateAround(player.transform.position, Vector3.up, (position.x - com_Position.x) / 10);
        float angle = (position.y - com_Position.y) / 10;
        mainCamera.transform.Rotate(Vector3.left, angle);
        player.transform.Rotate(Vector3.up, (position.x - com_Position.x) / 10);
        position = com_Position;
    }

    void Up()
    {

    }
}
