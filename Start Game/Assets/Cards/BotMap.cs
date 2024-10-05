using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotMap : MonoBehaviour
{
	[SerializeField] private Text FightName, TextForStart;
	[SerializeField] private Material CompleteTaskMateria;
	[SerializeField] private GameObject CubeCoinObject;
	[SerializeField] private string NameMapString;
	public CardsObject NewCard1, NewCard2, NewCard3;
	public GameObject GM, bot;
	public string NameMap;
	public bool BWin, Boos;
	public Camera Mcam, Pcam;
	public GameObject Perexod;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			TextForStart.gameObject.SetActive(true);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			TextForStart.gameObject.SetActive(false);
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
		{
			Button();
		}
	}
	private void Start()
	{
		FightName.text = NameMap;
		if (PlayerPrefs.HasKey(NameMap))
		{
			if(PlayerPrefs.GetInt(NameMap) == 1)
			{
				Perexod.SetActive(false);
				BWin = true;
				CubeCoinObject.GetComponent<MeshRenderer>().material = CompleteTaskMateria;
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
		GM.GetComponent<GameCardList>().Clear();
		Debug.Log("Победа");
		GM.GetComponent<GameCardList>().GameCards.Add(NewCard1);
		GM.GetComponent<GameCardList>().GameCards.Add(NewCard2);
		GM.GetComponent<GameCardList>().GameCards.Add(NewCard3);
		PlayerPrefs.SetInt(NameMap, 1);
		bot.SetActive(false);
		Pcam.gameObject.SetActive(false);
		Mcam.gameObject.SetActive(true);
		BWin = true;
		Perexod.SetActive(false);
		PlayerCharacteristic.instance.AddCoins(1);
		CubeCoinObject.GetComponent<MeshRenderer>().material = CompleteTaskMateria;
	}
	public void Lose()
    {
		Debug.Log("Поражение");
		GM.GetComponent<GameCardList>().Clear();
		Pcam.gameObject.SetActive(false);
		Mcam.gameObject.SetActive(true);
		Perexod.SetActive(false);
		bot.SetActive(false);
		PlayerPrefs.SetInt(NameMap, 0);
		BWin = false;
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
			if(!Boos)
			{
				bot.GetComponent<Bot>().HP = 100;
			}
			else
			{
				bot.GetComponent<Bot>().HP = 250;
			}
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
