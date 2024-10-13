using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBotMap : MonoBehaviour
{
    public List<BotMap> BotMaps;
    public void Clear()
    {
        for (int i = 0; i < BotMaps.Count; i++)
        {
            PlayerPrefs.SetInt(BotMaps[i].NameMap, 0);
        }
    }
}
