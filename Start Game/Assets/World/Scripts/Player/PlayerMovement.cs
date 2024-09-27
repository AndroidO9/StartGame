using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent playerNavMeshAgent;
    [SerializeField] private GameObject DestanationGameObject;
    public bool CanMoove = true;
    private void Start()
    {
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(1)&& CanMoove)
        {
            if (hit.collider.tag == "ClickableFloor")
            {
                playerNavMeshAgent.SetDestination(hit.point);
                DestanationGameObject.transform.position = hit.point + new Vector3(0,0.5f,0);
                DestanationGameObject.transform.rotation = hit.collider.gameObject.transform.rotation;
            }
        }
    }
}
