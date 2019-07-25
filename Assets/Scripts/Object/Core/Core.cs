﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public float knockBackForce = 5;
    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (Hp <= 0)
            {
                event_Death();
            }
            Debug.Log(Hp);
        }
    }

    [SerializeField]
    private int hp = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 knockBackDir=new Vector3(collision.gameObject.transform.position.x-transform.position.x, 0, 0);
            knockBackDir.Normalize();
            rigid.AddForce(knockBackDir*knockBackForce);
        }
    }

    private void event_Death()
    {

    }
}
