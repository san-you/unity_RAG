using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float destroy_time = 1f;
    private float time = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > destroy_time)
        {
            Destroy(this.gameObject);
        }
    }
}
