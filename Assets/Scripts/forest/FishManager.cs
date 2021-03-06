﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour {
    public float thrust=500;         //力道
    public Rigidbody2D rb;
    public int i=1;                  //方向
    public bool trigger = false;           //是否触发
    public GameObject BigFish;            //大鱼

    private PlayerController playCtrl;

    void Start () {
        rb = GetComponent<Rigidbody2D>();

        playCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        trigger = BigFish.GetComponent<BigFishManager>().trigger;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (trigger)
        {
            if (collision.gameObject.tag == "RiverBottom")
            {
                float i1 = Random.Range(0.9f, 1.1f);
                float i2 = Random.Range(0.9f, 1.1f);
                rb.AddForce(transform.up * thrust * i1);
                rb.AddForce(transform.right * thrust * i * i2);
                i = -i;
            }
            else if (collision.gameObject.tag == "Player")
            {
                //触发公主死亡
                playCtrl.Death();
            }
        }
    }
   



}
