using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{



    public void Play()
    {

        SceneManager.LoadSceneAsync(1);
       
    }

    public void Quit()
    {
#if UNITY_EDITOR
          UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif    
    }
}
