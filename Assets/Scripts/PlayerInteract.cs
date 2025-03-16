using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private float detectionDistance;
    [SerializeField] private LayerMask mask;  
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * detectionDistance, Color.red);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, detectionDistance, mask)) return;

        if (hit.collider.GetComponent<Interactable>() != null)
        {
            Debug.Log(hit.collider.GetComponent<Interactable>().promptMessage);
        }
    }
}
