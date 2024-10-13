using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public GameObject GM;
    void Update()
    {
        if(GM.GetComponent<GameCardList>())
        {
            gameObject.GetComponent<Image>().fillAmount = GM.GetComponent<GameCardList>().HP / 100;
        }
        else if(GM.GetComponent<Bot>())
        {
			gameObject.GetComponent<Image>().fillAmount = GM.GetComponent<Bot>().HP / 100;
		}
    }
}
