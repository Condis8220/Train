using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform camFixedPosition;
    public CameraFreeLook camObject;

    private enum EnTypeCamera
    {
        FIXED,
        FREE_LOOK
    }
    private EnTypeCamera typeCamera = EnTypeCamera.FIXED;

    public Button buttonChangeCamera;

    private void Start()
    {
        buttonChangeCamera.onClick.AddListener(ButtonChangeCamera);
    }

    private void ButtonChangeCamera()
    {
        typeCamera = typeCamera == EnTypeCamera.FIXED ? EnTypeCamera.FREE_LOOK : EnTypeCamera.FIXED;

        if (typeCamera == EnTypeCamera.FIXED)
        {
            camObject.transform.parent = camFixedPosition;
            camObject.transform.localPosition = Vector3.zero;
            camObject.transform.localEulerAngles = Vector3.zero;
            camObject.enabled = false;
        }
        else
        {
            camObject.transform.parent = null;
            camObject.enabled = true;
        }
    }
}
