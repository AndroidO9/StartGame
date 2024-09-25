using UnityEngine;

public class Bot : MonoBehaviour
{
	public CardsObject NewCard1, NewCard2, NewCard3;
	public GameObject Shop, MoyCards, Pered, PeredP, kard, BotMap, GM;
	public int coin;
	public float timeS, time;
	public float NtimeS, Ntime;
	public float HP;
	public bool stop;
	void Update()
	{
		if(HP <= 0)
		{
			stop = true;
			BotMap.GetComponent<BotMap>().Win();
			BotMap = null;
			NewCard1 = null;
			NewCard2 = null;
			NewCard3 = null;
		}
		time -= Time.deltaTime;
		if(time <= 0 && !stop)
		{
			time = timeS;
			coin++;
			Kards();
		}
		Ntime -= Time.deltaTime;
		if (Ntime <= 0 && !stop)
		{
			Ntime = NtimeS;
			int c = UnityEngine.Random.Range(1, 4);
			GameObject Kard = Instantiate(kard, MoyCards.transform);
			Kard.GetComponent<CardScriptableObject>().Pered = PeredP;
			Kard.GetComponent<CardScriptableObject>().PeredBot = Pered;
			Kard.GetComponent<CardScriptableObject>().bot = this;
			Kard.GetComponent<CardScriptableObject>().GM = GM.GetComponent<GameCardList>();
			switch (c)
			{
				case 1:
					Kard.GetComponent<CardScriptableObject>().attackDamage = NewCard1.attackDamage;
					Kard.GetComponent<CardScriptableObject>().health = NewCard1.health;
					Kard.GetComponent<CardScriptableObject>().price = NewCard1.price;
					Kard.GetComponent<CardScriptableObject>().word = NewCard1.word;
					Kard.GetComponent<CardScriptableObject>().description = NewCard1.description;
					Kard.GetComponent<CardScriptableObject>().Stime = NewCard1.time;
					break;
				case 2:
					Kard.GetComponent<CardScriptableObject>().attackDamage = NewCard2.attackDamage;
					Kard.GetComponent<CardScriptableObject>().health = NewCard2.health;
					Kard.GetComponent<CardScriptableObject>().price = NewCard2.price;
					Kard.GetComponent<CardScriptableObject>().word = NewCard2.word;
					Kard.GetComponent<CardScriptableObject>().description = NewCard2.description;
					Kard.GetComponent<CardScriptableObject>().Stime = NewCard2.time;
					break;
				case 3:
					Kard.GetComponent<CardScriptableObject>().attackDamage = NewCard3.attackDamage;
					Kard.GetComponent<CardScriptableObject>().health = NewCard3.health;
					Kard.GetComponent<CardScriptableObject>().price = NewCard3.price;
					Kard.GetComponent<CardScriptableObject>().word = NewCard3.word;
					Kard.GetComponent<CardScriptableObject>().description = NewCard3.description;
					Kard.GetComponent<CardScriptableObject>().Stime = NewCard3.time;
					break;
			}
		}
	}
	void Kards()
	{
		int x = UnityEngine.Random.Range(0, 1);
		if(MoyCards.transform.childCount >= 4)
		{
			x = 0;
		}
		else if(MoyCards.transform.childCount == 0)
		{
			x = 1;
		}
		Debug.Log(x.ToString());
		if (x == 0)
		{
			int y = Random.Range(0, MoyCards.transform.childCount);
			for (int i = 0; i < MoyCards.transform.childCount; i++)
			{
				if (MoyCards.transform.GetChild(y).gameObject.GetComponent<CardScriptableObject>().price <= coin)
				{
					coin -= MoyCards.transform.GetChild(y).gameObject.GetComponent<CardScriptableObject>().price;
					MoyCards.transform.GetChild(y).SetParent(Pered.transform.GetChild(0).transform);
					Debug.Log("Скинул карту");
					break;
				}
			}
		}
		else if (x == 1)
		{
			int h = Random.Range(0, Shop.transform.childCount);
			for (int i = 0; i < Shop.transform.childCount; i++)
			{
				if (Shop.transform.GetChild(h).gameObject.GetComponent<KardsShop>().price <= coin)
				{
					coin -= Shop.transform.GetChild(h).gameObject.GetComponent<KardsShop>().price;
					Shop.transform.GetChild(h).gameObject.GetComponent<KardsShop>().Shop(MoyCards);
					Debug.Log("Взял карту");
					break;
				}
			}
		}
	}
}
