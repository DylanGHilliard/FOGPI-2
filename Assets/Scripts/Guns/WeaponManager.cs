using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(WeaponManager))]
public class WeaponManagerEditor : Editor
{
    private WeaponManager weaponManager;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        WeaponManager wm = (WeaponManager)target;

        if (GUILayout.Button("Prev"))
        {
            wm.PrevWeapon();
        }
        if (GUILayout.Button("Next"))
        {
            wm.NextWeapon();
        }
        if (GUILayout.Button("Use"))
        {
            wm.Use();
        }
    }



}

#endif
public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();
    public Weapon currentWeapon;
    private int currentWeaponIndex = 0;
    void Start()
    {
        weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
    }

    public void Use()
    {
        if (currentWeapon) currentWeapon.Use();
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
            currentWeapon.Use();

        if (Input.GetKeyDown(KeyCode.Q))
            PrevWeapon();

        if (Input.GetKeyDown(KeyCode.E))
            NextWeapon();

    }

    public void PrevWeapon()
    {
        if (weapons.Count <= 1) return;

        currentWeaponIndex--;
        if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = weapons.Count - 1;
        }

        currentWeapon.gameObject.SetActive(false); // Turn off old gun

        currentWeapon = weapons[currentWeaponIndex]; // Set new gun and turn on
        currentWeapon.gameObject.SetActive(true);
        Debug.Log("Switched to " + currentWeapon.name);
    }

    public void NextWeapon()
    {
        if (weapons.Count <= 1) return;

        currentWeaponIndex++;
        if (currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }
        currentWeapon.gameObject.SetActive(false); // Turn off old gun

        currentWeapon = weapons[currentWeaponIndex]; // Set new gun and turn on
        currentWeapon.gameObject.SetActive(true);
        Debug.Log("Switched to " + currentWeapon.name);
    }
}
