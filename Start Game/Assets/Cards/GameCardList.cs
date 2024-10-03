using System.Collections.Generic;
using UnityEngine;

public class GameCardList : MonoBehaviour
{
    [SerializeField] public List<CardsObject> GameCards = new List<CardsObject>();
    public GameObject Kards;
	public GameObject MoyCards;
	public GameObject MoyCardsBot;
	public GameObject ShopCards;
	public GameObject Pered;
	public GameObject PeredBot;
	public Bot bot;
	public int HP;
	public int VC;
	public bool Shop;
	public void Clear()
    {
		foreach (Transform t in ShopCards.transform)
		{
			Destroy(t.gameObject);
		}
		foreach (Transform t in MoyCards.transform)
		{
			Destroy(t.gameObject);
		}
		foreach (Transform t in MoyCardsBot.transform)
		{
			Destroy(t.gameObject);
		}
		foreach (Transform t in Pered.transform)
		{
			Destroy(t.gameObject);
		}
		foreach (Transform t in PeredBot.transform)
		{
			Destroy(t.gameObject);
		}
	}
	public void BattalStart()
	{
		for (int i = 0; i < VC; i++)
		{
			Creat(MoyCards, false);
		}
		for (int i = 0; i < VC; i++)
		{
			Creat(MoyCardsBot, false);
		}
		gameObject.GetComponent<Coin>().T = 0;
		gameObject.GetComponent<Coin>().coin = 0;
		Shop = true;
	}
	void Creat(GameObject GM, bool Shop)
	{
		int x = Random.Range(0, GameCards.Count);
		for (int j = 0; j < GameCards.Count; j++)
		{
			if (x == j)
			{
				GameObject g = Instantiate(Kards, GM.transform);
				if (!Shop)
				{ 
					Destroy(g.GetComponent<KardsShop>()); 
				} 
				else 
				{  
					g.GetComponent<KardsShop>().coin = gameObject.GetComponent<Coin>();
					g.GetComponent<KardsShop>().MC = MoyCards;
				}
				g.GetComponent<CardScriptableObject>().attackDamage = GameCards[j].attackDamage;
				g.GetComponent<CardScriptableObject>().health = GameCards[j].health;
				g.GetComponent<CardScriptableObject>().price = GameCards[j].price;
				g.GetComponent<CardScriptableObject>().word = GameCards[j].word;
				g.GetComponent<CardScriptableObject>().description = GameCards[j].description;
				g.GetComponent<CardScriptableObject>().Stime = GameCards[j].time;
				g.GetComponent<CardScriptableObject>().index = GameCards[j].index;
				g.GetComponent<CardScriptableObject>().indexDopol = GameCards[j].indexD;
				g.GetComponent<CardScriptableObject>().bot = bot;
				g.GetComponent<CardScriptableObject>().GM = this;
				g.GetComponent<CardScriptableObject>().Pered = Pered;
				g.GetComponent<CardScriptableObject>().PeredBot = PeredBot;
			}
		}
	}
	void Update()
	{
		if (Shop)
		{
			if (ShopCards.transform.childCount < 4)
			{
				int x = 4 - ShopCards.transform.childCount;
				for (int i = 0; i < x; i++)
				{
					Creat(ShopCards, true);
				}
			}
		}
	}
}

