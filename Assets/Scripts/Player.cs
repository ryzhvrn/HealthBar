using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const float DamageInstance = 10f;
    public const float MaxHealth = 100f;

    public event Action<float> HealthChanged;

    private float _health;

    public float Health => _health;

    public void Heal()
    {
        _health += DamageInstance;
        HealthChanged?.Invoke(Health);
    }

    public void Damage()
    {
        _health -= DamageInstance;
        HealthChanged?.Invoke(Health);
    }

    private void Start()
    {
        _health = 50;
        HealthChanged?.Invoke(Health);
    }
}
