using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject player; // ��� ������ ������
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
