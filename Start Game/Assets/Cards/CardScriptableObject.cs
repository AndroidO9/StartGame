using System;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class CardScriptableObject : MonoBehaviour
{
    
    [SerializeField] int attackDamage, health , price;
    [SerializeField] string word, description;
    [SerializeField] Text WordText, DescriptionText, AttackValueText, HealthNumderText, PriceText;
    [SerializeField] bool IsActive;
    private void AppearanceInHand()
    {

    }
    private void AppearanceOnTable()
    {

    }
    private void Awake()
    {
        WordText.text = word;
        DescriptionText.text = description;
        AttackValueText.text = attackDamage.ToString();
        HealthNumderText.text = health.ToString();
        PriceText.text = price.ToString();
    }
}
