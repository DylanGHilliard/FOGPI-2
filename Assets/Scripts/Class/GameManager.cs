using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public bool isPlaying = false;

    public PlayerController player;
    public List<GameObject> enemies;
    public WinUI win;
    public int enemiesCount = 1;
    private float time = 0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time < 1f) return;
        
            
    
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemiesCount <= 0)
        {
            win.WinScreen();
        }
    }
    
    
}
