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
    public float UItime;
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
		UItime -= Time.deltaTime;
		if(UItime <= 0)
		{
			UItime = 1;
			WordText.text = word;
			DescriptionText.text = description;
			AttackValueText.text = attackDamage.ToString();
			HealthNumderText.text = health.ToString();
			PriceText.text = price.ToString();
		}
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
						if (indexDopol == 0)
						{
							int x = UnityEngine.Random.Range(0, PeredBot.transform.childCount);
							PeredBot.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
						}
						else if(indexDopol == 1)
						{
							foreach (Transform t in PeredBot.transform)
							{
								t.gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
							}
						}
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
						if (indexDopol == 0)
						{
							int x = UnityEngine.Random.Range(0, Pered.transform.childCount);
							Pered.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
						}
						else if (indexDopol == 1)
						{
							foreach (Transform t in Pered.transform)
							{
								t.gameObject.GetComponent<CardScriptableObject>().Dam(attackDamage);
							}
						}
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
					if (gameObject.transform.parent == Pered.transform && PeredBot.transform.childCount != 0)
					{
						int x = UnityEngine.Random.Range(0, PeredBot.transform.childCount);
						PeredBot.transform.GetChild(x).rotation = Pered.transform.rotation;
						PeredBot.transform.GetChild(x).SetParent(Pered.transform);
					}
					else if (gameObject.transform.parent == PeredBot.transform && Pered.transform.childCount != 0)
					{
						int x = UnityEngine.Random.Range(0, Pered.transform.childCount);
						Pered.transform.GetChild(x).rotation = PeredBot.transform.rotation;	
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
			if (gameObject.transform.parent == Pered.transform)
			{
				Destroy(gameObject);
			}
			else if (gameObject.transform.parent == PeredBot.transform)
			{
				Destroy(gameObject);
			}
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
						Pered.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().attackDamage += 2;
					}
					else if (gameObject.transform.parent == PeredBot.transform)
					{
						int x = UnityEngine.Random.Range(0, PeredBot.transform.childCount);
						PeredBot.transform.GetChild(x).gameObject.GetComponent<CardScriptableObject>().attackDamage += 2;
					}
					break;
			}
			if (gameObject.transform.parent == Pered.transform)
			{
				Destroy(gameObject);
			}
			else if (gameObject.transform.parent == PeredBot.transform)
			{
				Destroy(gameObject);
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
	public void UpdateUI()
	{
		WordText.text = word;
		DescriptionText.text = description;
		AttackValueText.text = attackDamage.ToString();
		HealthNumderText.text = health.ToString();
		PriceText.text = price.ToString();
	}
}
