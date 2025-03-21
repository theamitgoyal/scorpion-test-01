using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private float detectionDistance;
    [SerializeField] private LayerMask mask;

    PlayerUI playerUI;
    PlayerInput playerInput;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        playerUI = GetComponent<PlayerUI>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);
        
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * detectionDistance, Color.red);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, detectionDistance, mask)) return;
       

        if (hit.collider.GetComponent<Interactable>() != null)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();           
            playerUI.UpdateText(interactable.promptMessage);
            if (playerInput.actions["Interact"].triggered)
            {
                interactable.BaseInteract();
            }
        }
       
    }
}
