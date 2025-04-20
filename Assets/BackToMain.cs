using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public void BACK ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
