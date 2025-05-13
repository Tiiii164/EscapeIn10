//using LlamAcademy.Guns.Demo;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private PlayerGunSelector GunSelector;
    [SerializeField] bool AutoReload = true;
    private bool IsReloading;
    //[SerializeField] Animator PlayerAnimator;
    [SerializeField] private float ReloadSpeed = 1;
    //[SerializeField] private PlayerIK InverseKinematics;
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    private StarterAssetsInputs assetsInputs;
    private void Awake()
    {
        assetsInputs = GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        if (assetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
        }
            GunSelector.ActiveGun.Tick(!IsReloading && Mouse.current.leftButton.isPressed && GunSelector.ActiveGun != null);
            
        if(ShouldManualReload() || ShouldAutoReload())
        {
            //GunSelector.ActiveGun.StartReloading();
            IsReloading = true;
            
            Invoke(nameof(EndReload), ReloadSpeed);
            //PlayerAnimator.SetTrigger("Reload");
            //InverseKinematics.HandIKAmount = 0.25f;
            //InverseKinematics.ElbowIKAmount = 0.25f;
        }

    }

    private bool ShouldManualReload()
    {
        return !IsReloading
            && Keyboard.current.rKey.wasReleasedThisFrame
            && GunSelector.ActiveGun.CanReload();
    }

    private bool ShouldAutoReload()
    {
        return !IsReloading
            && AutoReload
            && GunSelector.ActiveGun.AmmoConfig.CurrentClipAmmo == 0
            && GunSelector.ActiveGun.CanReload();
    }

    private void EndReload()
    {
        GunSelector.ActiveGun.EndReload();
       

        //InverseKinematics.HandIKAmount = 1f;
        //InverseKinematics.ElbowIKAmount = 1f;
        IsReloading = false;
    }
}
