using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "One", order = 51)]
public class CardsObject : ScriptableObject
{
	[SerializeField] public int attackDamage, health, price, index, indexD;
	[SerializeField] public string word, description;
	[SerializeField] public float time;
	public int Damadg0
	{
		get { return attackDamage; }
	}
	public int Health0
	{
		get { return health; }
	}
	public int Price0
	{
		get { return price; }
	}
	public string Word0
	{
		get { return word; }
	}
	public string Description0
	{
		get { return description; }
	}
	public float Time0
	{
		get { return time; }
	}
	public int Index0
	{
		get { return index; }
	}
	public int IndexD0
	{
		get { return indexD; }
	}
}
