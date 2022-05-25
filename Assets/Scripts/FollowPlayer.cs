using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 2, 0);
    public float rotationSensitivity;
    public Vector3 cameraPosition_NOaim;
    public Vector2 cameraInput;
    public Vector2 maxMinRotation;
    public Transform playerTarget;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        Vector3 dir = cameraPosition_NOaim;
        Quaternion rotation = Quaternion.Euler(cameraInput.x, cameraInput.y, 0);
        rotation.x = Mathf.Clamp(rotation.x, -maxMinRotation.x, maxMinRotation.y);
        transform.position = playerTarget.transform.position + rotation * dir;
        transform.LookAt(playerTarget.transform.position);
    }

    void RotateCamera()
    {
        cameraInput.y += Input.GetAxis("Mouse X") * rotationSensitivity;
        cameraInput.x += -Input.GetAxis("Mouse Y") * rotationSensitivity;
        cameraInput.x = Mathf.Clamp(cameraInput.x, -maxMinRotation.x, maxMinRotation.y);
    }

    private void Update()
    {
        RotateCamera();
    }
}
