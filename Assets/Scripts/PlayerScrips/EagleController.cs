using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{

    public PlayerMove playerMove;

    
    public Transform Player;
    public float eagleSpeed = 5.0f, MoveSpeed = 3.0f;

    void Update()
    {
        if (playerMove.eagleAttack == true)
        {
            gameObject.transform.SetParent(null);
            StartCoroutine(EagleAttacks());
        }
    }

   IEnumerator EagleAttacks()
    {
       Vector3 startPos = transform.position;
       Vector3 targetPos = Player.position;
        targetPos.y += 1;
        transform.LookAt(targetPos);
        float t = 0;

        while (transform.position.z > Player.position.z)
        {
            t += Time.deltaTime * eagleSpeed;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }
        Player.SetParent(this.gameObject.transform);

        startPos = transform.position;
        targetPos = transform.position;
        targetPos.z -= 5;

        while (transform.position.z > transform.position.z - 5)
        {
            t += Time.deltaTime * eagleSpeed;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        playerMove.score.CheckHighScore();

        yield return null;
    }
}
