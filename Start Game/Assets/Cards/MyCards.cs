using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCards : MonoBehaviour
{
    public List<GameObject> MCards;
	private void Update()
	{
		MCards.Clear();
		foreach(Transform t in transform)
		{
			MCards.Add(t.gameObject);
		}
		gameObject.transform.position = new Vector3((2.1f * MCards.Count)/2, 1f, gameObject.transform.position.z);
		for (int i = 0; i < MCards.Count; i++)
		{
			MCards[i].transform.position = new Vector3(2.1f * i-transform.position.x+1,1, gameObject.transform.position.z);
		}
	}
}
