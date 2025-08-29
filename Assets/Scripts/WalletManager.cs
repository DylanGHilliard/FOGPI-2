using UnityEngine;

public class WalletManager : MonoBehaviour
{
    public static WalletManager instance;

    [SerializeField] private int m_coin = 0;

    public int coin { get { return m_coin; } }

    void Awake()
    {
        if (instance == null)
            instance = this;

    }
    public bool ICanAfford(int _amount)
    {
        if (0 > (m_coin - _amount))
        {
            return false;
        }
        return true;
    }

    public void Earn(int _amount)
    {
        m_coin += _amount;
    }

    public void Pay(int _amount)
    {
        bool iCanAfford = ICanAfford(_amount);

        if (!iCanAfford) return;

        m_coin -= _amount;

    }

}
