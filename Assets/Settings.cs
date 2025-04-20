using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Slider volumeSlider;

    Resolution[] resolutions;
    List<string> options = new List<string>();

    void Start()
{
    // RESOLUÇÃO
    HashSet<Vector2Int> uniqueSizes = new HashSet<Vector2Int>();
    resolutions = Screen.resolutions;
    resolutionDropdown.ClearOptions();

    int currentResolutionIndex = 0;
    options.Clear();

    for (int i = 0; i < resolutions.Length; i++)
    {
        Vector2Int size = new Vector2Int(resolutions[i].width, resolutions[i].height);

        if (uniqueSizes.Add(size))
        {
            string option = size.x + " x " + size.y;
            options.Add(option);

            if (size.x == Screen.currentResolution.width && size.y == Screen.currentResolution.height)
            {
                currentResolutionIndex = options.Count - 1;
            }
        }
    }

    resolutionDropdown.AddOptions(options);

    // Carregar preferências
    int savedRes = PlayerPrefs.GetInt("resolution", currentResolutionIndex);
    bool isFullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;
    float savedVolume = PlayerPrefs.GetFloat("volume", 1f);

    resolutionDropdown.value = savedRes;
    resolutionDropdown.RefreshShownValue();
    fullscreenToggle.isOn = isFullscreen;
    volumeSlider.value = savedVolume;

    SetResolution(savedRes);
    SetFullscreen(isFullscreen);
    SetVolume(savedVolume);
}

    public void SetResolution(int resolutionIndex)
{
    if (resolutionIndex < 0 || resolutionIndex >= options.Count)
        resolutionIndex = 0;

    string[] res = options[resolutionIndex].Split('x');
    int width = int.Parse(res[0].Trim());
    int height = int.Parse(res[1].Trim());

    bool isFullscreen = fullscreenToggle.isOn;

    if (isFullscreen)
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Screen.SetResolution(width, height, true);
    }
    else
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(width, height, false);
    }

    PlayerPrefs.SetInt("resolution", resolutionIndex);
    PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);
}


public void SetFullscreen(bool isFullscreen)
{
    Screen.fullScreen = isFullscreen;
    PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);
}

public void SetVolume(float volume)
{
    AudioListener.volume = volume;
    PlayerPrefs.SetFloat("volume", volume);
}

}