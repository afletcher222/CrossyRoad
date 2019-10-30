using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    public PlayerMove playerMove;

    public Transform endLocation;
    public Transform player;
    public float eagleSpeed = 5.0f, MoveSpeed = 3.0f;

    void FixedUpdate()
    {
        if (playerMove.eagleAttack == true)
        {
            playerMove.eagleAttack = false;
            gameObject.transform.SetParent(null);
            endLocation.SetParent(null);
            StartCoroutine(EagleAttacks());
        }
    }

   IEnumerator EagleAttacks()
   {
       Vector3 startPos = transform.position;
       Vector3 targetPos = player.position;
        targetPos.y += 1;
        transform.LookAt(targetPos);
        float t = 0;

        while (transform.position.z > player.position.z)
        {
            t += Time.deltaTime * eagleSpeed;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.SetParent(this.gameObject.transform);

        startPos = transform.position;
        targetPos = endLocation.position;
        t = 0;

        while (transform.position.z > targetPos.z)
        {
            t += Time.deltaTime * eagleSpeed * 2;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        playerMove.score.CheckHighScore();

        yield return null;
   }
}