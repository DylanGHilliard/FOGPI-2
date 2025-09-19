using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject shopMenu;
    public GameObject survey;
    public GameObject settingsMenu;

    private GameObject currActive;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(true);
            survey.SetActive(false);

        }
    }

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

    public void OpenSurvey()
    {
        mainMenu.SetActive(false);
        survey.SetActive(true);
        currActive = survey;
    }

    public void RestGame()
    {
        PlayerManager.instance.ResetData();

    }
}
