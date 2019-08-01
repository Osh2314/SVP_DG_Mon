using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public GameObject Enemy;

    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Enemy.gameObject.transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
     //   Debug.Log(collision.gameObject.name + "발견");
        if (collision.gameObject.tag == "Player"&& enemy.state == global::Enemy.State.MOVE || collision.gameObject.tag == "Core" && enemy.state == global::Enemy.State.MOVE)
        {
            enemy.StartCoroutine(enemy.State_Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("Exit");
        if ((collision.gameObject.tag == "Player" && enemy.state == global::Enemy.State.ATTACK || collision.gameObject.tag == "Core") && enemy.state == global::Enemy.State.ATTACK)
        {
            enemy.StartCoroutine(enemy.State_Move());
        }
    }
}
