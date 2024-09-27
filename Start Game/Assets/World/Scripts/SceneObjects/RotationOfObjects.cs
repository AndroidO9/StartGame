using UnityEngine;
public class RotationOfObjects : MonoBehaviour
{
    [SerializeField] private Vector3 SpeedOfRotation;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(SpeedOfRotation);
    }
}
