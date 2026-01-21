using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintSpeed = 7.5f;

    private InputAction moveAction;
    private InputAction sprintAction;
    private InputActionAsset inputActionAsset;

    void Start()
    {
        inputActionAsset = GetComponent<PlayerInput>().actions;
        moveAction = inputActionAsset.FindAction("Move");
        sprintAction = inputActionAsset.FindAction("Sprint");
    }

    void Update()
    {
        float speed = moveSpeed;
        if (sprintAction.IsPressed())
        {
            speed = sprintSpeed;
        }
    
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, input.y, 0) * speed * Time.deltaTime;
        transform.Translate(move);
    }
}