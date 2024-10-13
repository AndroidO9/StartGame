using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KardsShop : MonoBehaviour
{
	public int price;
	public Coin coin;
	public GameObject MC;
	void Start()
	{
		price = gameObject.GetComponent<CardScriptableObject>().price;
	}
	void OnMouseDown()
	{
		if (coin.coin >= price)
		{
			coin.coin -= price;
			Shop(MC);
		}
	}
	public void Shop(GameObject g)
	{
		gameObject.transform.SetParent(g.transform);
		gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
		Destroy(gameObject.GetComponent<KardsShop>());
	}
}
