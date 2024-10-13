using UnityEngine;
public class PlayerCharacteristic : MonoBehaviour
{
    public static PlayerCharacteristic instance;
    private int Coins = 0;
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

    public int CurrentCoins() { return Coins; }
    public void AddCoins(int value)
    {
        Coins += value;
        PlayerUI.instance.UIUpdate(Coins);
    }
    public void TakeCoins(int value)
    {
        Coins -= value;
        PlayerUI.instance.UIUpdate(Coins);
    }
}
