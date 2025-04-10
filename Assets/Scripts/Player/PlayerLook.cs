using UnityEngine;
public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private float xSensitivity = 30f;
    [SerializeField] private float ySensitivity = 30f;

    private float xRotation = 0f;

    public void ProcessLook(Vector2 input)
    {
        float rotInputX = input.x;
        float rotInputY = input.y;

        //Calculate camera rotation for looking up and down
        xRotation -= (rotInputY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //Apply vertical rotation to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Rotate player to look left and right
        transform.Rotate(Vector3.up * rotInputX * Time.deltaTime * xSensitivity);
    }
}
