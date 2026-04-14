using UnityEngine;

public class CloudScroll : MonoBehaviour
{
    public float speed = 1.5f;
    public float resetX = -12f;
    public float startX = 12f;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= resetX)
        {
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        }
    }
}