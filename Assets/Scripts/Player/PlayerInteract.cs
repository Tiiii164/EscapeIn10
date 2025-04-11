using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask mask;
    private PlayerUI playerUI;
    //private StarterAsset playerInput;
    private InputManager inputManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, rayDistance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promtMessage);
                if (inputManager.playerActions.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
