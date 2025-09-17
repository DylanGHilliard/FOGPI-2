using TMPro;
using UnityEngine;
using UnityEngine.XR.WindowsMR.Input;

public class WalletUI : MonoBehaviour
{
    public TMP_Text coinText;
    private WalletManager wallet;
    void Start()
    {
        wallet = PlayerManager.instance.wallet;;
       
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " +wallet.coins.ToString();
    }
}
