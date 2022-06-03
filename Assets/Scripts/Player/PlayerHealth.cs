using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    public event Action onDead;

    public void TakeDamage()
    {
        onDead?.Invoke();
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
    }
}
