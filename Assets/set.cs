using UnityEngine;

public class set : MonoBehaviour
{
    public AudioClip bounceSound;
private AudioSource audioSource;

void Start()
{
    audioSource = GetComponent<AudioSource>();
}

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Paddle"))
    {
        audioSource.PlayOneShot(bounceSound);
    }
}
}
