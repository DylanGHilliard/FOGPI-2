using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    PlayerManager pm;

    private float m_target;
    private float m_timeToDrain = 0.25f;

    private Coroutine drainHealthBarCoroutine;

    void Start()
    {
        pm = PlayerManager.instance;
        pm.health.hurt.AddListener(UpdateHealthBar);
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateHealthBar()
    {
        m_target = (float)pm.health.currentHealth / (float)pm.health.maxHealth;
        drainHealthBarCoroutine = StartCoroutine(DrainHealthBar());
    }



    private IEnumerator DrainHealthBar()
    {
        float fillAmount = healthSlider.value;

        float elapsedTime =0;
        while(elapsedTime < m_timeToDrain )
        {
            elapsedTime += Time.deltaTime;
            healthSlider.value = Mathf.Lerp(fillAmount, m_target, (elapsedTime/m_timeToDrain));

            yield return null;
        }
    }


}
