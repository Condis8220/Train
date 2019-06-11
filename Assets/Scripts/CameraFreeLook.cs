using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeLook : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    [Header("Rotate")]
    public float speedRotate = 10;
    public float minY;
    public float maxY;

    public float distanceFromTarget = 3;

    private float inputX;
    private float inputY;

    private float smoothTime = 0.1f;
    private Vector3 currentRotation;
    private Vector3 currentVelocity;

    private void LateUpdate()
    {
        inputX += Swipe.Instance.Delta.x * speedRotate;
        inputY -= Swipe.Instance.Delta.y * speedRotate;
        inputY = Mathf.Clamp(inputY, minY, maxY);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(inputY, inputX), ref currentVelocity, smoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = (player.position + offset) - transform.forward * distanceFromTarget;
    }
}
