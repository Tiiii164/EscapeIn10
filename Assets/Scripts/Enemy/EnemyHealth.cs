using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int _Health;
    [SerializeField]
    private int _MaxHealth = 100;
    public float bulletSpread = 3f;
    [SerializeField] AudioClip damageSoundFXClip;
    public int CurrentHealth { get => _Health; private set => _Health = value; }
    public int MaxHealth { get => _MaxHealth; private set => _MaxHealth = value; }

    public event IDamageable.TakeDamageEvent OnTakeDamage;
    public event IDamageable.DeathEvent OnDeath;

    private FlashEffect _flashEffect;

    private void Awake()
    {
        _flashEffect = GetComponent<FlashEffect>();
    }

    private void OnEnable()
    {
        _Health = MaxHealth;
    }

    public void TakeDamage(int Damage)
    {
        int damageTaken = Mathf.Clamp(Damage, 0, CurrentHealth);
        CurrentHealth -= damageTaken;
        SoundFXManager.Instance.PlaySoundFXClip(damageSoundFXClip,transform,1);
        if (damageTaken != 0)
        {
            OnTakeDamage?.Invoke(damageTaken);
            _flashEffect?.PlayFlash(); 
        }

        if (CurrentHealth == 0 && damageTaken != 0)
        {
            OnDeath?.Invoke(transform.position);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
