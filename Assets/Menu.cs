using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 


    public void PLAY()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QUIT()
    {
        Application.Quit();
        Debug.Log("EXITING");

    }
    public void CONFIG()
    {
        SceneManager.LoadScene("ConfigMenu");
    }
}
