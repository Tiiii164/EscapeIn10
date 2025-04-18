using UnityEngine;
public class InputManager : MonoBehaviour
{
    public StarterAsset inputActions;
    public StarterAsset.PlayerActions playerActions;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputActions = new StarterAsset();
        playerActions = inputActions.Player;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        playerActions.Enable();
    }
    private void OnDisable()
    {
        playerActions.Disable();
    }
}
