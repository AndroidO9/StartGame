using System;
using UnityEngine;
public class ShopUILogic : MonoBehaviour
{
    [SerializeField] private GameObject FirstItem;
   public void OnBuyFirstItemButton()
    {
        if (PlayerCharacteristic.instance.CurrentCoins() >= 2)
        {
            PlayerCharacteristic.instance.TakeCoins(2);
            Debug.Log("�� ������ 1");
            FirstItem.SetActive(false);
        }
        else
        {
            Debug.Log("� ��� �� ������� �����");
        }
    }
}
