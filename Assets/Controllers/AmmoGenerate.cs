using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGenerate : MonoBehaviour
{
    public GameObject Ammo;

     private float generate_time = 10f;
    private float time;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > generate_time)
        {
            time = 0f;
            GenerateAmmo();
        }
     }

    // 弾薬をランダムな位置に生成
    void GenerateAmmo()
    {
        float x = Random.Range(-40f, 40f);
        float y = 1.5f;
        float z = Random.Range(-40f, 40f);
        Vector3 position = new Vector3(x, y, z);
        Instantiate(Ammo, position, Ammo.transform.rotation);
    }
}
