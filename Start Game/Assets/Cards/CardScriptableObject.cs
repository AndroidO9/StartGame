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
    public float time;
    public Bot bot;
    public GameCardList GM;
    public int index; 
    public int indexDopol; 
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
		if (index == 0)
		{
			if (attackDamage != 0)
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
		else if (index == 1)
		{
			switch (indexDopol)
			{
				case 0:
					if (gameObject.transform.parent == Pered.transform)
					{
						int x = UnityEngine.Random.Range(0, PeredBot.transform.childCount);
						PeredBot.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().time += 3f;
						PeredBot.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						int x = UnityEngine.Random.Range(0, Pered.transform.childCount);
						Pered.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().time += 3f;
						Pered.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
					}
					break;
				case 1:
					if (gameObject.transform.parent == Pered.transform)
					{
						foreach (Transform t in Pered.transform)
						{
							t.gameObject.GetComponent<CardScriptableObject>().health += 3;
						}
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						foreach (Transform t in PeredBot.transform)
						{
							t.gameObject.GetComponent<CardScriptableObject>().health += 3;
						}
					}
					break;
				case 2:
					if (gameObject.transform.parent == Pered.transform)
					{
						int x = UnityEngine.Random.Range(0, PeredBot.transform.childCount);
						PeredBot.transform.GetChild(x).SetParent(Pered.transform);
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						int x = UnityEngine.Random.Range(0, Pered.transform.childCount);
						Pered.transform.GetChild(x).SetParent(PeredBot.transform);
					}
					break;
				case 3:
					if (gameObject.transform.parent == Pered.transform)
					{
						int x = 100;
						int y = 0;
						for (int i = 0; i < PeredBot.transform.childCount; i++)
						{
							if (PeredBot.transform.GetChild(i).gameObject.GetComponent<CardScriptableObject>().health < x)
							{
								y = i;
								x = PeredBot.transform.GetChild(i).gameObject.GetComponent<CardScriptableObject>().health;
							}
						}
						PeredBot.transform.GetChild(y).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						int x = 100;
						int y = 0;
						for (int i = 0; i < Pered.transform.childCount; i++)
						{
							if (Pered.transform.GetChild(i).gameObject.GetComponent<CardScriptableObject>().health < x)
							{
								y = i;
								x = Pered.transform.GetChild(i).gameObject.GetComponent<CardScriptableObject>().health;
							}
						}
						Pered.transform.GetChild(y).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
					}
					break;
				case 4:
					if (gameObject.transform.parent == Pered.transform)
					{
						bot.HP -= attackDamage;
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						GM.HP -= attackDamage;
					}
					break;
			}
			Destroy(gameObject);
		}
		else if (index == 2)
		{
			switch (indexDopol)
			{
				case 0:
					if (gameObject.transform.parent == Pered.transform)
					{
						foreach (Transform t in Pered.transform)
						{
							t.gameObject.GetComponent<CardScriptableObject>().health += 2;
						}
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						foreach (Transform t in PeredBot.transform)
						{
							t.gameObject.GetComponent<CardScriptableObject>().health += 2;
						}
					}
					break;
				case 1:
					if (gameObject.transform.parent == Pered.transform)
					{
						int x = UnityEngine.Random.Range(0, PeredBot.transform.childCount);
						PeredBot.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().time += 3f;
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						int x = UnityEngine.Random.Range(0, Pered.transform.childCount);
						Pered.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().time += 3f;
					}
					break;
				case 2:
					if (gameObject.transform.parent == Pered.transform)
					{
						int x = UnityEngine.Random.Range(0, PeredBot.transform.childCount);
						PeredBot.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						int x = UnityEngine.Random.Range(0, Pered.transform.childCount);
						Pered.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
					}
					break;
				case 3:
					if (gameObject.transform.parent == Pered.transform)
					{
						int x = UnityEngine.Random.Range(0, Pered.transform.childCount);
						Pered.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().attackDamage += attackDamage;
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						int x = UnityEngine.Random.Range(0, PeredBot.transform.childCount);
						PeredBot.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().attackDamage += attackDamage;
					}
					break;
			}
			Destroy(gameObject);
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
