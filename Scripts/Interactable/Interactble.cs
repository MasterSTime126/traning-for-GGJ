using UnityEngine;
public class Interactble : MonoBehaviour
{
    [SerializeField] Door door;
    public virtual void Interact()
    {
        door.Interact();
    }
}