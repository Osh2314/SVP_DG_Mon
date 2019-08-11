using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShop_ObjectBtn : MonoBehaviour
{
    public GameObject obj;

    public void GiveObjectToPlayer() {
        Player player = GameManager.Instance.player.GetComponent<Player>();
        player.setTrueInstallMode(obj);
    }
}
