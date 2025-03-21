using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private float detectionDistance;
    [SerializeField] private LayerMask mask;

    PlayerUI playerUI;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        playerUI = GetComponent<PlayerUI>();
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
            playerUI.UpdateText(hit.collider.GetComponent<Interactable>().promptMessage);
        }
       
    }
}
