using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public GameObject winOBJ;


    public void WinScreen()
    {
        winOBJ.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
        winOBJ.SetActive(false);

    }
}
