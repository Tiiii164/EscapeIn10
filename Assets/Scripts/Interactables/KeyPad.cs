using UnityEngine;

public class KeyPad : Interactable
{
    [SerializeField] private GameObject door;
    private bool doorOpen ;
    
    

   
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        Debug.Log("Interacted with" + gameObject.name);
        door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
    }
}
