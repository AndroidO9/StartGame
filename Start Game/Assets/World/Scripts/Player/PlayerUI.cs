using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;
    [SerializeField] private Text CoinsText;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        
    }
    void LateUpdate()
    {
        UIUpdate(PlayerCharacteristic.instance.CurrentCoins());
    }


    public void UIUpdate(int NewCoins)
    {
        CoinsText.text = "Монеты:" + NewCoins;
    }
}
