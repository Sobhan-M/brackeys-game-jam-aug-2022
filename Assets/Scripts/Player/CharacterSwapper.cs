using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwapper : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private PlayerMovement playerMovement;
    private PetMovement petMovement;
    private bool isPlayerInControl;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        playerMovement = FindObjectOfType<PlayerMovement>();
        petMovement = FindObjectOfType<PetMovement>();
    }

    private void OnEnable()
    {
        playerInputActions.Player.SwapCharacter.performed += ctx => SwapCharacter();
        playerInputActions.Player.SwapCharacter.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.SwapCharacter.Disable();
    }

    private void Start()
    {
        isPlayerInControl = true;

        playerMovement.enabled = isPlayerInControl;
        petMovement.enabled = !isPlayerInControl;
    }

    private void SwapCharacter()
    {
        isPlayerInControl = !isPlayerInControl;

        playerMovement.enabled = isPlayerInControl;
        petMovement.enabled = !isPlayerInControl;
    }
}
