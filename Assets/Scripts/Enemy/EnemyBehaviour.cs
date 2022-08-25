using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private void HurtPlayer(PlayerLife player)
    {
        player.GetHurt();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerLife player = collision.gameObject.GetComponent<PlayerLife>();

        if (player != null)
        {
            HurtPlayer(player);
        }
    }
}
