using UnityEngine;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    public PlayerInput PlayerInput { get => playerInput; }

    private PlayerInput.CharacterActions characterActions;
    public PlayerInput.CharacterActions CharacterActions { get => characterActions; }

    private PlayerLook playerLook;

    private void Awake()
    {
        playerInput = new PlayerInput();
        characterActions = playerInput.Character;
        
        playerLook = GetComponent<PlayerLook>();
    }

    private void LateUpdate()
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
