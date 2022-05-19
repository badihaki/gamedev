using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int CurrentHealth { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeHealth(int damageValue)
    {
        CurrentHealth -= damageValue;
    }

    public void GiveHealth(int healValue)
    {
        CurrentHealth += healValue;
    }

    public void IncreaseMaxHealth(int healthPowerUpValue)
    {
        maxHealth += healthPowerUpValue;
    }

    // end of the line
}
