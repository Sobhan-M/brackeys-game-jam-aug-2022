using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CharacterSwapper : MonoBehaviour
{
    [SerializeField] GameObject humanCharacter;
    [SerializeField] GameObject dogCharacter;

    private PlayerInputActions playerInputActions;
    private PlayerMovement humanMovement;
    private PlayerMovement dogMovement;
    private bool isHumanInControl;

    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        humanMovement = humanCharacter.GetComponent<PlayerMovement>();
        dogMovement = dogCharacter.GetComponent<PlayerMovement>();

        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
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

        humanMovement.enabled = isHumanInControl;
        dogMovement.enabled = !isHumanInControl;
    }

    private void SwapCharacter()
    {
        isHumanInControl = !isHumanInControl;

        humanMovement.enabled = isHumanInControl;
        dogMovement.enabled = !isHumanInControl;

        if (isHumanInControl)
        {
            virtualCamera.Follow = humanCharacter.transform;
        }
        else
        {
            virtualCamera.Follow = dogCharacter.transform;
        }
    }
}
