using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintSpeed = 7.5f;

    private Interact[] interacts = new Interact[0];

    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction interactAction;
    private InputActionAsset inputActionAsset;

    private void Start()
    {
        inputActionAsset = GetComponent<PlayerInput>().actions;
        moveAction = inputActionAsset.FindAction("Move");
        sprintAction = inputActionAsset.FindAction("Sprint");
        interactAction = inputActionAsset.FindAction("Interact");

        interactAction.performed += ctx => OnInteract();
    }

    private void Update()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Negr!");
            moveAction.Disable();
            sprintAction.Disable();
        }
        if (collision.gameObject.TryGetComponent<Interact>(out Interact interact))
        {
            interacts.Append(interact);
            //CHEKPOINT change it later
        }
    }

    private void OnInteract()
    {
        Debug.Log("Interacting with objects.");
        foreach (var interact in interacts)
        {
            interact.OnInteract();
        }
    }

}