using UnityEngine;
public class Interact : MonoBehaviour
{
    [SerializeField] Door door;
    public virtual void OnInteract()
    {
        door.Interact();
    }
}