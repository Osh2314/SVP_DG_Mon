using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;

    public float speed;
    private bool cMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cMove == true)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    public void SetcMove(bool setMove)
    {
        cMove = setMove;
    }
}
