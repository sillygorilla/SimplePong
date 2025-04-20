using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float baseOrthographicSize = 5f;
    public int referenceHeight = 1080;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        UpdateOrthographicSize();
    }

    public void UpdateOrthographicSize()
    {
        if (cam == null)
            cam = Camera.main;

        float scale = (float)Screen.height / referenceHeight;
        cam.orthographicSize = baseOrthographicSize / scale;
    }
}
