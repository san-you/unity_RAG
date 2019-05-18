using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionGenerate : MonoBehaviour
{
    public GameObject potion;

    private float appearNextTime = 20f;
    private float time;

    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > appearNextTime)
        {
            time = 0f;
            GeneratePotion();
        }
    }

    // ポーション生成処理
    void GeneratePotion()
    {
        float x = Random.Range(-40f, 40f);
        float y = 1.5f;
        float z = Random.Range(-40f, 40f);
        Vector3 position = new Vector3(x, y, z);
        Instantiate(potion, position, potion.transform.rotation);
    }
}
