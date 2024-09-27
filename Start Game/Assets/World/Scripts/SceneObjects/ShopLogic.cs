using UnityEngine;
using UnityEngine.UI;
public class ShopLogic : MonoBehaviour
{
    [SerializeField] private Material ShopZoneNeggative, ShopZonePositive;
    [SerializeField] private Text ShopButtonText;
    [SerializeField] private GameObject ShopZone, ShopInterface,ShopWorldUI;
    [SerializeField] private PlayerMovement PlayerGameObject;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ShopZone.GetComponent<MeshRenderer>().material = ShopZonePositive;
            ShopButtonText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ShopZone.GetComponent<MeshRenderer>().material = ShopZoneNeggative;
            ShopButtonText.gameObject.SetActive(false);
            PlayerGameObject.CanMoove = true;
            ShopInterface.SetActive(false);
            ShopWorldUI.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerGameObject.CanMoove)
            {
                PlayerGameObject.CanMoove = false;
                ShopInterface.SetActive(true);
                ShopWorldUI.SetActive(false);

            }
            else
            {
                PlayerGameObject.CanMoove = true;
                ShopInterface.SetActive(false);
                ShopWorldUI.SetActive(true);
            }
        }
    }
}
