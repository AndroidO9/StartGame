using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCards : MonoBehaviour
{
	public List<GameObject> MCards;
	[SerializeField] bool Shop;
	private void Update()
	{
		MCards.Clear();
		foreach(Transform t in transform)
		{
			MCards.Add(t.gameObject);
		}
		if(!Shop)
		{
			gameObject.transform.position = new Vector3((2.1f * MCards.Count) / 2, transform.position.y, transform.position.z);
		}
		else
		{
			gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 2.1f * MCards.Count / 2);
		}
		for (int i = 0; i < MCards.Count; i++)
		{
			if (!Shop)
			{
				MCards[i].transform.position = new Vector3(2.1f * i - transform.position.x + 1, transform.position.y, transform.position.z);
			}
			else
			{
				MCards[i].transform.position = new Vector3(transform.position.x, transform.position.y, 2.1f * i - transform.position.z + 1);
			}
			MCards[i].gameObject.transform.rotation = new Quaternion(Quaternion.identity.x, MCards[i].gameObject.transform.rotation.y, MCards[i].gameObject.transform.rotation.z, MCards[i].gameObject.transform.rotation.w);
		}
	}
}
