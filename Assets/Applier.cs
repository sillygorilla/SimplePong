using UnityEngine;

public class ApplySettings : MonoBehaviour
{
    void Awake()
    {
        ApplySavedSettings();
    }

    void ApplySavedSettings()
    {
        int savedRes = PlayerPrefs.GetInt("resolution", -1);
        bool isFullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;
        float volume = PlayerPrefs.GetFloat("volume", 1f);

        Resolution[] resolutions = Screen.resolutions;
        if (savedRes >= 0 && savedRes < resolutions.Length)
        {
            Resolution res = resolutions[savedRes];
            Screen.SetResolution(res.width, res.height, isFullscreen);
        }

        AudioListener.volume = volume;
    }
}
