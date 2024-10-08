using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] TextMeshProUGUI uiBullet;

    private void Start()
    {
        SetBullet(uiBullet);

        position = this.gameObject;
        anim = this.GetComponent<Animator>();
        shellCase = this.GetComponentInChildren<ParticleSystem>();


        shakeIntensity = 7f;
        shakeTime = .1f;

        shootSpeed = 25f;
        waitShoot = 1f;
        maxBullet = 6;

        shootPos = transform.Find("shootPos").transform;

        manyBullet = maxBullet;
    }
    private void Update()
    {
        Rotate();
        SetBullet(uiBullet);

        waitShoot -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && manyBullet > 0)
        {
            if (waitShoot <= 0)
            {
                Shoot();

                waitShoot = 1f;
                manyBullet -= 1;
            }
        }
    }
    //Override Reload para recarregar por um tempo e parar no numero que ficou, dependendo de quantas balas tem no invent�rio
}
