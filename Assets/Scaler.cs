using UnityEngine;

public class CameraAutoScaler : MonoBehaviour
{
    public Transform topWall;
    public Transform bottomWall;
    public Transform leftPaddle;
    public Transform rightPaddle;

    public float padding = 1f;          // margem vertical extra
    public float minAspect = 16f / 9f;   // proporção mínima horizontal (ex: 4:3, 16:9)

    void Start()
    {
        if (topWall == null || bottomWall == null || leftPaddle == null || rightPaddle == null)
        {
            Debug.LogWarning("Algum elemento não foi atribuído no CameraAutoScaler!");
            return;
        }

        // Altura base
        float verticalSize = Mathf.Abs(topWall.position.y - bottomWall.position.y) / 2f + padding;

        // Centro vertical
        float midY = (topWall.position.y + bottomWall.position.y) / 2f;

        // Calcula o aspecto da tela atual
        float screenAspect = (float)Screen.width / Screen.height;

        // Largura total necessária (distância entre paddles)
        float desiredWidth = Mathf.Abs(rightPaddle.position.x - leftPaddle.position.x) + padding * 2;

        // Se a largura for maior do que o aspecto permitir, ajusta a ortographicSize proporcionalmente
        float requiredVerticalSizeForWidth = desiredWidth / (2f * screenAspect);

        // Usa o maior entre altura e largura exigida
        float finalSize = Mathf.Max(verticalSize, requiredVerticalSizeForWidth);

        Camera.main.orthographicSize = finalSize;

        // Centraliza a câmera horizontalmente e verticalmente
        float midX = (leftPaddle.position.x + rightPaddle.position.x) / 2f;
        Camera.main.transform.position = new Vector3(midX, midY, Camera.main.transform.position.z);
    }
}