using UnityEngine;
public class Door : MonoBehaviour
{
    Animator doorAnimator;
    public bool isClosed = true;
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }
    public void Interact()
    {
        if (isClosed)
        {
            
            OpenDoor();
        }
        else
        {
            
            CloseDoor();
        }
    }
    public void OpenDoor()
    {
        doorAnimator.SetBool("isClosed", false);
        isClosed = false;
        Debug.Log("Door is now open.");
    }
    public void CloseDoor()
    {
        doorAnimator.SetBool("isClosed", true);
        isClosed = true;
        Debug.Log("Door is now closed.");
    }
}