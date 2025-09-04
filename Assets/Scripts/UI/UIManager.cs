using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject shopMenu;
    public GameObject settingsMenu;

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

    public void OpenShop()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void CloseShop()
    {
        mainMenu.SetActive(true);
        shopMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
}
