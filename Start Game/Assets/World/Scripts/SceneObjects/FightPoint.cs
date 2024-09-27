using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FightPoint : MonoBehaviour
{
    [SerializeField] private Text FightName,TextForStart;
    [SerializeField] private Material CompleteTaskMateria;
    [SerializeField] private GameObject CubeCoinObject;
    private bool IsInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CubeCoinObject.GetComponent<MeshRenderer>().material = CompleteTaskMateria;
            TextForStart.gameObject.SetActive(true);
            IsInTrigger = true;
            PlayerCharacteristic.instance.AddCoins(1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TextForStart.gameObject.SetActive(false);
            IsInTrigger = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" &&  Input.GetKey(KeyCode.E) && IsInTrigger)
        {
            SceneManager.LoadScene(0);
        }
    }
}
