using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed;
    public AudioClip bounceSound;
private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
{
    LaunchBall();
    audioSource = GetComponent<AudioSource>();

}

void LaunchBall()
{
    bool isRight = UnityEngine.Random.value >= 0.5f;
    float xVelocity = isRight ? 1f : -1f;

    float yVelocity = 0f;

    // Garante um mínimo de inclinação
    while (Mathf.Abs(yVelocity) < 0.3f)
    {
        yVelocity = UnityEngine.Random.Range(-1f, 1f);
    }

    Vector2 direction = new Vector2(xVelocity, yVelocity).normalized;
    rb.linearVelocity = direction * startingSpeed;
}
     void OnCollisionEnter2D(Collision2D collision)
    {
       
       {
    if (collision.gameObject.CompareTag("Paddle"))
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 direction = rb.linearVelocity.normalized;

            float currentSpeed = rb.linearVelocity.magnitude;
            float speedBoost = 0.5f;          // aceleração a cada colisão
            float maxSpeed = 40f;             // limite de velocidade

            float newSpeed = Mathf.Min(currentSpeed + speedBoost, maxSpeed);
            rb.linearVelocity = direction * newSpeed;
        }
         if (collision.gameObject.CompareTag("Paddle"))
    {
        audioSource.PlayOneShot(bounceSound);
    }
            
        
        
    }
}   

    }
    public void ResetBall()
{
    rb.linearVelocity = Vector2.zero;
    transform.position = Vector3.zero;

    float yVelocity = UnityEngine.Random.Range(-1f, 1f);
    float xDirection = UnityEngine.Random.value > 0.5f ? 1f : -1f;

    Vector2 newDirection = new Vector2(xDirection, yVelocity).normalized;
    rb.linearVelocity = newDirection * startingSpeed;
}
    void Update()
    {
        
        
        
    }
}    
