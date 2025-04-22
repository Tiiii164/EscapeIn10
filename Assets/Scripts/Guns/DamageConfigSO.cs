using static UnityEngine.ParticleSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Config", menuName = "Scriptable Objects/Guns/Damage Config", order = 1)]
public class DamageConfigSO : ScriptableObject, System.ICloneable
{
    public MinMaxCurve DamageCurve;

    private void Reset()
    {
        DamageCurve.mode = ParticleSystemCurveMode.Curve;
    }

    public int GetDamage(float Distance = 0, float DamageMultiplier = 1)
    {
        return Mathf.CeilToInt(
            DamageCurve.Evaluate(Distance, Random.value) * DamageMultiplier
        );
    }

    public object Clone()
    {
        DamageConfigSO config = CreateInstance<DamageConfigSO>();

        config.DamageCurve = DamageCurve;
        return config;
    }
}