using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentLocation : MonoBehaviour
{

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            player.transform.SetParent(this.transform);
        }
    }
}
