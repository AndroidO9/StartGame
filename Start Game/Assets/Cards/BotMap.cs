using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMap : MonoBehaviour
{
	public CardsObject NewCard1, NewCard2, NewCard3;
	public GameObject GM, bot;
	public string NameMap;
	public bool BWin;
	public Camera Mcam, Pcam;
	public GameObject Perexod;
	private void Start()
	{
		if(PlayerPrefs.HasKey(NameMap))
		{
			if(PlayerPrefs.GetInt(NameMap) == 1)
			{
				Perexod.SetActive(false);
				BWin = true;
				GM.GetComponent<GameCardList>().GameCards.Add(NewCard1);
				GM.GetComponent<GameCardList>().GameCards.Add(NewCard2);
				GM.GetComponent<GameCardList>().GameCards.Add(NewCard3);
			}
		}
		else
		{
			PlayerPrefs.SetInt(NameMap, 0);
		}
	}
	public void Win()
	{
		Debug.Log("ggg");
		GM.GetComponent<GameCardList>().GameCards.Add(NewCard1);
		GM.GetComponent<GameCardList>().GameCards.Add(NewCard2);
		GM.GetComponent<GameCardList>().GameCards.Add(NewCard3);
		PlayerPrefs.SetInt(NameMap, 1);
		bot.SetActive(false);
		Pcam.gameObject.SetActive(false);
		Mcam.gameObject.SetActive(true);
		BWin = true;
		Perexod.SetActive(false);
	}
	public void Button()
	{
		if (!BWin)
		{
			bot.SetActive(true);
			bot.GetComponent<Bot>().timeS = 2.5f;
			bot.GetComponent<Bot>().NtimeS = 30f;
			bot.GetComponent<Bot>().coin = 0;
			bot.GetComponent<Bot>().stop = false;
			bot.GetComponent<Bot>().BotMap = gameObject;
			bot.GetComponent<Bot>().HP = 100;
			bot.GetComponent<Bot>().NewCard1 = NewCard1;
			bot.GetComponent<Bot>().NewCard2 = NewCard2;
			bot.GetComponent<Bot>().NewCard3 = NewCard3;
			Perexod.SetActive(true);
			Mcam.gameObject.SetActive(false);
			Pcam.gameObject.SetActive(true);
			GM.GetComponent<GameCardList>().BattalStart();
		}
	}
}
