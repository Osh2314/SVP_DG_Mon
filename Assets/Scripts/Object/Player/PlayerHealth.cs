using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Hp {
        get {
            return hp;
        }
        set {
            hp = value;
            GameManager.Instance.iBox.slider_PlayerHp.value = hp;
            if (Hp <= 0)
            {
                event_Death();
            }
            Debug.Log(gameObject.name + " hp : "+Hp);
        }
    }

    [SerializeField]
    private int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.iBox.slider_PlayerHp.maxValue = hp;
        GameManager.Instance.iBox.slider_PlayerHp.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void event_Death()
    {
        Destroy(gameObject);
    }
}
