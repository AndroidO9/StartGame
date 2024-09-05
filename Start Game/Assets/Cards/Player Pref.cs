using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPref : MonoBehaviour
{
    public GameObject K;
    public List<Kards> Kards;
	void Start()
	{
		
	}
}
[SerializeField]
public class Kards
{
    public Text Neme;
    public Text info;
    public Text Damadg;
    public Text Helt;
    public bool On;
}
