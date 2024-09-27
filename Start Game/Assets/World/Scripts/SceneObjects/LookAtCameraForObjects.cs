using UnityEngine;
public class LookAtCameraForObjects : MonoBehaviour
{
    private void FixedUpdate()
    {
         gameObject.transform.LookAt(Camera.main.transform);
    }
}
