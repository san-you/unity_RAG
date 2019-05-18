using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    public GameObject Enemy;

    private float appearNextTime = 5f;
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
            AppearEnemy();
        }
    }

    //　ランダムな位置に敵オブジェクトを生成
    void AppearEnemy()
    {
        float x = Random.Range(-80f, 80f);
        float y = 3;
        float z =Random.Range(-80f, 80f);
        Vector3 position = new Vector3(x, y, z);
        Instantiate(Enemy, position, Enemy.transform.rotation);
    }
}
