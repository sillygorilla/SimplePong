using UnityEngine;

public class ControlsP2 : MonoBehaviour
{
    public float moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
    float moveY = 0f;

    if (Input.GetKey(KeyCode.UpArrow))
        moveY = 1f;
    else if (Input.GetKey(KeyCode.DownArrow))
        moveY = -1f;

    Vector3 position = transform.position;
    position.y += moveY * moveSpeed * Time.deltaTime;
    position.y = Mathf.Clamp(position.y, -4f, 4f);

    transform.position = position;
}
}
