using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perexod : MonoBehaviour
{
	public Material V, O;
    public GameObject Kard;
	public Camera Cam;
	public GameObject GM;
	void Update()
	{
		Ray Ray = Cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			Physics.Raycast(Ray, out hit);
			if(Kard != null)
			{
				if (hit.collider.gameObject.name == "Stol")
				{
					Kard.GetComponent<MeshRenderer>().material = O;
					Kard = null;
				}
				else if (hit.collider.gameObject.name == "Kards(Clone)" && !hit.collider.gameObject.GetComponent<KardsShop>())
				{
					Kard.GetComponent<MeshRenderer>().material = O;
					Kard = hit.collider.gameObject;
					Kard.GetComponent<MeshRenderer>().material = V;
				}
				else if (hit.collider.gameObject.name == "Pered")
				{
					if (GM.GetComponent<Coin>().coin >= Kard.GetComponent<CardScriptableObject>().price)
					{
						GM.GetComponent<Coin>().coin -= Kard.GetComponent<CardScriptableObject>().price;
						Kard.gameObject.transform.SetParent(hit.collider.transform.GetChild(0));
						Kard.GetComponent<MeshRenderer>().material = O;
						Kard = null;
					}
				}
			}
			else
			{
				if (hit.collider.gameObject.name == "Kards(Clone)" && !hit.collider.gameObject.GetComponent<KardsShop>())
				{
					Kard = hit.collider.gameObject;
					Kard.GetComponent<MeshRenderer>().material = V;
				}
			}
		}
	}
}
