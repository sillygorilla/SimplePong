using UnityEngine;

public class Gols : MonoBehaviour
{
    public bool GolP1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GolP1 == true)
        {
            FindObjectOfType<GameManager>().IncreaseP2Points();
            other.gameObject.transform.position = Vector2.zero;
        }
        
        else 
        {
            FindObjectOfType<GameManager>().IncreaseP1Points();
            other.gameObject.transform.position = Vector2.zero;

        }
        Ball ball = other.GetComponent<Ball>();
        if (ball!= null)
        {
            ball.ResetBall();
        }
    }
}
