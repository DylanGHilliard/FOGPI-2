using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public Sprite weaponImage;
    public int weaponPrice; 
    public GameObject weaponPrefab;
}
