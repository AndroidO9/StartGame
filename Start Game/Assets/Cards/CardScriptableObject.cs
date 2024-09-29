using System;
using UnityEngine;
using UnityEngine.UI;

public class CardScriptableObject : MonoBehaviour
{
    public GameObject Pered, PeredBot;
    [SerializeField] public int attackDamage, health , price;
    [SerializeField] public float Stime;
    [SerializeField] public string word, description;
    [SerializeField] public Text WordText, DescriptionText, AttackValueText, HealthNumderText, PriceText;
    float time;
    public Bot bot;
    public GameCardList GM;
    private void Start()
    {
        WordText.text = word;
        DescriptionText.text = description;
        AttackValueText.text = attackDamage.ToString();
        HealthNumderText.text = health.ToString();
        PriceText.text = price.ToString();
    }
	private void Update()
	{
        if(attackDamage != 0)
        {
			time -= Time.deltaTime;
		}
        if (time <= 0)
        {
            time = Stime;
            if (gameObject.transform.parent == Pered.transform)
            {
				if (PeredBot.transform.childCount == 0)
				{
					bot.HP -= attackDamage;
				}
				else
				{
					int x = UnityEngine.Random.Range(0, PeredBot.transform.childCount);
					PeredBot.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
				}
			}
            else if (gameObject.transform.parent == PeredBot.transform)
            {
                if (Pered.transform.childCount == 0)
                {
                    GM.HP -= attackDamage;
                }
                else
                {
                    int x = UnityEngine.Random.Range(0, Pered.transform.childCount);
                    Pered.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
                }
			}
		}
	}
    public void Dam(int D)
    {
        health -= D;
        if(health <= 0)
        {
            Destroy(gameObject);
		}
		HealthNumderText.text = health.ToString();
	}
}
