using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CargoController.Instance.CurrentStation = this;
    }

    private void OnTriggerExit(Collider other)
    {
        CargoController.Instance.CurrentStation = null;
    }
}
