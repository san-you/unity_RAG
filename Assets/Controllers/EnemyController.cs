using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    GameObject player;
    GameObject enemy;
    float speed;
    float HP;
    GameObject soundManager;
    SoundManager SM;

    void Start () 
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        speed = 0.3f;
        HP = 2f;

        soundManager = GameObject.Find("SoundManager");
        SM = soundManager.GetComponent<SoundManager>();
    }
	
	void Update () 
    {
        Vector3 myVector = ((player.transform.position - this.transform.position).normalized)*speed;
        transform.position += new Vector3(myVector.x,0,myVector.z);
        transform.LookAt(myVector);
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            SM.playHitSE();
            Destroy(collision.gameObject);
            HP = HP - 1f;
        }

        if( HP < 1)
        {
            Destroy(this.gameObject); 
        }
    }
}
