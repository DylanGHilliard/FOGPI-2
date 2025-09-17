using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    PlayerManager pm;

    void Start()
    {
        pm = PlayerManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = (float)pm.health.currentHealth / (float)pm.health.maxHealth;
    }
}
