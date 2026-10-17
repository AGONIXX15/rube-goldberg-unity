using UnityEngine;

// La cámara se queda quieta y solo gira para mirar siempre al objetivo.
public class CameraLookAt : MonoBehaviour
{
    public Transform objetivo;

    void LateUpdate()
    {
        if (objetivo != null) transform.LookAt(objetivo);
    }
}
