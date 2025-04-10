using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private float detectionDistance;
    [SerializeField] private LayerMask mask;

    PlayerUI playerUI;
    InputManager inputManager;
    bool isInteracting;

    private void Start()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();

        inputManager.PlayerInput.Character.Interact.performed += HoldInteractPerformed;
        inputManager.PlayerInput.Character.Interact.canceled += HoldInteractCanceled;
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);
        
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * detectionDistance, Color.red);
        RaycastHit hit;
        
        if (!Physics.Raycast(ray, out hit, detectionDistance, mask)) return;

        if (!hit.collider.TryGetComponent(out Interactable interactable)) return;

        playerUI.UpdateText(interactable.PromptMessage);
        
        if (!interactable.HoldToInteract)
        {
            if (inputManager.PlayerInput.Character.Interact.triggered)
            {
                interactable.BaseInteract();
            }
        }        
        else if (interactable.HoldToInteract)
        {
            if (isInteracting)
            {
                interactable.BaseHoldInteract(inputManager.CharacterActions.AddInteract.ReadValue<Vector2>());
            }
        }

    }

    private void HoldInteractPerformed(InputAction.CallbackContext context)
    {
        isInteracting = true;
    }

    private void HoldInteractCanceled(InputAction.CallbackContext context)
    {
        isInteracting = false;
    }
   
}
