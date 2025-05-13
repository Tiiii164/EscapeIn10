using Unity.VisualScripting;
//using UnityEditor.PackageManager.ValidationSuite;
using UnityEngine;

[CreateAssetMenu(fileName = "AmmoConfigSO", menuName = "Scriptable Objects/Guns/AmmoConfigSO", order = 3)]
public class AmmoConfigSO : ScriptableObject 
{
    public int MaxAmmo = 120;
    public int ClipSize = 30;

    public int CurrentAmmo = 120;
    public int CurrentClipAmmo = 30;

   
    public void Reload()
    {

        int maxReloadAmount = Mathf.Min(ClipSize, CurrentAmmo);
        int availableBulletsInCurrentClip = ClipSize - CurrentClipAmmo;
        int reloadAmount = Mathf.Min(maxReloadAmount, availableBulletsInCurrentClip);
        CurrentClipAmmo += reloadAmount;
        CurrentAmmo -= reloadAmount;
    }
    public bool CanReload()
    {
        return CurrentClipAmmo < ClipSize && CurrentAmmo > 0;
    }

    public void AddAmmo(int Amount)
    {
        if (CurrentAmmo + Amount > MaxAmmo)
        {
            CurrentAmmo = MaxAmmo;
        }
        else
        {
            CurrentAmmo += Amount;
        }
    }

    //public object Clone()
    //{
    //    AmmoConfigSO config = CreateInstance<AmmoConfigSO>();

    //    Utilities.CopyValues(this, config);

    //    return config;
    //}
}


