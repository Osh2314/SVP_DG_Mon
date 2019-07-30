using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Enemy.gameObject.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
     //   Debug.Log(collision.gameObject.name + "발견");
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Core")
        {
            Enemy enemy = GetComponentInParent<Enemy>();
            enemy.StartCoroutine(enemy.State_Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("Exit");
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Core")
        {
            Enemy enemy = GetComponentInParent<Enemy>();
            enemy.StartCoroutine(enemy.State_Move());
        }
    }
}
