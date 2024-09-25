using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
	[SerializeField] public int coin;
	[SerializeField] private float ST;
	[SerializeField] public float T;
	[SerializeField] private Text text;
	void Update()
	{
		text.text = coin.ToString();
		if (coin < 10)
		{
			T -= Time.deltaTime;
			if (T <= 0)
			{
				coin++;
				T = ST;
			}
		}
	}
}
