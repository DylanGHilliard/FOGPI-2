using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using UnityEngine.Animations;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.XR.WindowsMR.Input;


[CustomEditor(typeof(PlayerManager))]

public class PlayerManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PlayerManager pm = (PlayerManager)target;

        if (GUILayout.Button("Save Game"))
        {
            pm.SaveGame();
        }
        if (GUILayout.Button("Load Game"))
        {
            pm.LoadGame();
        }
    }
}


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public Health health;

    public WalletManager wallet;
    private WeaponManager wm;

    [SerializeField] private string weaponsPath = "Weapons/";  // Path to weapons in Resources folder
    public List<ScriptableObject> ownedWeapons = new List<ScriptableObject>();
    public List<ScriptableObject> equipedWeapons = new List<ScriptableObject>();
    public GameObject player;


    private SaveData saveData = new SaveData(10, 100, 100);
    private const string SAVE_KEY = "PlayerSaveData";


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this);

        InitializeComponents();
        LoadGame();

        
        equipedWeapons = ownedWeapons; //Change latter


    }

    private void InitializeComponents()
    {
        // Get required components
        wallet = GetComponent<WalletManager>() == null ? this.AddComponent<WalletManager>() : GetComponent<WalletManager>();
        health = GetComponent<Health>() == null ? this.AddComponent<Health>() : GetComponent<Health>();

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
            health.maxHealth,
            ownedWeapons

        );

        string json = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
        Debug.Log("Game saved successfully");

    }

    public void LoadGame()
    {
    
            string json = PlayerPrefs.GetString(SAVE_KEY);
            saveData = JsonUtility.FromJson<SaveData>(json);

            // Apply loaded data
            health.SetCurrentHealth(saveData.health);
            health.SetMaxHealth(saveData.maxHealth);
            wallet.SetCoins(saveData.coins);
            ownedWeapons.Clear();

            foreach (string weaponName in saveData.ownedWeapons)
            {
                ScriptableObject weapon = Resources.Load<ScriptableObject>(weaponsPath + weaponName);
                if (weapon != null)
                {
                    ownedWeapons.Add(weapon);
                }
                else
                {
                    Debug.LogWarning($"Weapon '{weaponName}' not found in Resources/{weaponsPath}");
                }
            }

            Debug.Log("Game loaded successfully");

        

    }

    public void RegisterPlayer(GameObject _player)
    {
        player = _player;
        wm = player.AddComponent<WeaponManager>();

        for (int i = 0; i < equipedWeapons.Count; i++)
        {
            Debug.Log("in FOR LOOP");
            WeaponSO weapon = (WeaponSO)equipedWeapons[i];
            Weapon weaponTemp = Instantiate(weapon.weaponPrefab, player.transform.position + Vector3.right *0.5f, player.transform.rotation, player.transform).GetComponent<Pistol>();
            print("weaponTemp");
            wm.weapons.Add(weaponTemp);
             if (i == 0)
             {
                 wm.currentWeapon = weaponTemp;
                 wm.currentWeapon.gameObject.SetActive(true);
             }
             else
             {
                 weaponTemp.gameObject.SetActive(false);
             }
            Debug.Log("Added " + weapon.weaponName);

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
    public List<string> ownedWeapons = new List<string>();

    public SaveData(int _coins, int _health, int _maxHealth, List<ScriptableObject> _ownedWeapons = null)
    {
        coins = _coins;
        health = _health;
        maxHealth = _maxHealth;

        foreach (ScriptableObject weapon in _ownedWeapons)
        {
            ownedWeapons.Add(weapon.name);
        }
    
    }
}




