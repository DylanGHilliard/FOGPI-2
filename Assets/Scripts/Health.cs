using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public UnityEvent outOfHealth;
    public UnityEvent hurt;
    public UnityEvent OnDeath;
    void Start()
    {
        currentHealth = maxHealth;

        if (outOfHealth == null)    outOfHealth = new UnityEvent();
        if (hurt == null)           hurt = new UnityEvent();
        if (OnDeath == null)        OnDeath = new UnityEvent();
    }

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            Death();
        }
        else
        {
            hurt.Invoke();
        }
    }

    public void Heal(int _amount)
    {
        currentHealth += _amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void SetCurrentHealth(int _amount)
    {
        currentHealth = _amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void SetMaxHealth(int _amount)
    {
        maxHealth = _amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }



    private void Death()
    {
        OnDeath.Invoke();
    }

}
