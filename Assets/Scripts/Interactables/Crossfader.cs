using System.Runtime.CompilerServices;
using UnityEngine;

public class Crossfader : Interactable
{

    [SerializeField] private float slideSpeed;
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;
    [SerializeField] private Transform centrePos;
    [SerializeField] private GameObject crossFaderKnob;
    
    protected override void HoldInteract(Vector2 input)
    {
        if (input.magnitude >= 0)
        {
            Debug.Log("XInput: " + input.x + " YInput: " + input.y);
        }
    }
}
