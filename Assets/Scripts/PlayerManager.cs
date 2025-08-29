using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }

    private Health health;
    private WalletManager wallet;
    private WeaponManager wm;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        wallet = WalletManager.instance;

    }
    

}


