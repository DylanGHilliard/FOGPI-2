using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using UnityEngine.Animations;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private Health health;

    private WalletManager wallet;
    private WeaponManager wm;
    private GameObject player;

    private SaveData saveData = new SaveData(10, 100, 100);
    private const string SAVE_KEY = "PlayerSaveData";


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);


        player = GameObject.FindGameObjectWithTag("Player");
        LoadGame();


    }

    private void InitializeComponents()
    {
        // Get required components
        wallet = GetComponent<WalletManager>() == null ? this.AddComponent<WalletManager>() : GetComponent<WalletManager>();
        health = GetComponent<Health>() == null ? this.AddComponent<Health>() : GetComponent<Health>();
        wm = GetComponent<WeaponManager>();
        player = GameObject.FindGameObjectWithTag("Player");

        // Check if components exist
        if (!health) Debug.LogError("Health component missing from Player!");
        if (!wallet) Debug.LogError("WalletManager not found in scene!");
        if (!wm) Debug.LogError("WeaponManager component missing from Player!");
        if (!player) Debug.LogError("Player object not found in scene!");
    }

    private void InitializePlayerStats()
    {
        // Set initial health
        if (health != null)
        {

        }

        // Set initial currency
        if (wallet != null)
        {

        }


    }

    public void SaveGame()
    {
        saveData = new SaveData(
            health.currentHealth,
            wallet.coin,
            health.maxHealth

        );

        string json = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();

    }
    
     public void LoadGame()
    {
        if(PlayerPrefs.HasKey(SAVE_KEY))
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            saveData = JsonUtility.FromJson<SaveData>(json);

            // Apply loaded data
            health.SetCurrentHealth(saveData.health);
            health.SetMaxHealth(saveData.maxHealth);
            wallet.SetCoins(saveData.coins);

            Debug.Log("Game loaded successfully");
            return;
        }

    }

    // Auto-save when application quits
    private void OnApplicationQuit()
    {
        SaveGame();
    }



}

[System.Serializable]
public class SaveData
{
    public int coins = 10;
    public int health = 100;
    public int maxHealth = 100;

    public SaveData(int _coins, int _health, int _maxHealth)
    {
        coins = _coins;
        health = _health;
        maxHealth = _maxHealth;
    }
}




