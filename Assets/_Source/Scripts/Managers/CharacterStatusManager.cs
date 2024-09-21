using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterStatusManager : MonoBehaviour, IDamageable
{
    public Status status;

    public event Action OnTakeDamage;

    private void Start()
    {
        status.Init();
    }


    public void TakeDamage(int amount)
    {
        Debug.Log("Tomando " + amount + "de dano");
        
        status.health -= amount;

        OnTakeDamage?.Invoke();

        if(status.health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
