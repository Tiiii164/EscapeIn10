using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public AudioClip expoldeSound;
    public AudioClip spatSound;
    public void ExploseSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(expoldeSound,transform, 0.1f);
    }
    public void SpatSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(spatSound, transform, 0.1f);
    }
}
