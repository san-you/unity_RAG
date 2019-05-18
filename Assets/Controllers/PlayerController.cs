using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;
    private float moveSpeed = 40.0f;

    public GameObject bullet;
    private int Ammo = 30;
    GameObject gameDircior;
    GameObject soundManager;
    SoundManager SM;
    GameObject Muzzle;
    GameObject Gun;
    GameObject AmmoText;
    Vector3 moveForward;


    AudioSource[] audioSource;

    void Start()
    {
        gameDircior = GameObject.Find("GameDirector");
        soundManager = GameObject.Find("SoundManager");
        SM = soundManager.GetComponent<SoundManager>();
        rb = GetComponent<Rigidbody>();
        Muzzle = GameObject.Find("Muzzle");
        Gun = GameObject.Find("Sci-Fi Rifle");
        AmmoText = GameObject.Find("AmmoText");
        audioSource = gameObject.GetComponents<AudioSource>();
    }

    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;
    Vector3 cameraForward;
    private float timeleft;

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定 
        moveForward = cameraForward * inputVertical + cameraRight * inputHorizontal;

        walk();

        if (Input.GetButton("Fire2"))
        {
            aim();
        }
        else
        {
            DisAim();
        }

        if (Input.GetButton("Fire1"))
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0.0)
            {
                shot();
                timeleft = 0.1f;
            }
        }
    }

    void walk()
    {
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameDirector GD = gameDircior.GetComponent<GameDirector>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource[4].Play();
            GD.HpDecreaseHp(10);
            moveSpeed = 60.0f;
            Invoke("stopBoost", 3.0f);
        }

        if (collision.gameObject.CompareTag("Ammo"))
        {
            audioSource[2].Play();
            Ammo = Ammo + 20;
            Destroy(collision.gameObject);
            AmmoText.GetComponent<Text>().text = Ammo.ToString();
        }

        if (collision.gameObject.CompareTag("Potion"))
        {
            audioSource[3].Play();
            GD.HpHeal(30);
            Destroy(collision.gameObject);
        }
    }

    void stopBoost()
    {
        moveSpeed = 40.0f;
    }

    void aim()
    {
        Camera.main.fieldOfView = 30f;
    }

    void DisAim()
    {
        Camera.main.fieldOfView = 70f;
    }

    // 弾丸射出時メソッド
    void shot()
    {
        if (Ammo != 0) Ammo = Ammo - 1;
        AmmoText.GetComponent<Text>().text = Ammo.ToString();
        if (Ammo < 1) return;
        GameObject bullets = Instantiate(bullet) as GameObject;

        audioSource[0].Play();

        bullets.transform.localPosition = Muzzle.transform.position;
        Vector3 force = Camera.main.transform.forward * 500f;
        bullets.GetComponent<Rigidbody>().velocity = force;
        bullets.transform.forward = Camera.main.transform.forward;
    }

}
