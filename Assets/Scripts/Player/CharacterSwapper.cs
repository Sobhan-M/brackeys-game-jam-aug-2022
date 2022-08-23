using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwapper : MonoBehaviour
{
    [SerializeField] GameObject humanCharacter;
    [SerializeField] GameObject dogCharacter;

    private PlayerInputActions playerInputActions;
    private PlayerMovement playerMovement;
    private PlayerMovement petMovement;
    private bool isHumanInControl;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        playerMovement = humanCharacter.GetComponent<PlayerMovement>();
        petMovement = dogCharacter.GetComponent<PlayerMovement>();
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
        isHumanInControl = true;

        playerMovement.enabled = isHumanInControl;
        petMovement.enabled = !isHumanInControl;
    }

    private void SwapCharacter()
    {
        isHumanInControl = !isHumanInControl;

        playerMovement.enabled = isHumanInControl;
        petMovement.enabled = !isHumanInControl;
    }
}
