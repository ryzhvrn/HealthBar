using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const float DamageInstance = 10f;
    public const float MaxHealth = 100f;

    private float _health;

    public event Action<float> HealthChanged;

    public float Health => _health;

    private void Start()
    {
        _health = 50;
        HealthChanged?.Invoke(Health);
    }

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
}
