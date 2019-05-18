using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

    public static string nowTime;
    float countTime = 0.0f;
    int minutes = 0;

	void Start ()
    {
		
	}

    void Update()
    {
        GetComponent<Text>().text = minutes.ToString().PadLeft(2, '0') + ":" + countTime.ToString("F0").PadLeft(2, '0');
        nowTime = minutes.ToString().PadLeft(2, '0') + ":" + countTime.ToString("F0").PadLeft(2, '0');
        countTime += Time.deltaTime;

        if(countTime > 59 )
        {
            minutes++;
            countTime = 0.0f;
        }

    }

    public static string getClearTime()
    {
        return nowTime;
    }

}
