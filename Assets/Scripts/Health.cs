using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    [SerializeField] private int m_maxHealth = 100;
    protected int m_currentHealth;
    public UnityEvent outOfHealth;
    public UnityEvent hurt;
    public UnityEvent OnDeath;
    void Start()
    {
        m_currentHealth = m_maxHealth;

        if (outOfHealth == null)    outOfHealth = new UnityEvent();
        if (hurt == null)           hurt = new UnityEvent();
        if (OnDeath == null)        OnDeath = new UnityEvent();
    }

    public void TakeDamage(int _damage)
    {
        m_currentHealth -= _damage;
        if (m_currentHealth <= 0)
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
        m_currentHealth += _amount;
        if (m_currentHealth > m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }
    }


    private void Death()
    {
        OnDeath.Invoke();
    }

}
