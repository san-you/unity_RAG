using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTimeController : MonoBehaviour
{
    string clearTime;
    // Start is called before the first frame update
    void Start()
    {
        clearTime = TimerController.getClearTime();
        this.gameObject.GetComponent<Text>().text = "ClearTime : " +clearTime;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
