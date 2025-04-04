using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    public PlayerInput PlayerInput { get => playerInput; }

    private PlayerInput.CharacterActions characterActions;
    private PlayerLook playerLook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        characterActions = playerInput.Character;
        
        playerLook = GetComponent<PlayerLook>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerLook.ProcessLook(characterActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        characterActions.Enable();
    }

    private void OnDisable()
    {
        characterActions.Disable();
    }
}
