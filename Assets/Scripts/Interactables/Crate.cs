using UnityEngine;
public class Crate : Interactable
{
    [SerializeField] ParticleSystem openParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        Debug.Log("Interacted with" + gameObject.name);
        openParticle.Play();
        Debug.Log("After Play - IsPlaying: " + openParticle.isPlaying + ", Particle Count: " + openParticle.particleCount);
    }
}
