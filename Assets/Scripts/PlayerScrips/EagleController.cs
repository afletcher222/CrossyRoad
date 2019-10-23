using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{

    public PlayerMove player;

    
    Transform tr_Player;
    public float eagleSpeed = 3.0f, MoveSpeed = 3.0f;

    void Update()
    {
        if (player.eagleAttack == true)
        {
            gameObject.transform.SetParent(null);
            EagleAttacks();
        }
    }

    void EagleAttacks()
    {


        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position)
                                       , eagleSpeed * Time.deltaTime);

        transform.position += transform.forward * eagleSpeed * Time.deltaTime;

    }
}
