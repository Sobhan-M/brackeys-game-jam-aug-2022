using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
    private PlayerInputActions playerInputActions;
    private int numOfPlayers = 0;

    private DistanceJoint2D joint;
    private PlayerMovement[] players;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        joint = GetComponent<DistanceJoint2D>();
        players = FindObjectsOfType<PlayerMovement>();

        joint.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ++numOfPlayers;

            if (numOfPlayers > 0)
            {
                playerInputActions.Player.Interact.performed += ctx => Interact();
                playerInputActions.Player.Interact.canceled += ctx => Cancel();
                playerInputActions.Enable();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            --numOfPlayers;

            if (numOfPlayers < 1)
            {
                playerInputActions.Disable();
            }
        }

        
    }


    public void Interact()
    {
        for (int i = 0; i < players.Length; ++i)
        {
            if (players[i].enabled)
            {
                joint.connectedBody = players[i].GetComponent<Rigidbody2D>();
                joint.enabled = true;
                return;
            }
        }

    }

    private void Cancel()
    {
        joint.connectedBody = null;
        joint.enabled = false;
    }
}
