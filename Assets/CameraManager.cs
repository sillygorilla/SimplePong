using UnityEngine;

public class ScreenFitter : MonoBehaviour
{
    public Transform topBorder;
    public Transform bottomBorder;
    public Transform leftGoal;
    public Transform rightGoal;

    public float borderThickness = 1f;

    void Start()
    {
        FitToScreen();
    }

    void FitToScreen()
    {
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;

        // Topo
        topBorder.position = new Vector2(0, halfHeight);
        topBorder.localScale = new Vector2(halfWidth * 2f, borderThickness);

        // Base
        bottomBorder.position = new Vector2(0, -halfHeight);
        bottomBorder.localScale = new Vector2(halfWidth * 2f, borderThickness);

        // Gol esquerdo
        leftGoal.position = new Vector2(-halfWidth, 0);
        leftGoal.localScale = new Vector2(borderThickness, halfHeight * 2f);

        // Gol direito
        rightGoal.position = new Vector2(halfWidth, 0);
        rightGoal.localScale = new Vector2(borderThickness, halfHeight * 2f);
    }
}
