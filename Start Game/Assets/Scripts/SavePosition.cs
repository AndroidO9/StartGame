using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("SavePositionX") && PlayerPrefs.HasKey("SavePositionY") && PlayerPrefs.HasKey("SavePositionZ"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("SavePositionX"), PlayerPrefs.GetFloat("SavePositionY"), PlayerPrefs.GetFloat("SavePositionZ"));
        }
        else
        {
            PlayerPrefs.SetFloat("SavePositionX", transform.position.x);
            PlayerPrefs.SetFloat("SavePositionY", transform.position.y);
            PlayerPrefs.SetFloat("SavePositionZ", transform.position.z);
        }
    }
	public void Button()
	{
		if (PlayerPrefs.HasKey("SavePositionX") && PlayerPrefs.HasKey("SavePositionY") && PlayerPrefs.HasKey("SavePositionZ"))
        {
			PlayerPrefs.SetFloat("SavePositionX", transform.position.x);
			PlayerPrefs.SetFloat("SavePositionY", transform.position.y);
			PlayerPrefs.SetFloat("SavePositionZ", transform.position.z);
		}
	}
}
