using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    GameObject HpImage;
    GameObject Message;
    GameObject HPText;

    float nowTime;
    int HP = 100;

    private float nextDamageTime = 2f;
    private float time;

    void Start () 
    {
        HpImage = GameObject.Find("HPImage");
        Message = GameObject.Find("Message");
        HPText = GameObject.Find("HPText");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		
	}
	
	void Update () 
    {
        time += Time.deltaTime;

        if (time > nextDamageTime)
        {
            time = 0f;
            HP = HP - 1;
            HPText.GetComponent<Text>().text = "HP" + HP;
            HpImage.GetComponent<Image>().fillAmount -= 0.01f;
        }

        if (HP < 1)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
	}

    // HP減少処理
    public void HpDecreaseHp(float Damage)
    {
        HP = HP - (int)Damage;
        Damage = Damage * 0.01f;
        HpImage.GetComponent<Image>().fillAmount -= Damage;
        Message.GetComponent<Text>().text = "Damage!!";
        HPText.GetComponent<Text>().text = "HP"+HP;

        Invoke("deleteMessage", 1.0f);
    }

    // HP増加処理
    public void HpHeal(float Heal)
    {
        if (HP > 99) return;
        HP = HP + (int)Heal;
        if (HP > 99) HP = 100;
        Heal = Heal * 0.01f;
        if(HpImage.GetComponent<Image>().fillAmount != 1f) HpImage.GetComponent<Image>().fillAmount += Heal;

        Message.GetComponent<Text>().text = "Heal!!";
        HPText.GetComponent<Text>().text = "HP" + HP;

        Invoke("deleteMessage", 1.0f);
    }


    public void deleteMessage() 
    {
        Message.GetComponent<Text>().text = "";
    }
}
