using UnityEngine;

public class pipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2f;
    private float timer = 0f;
    public float heightOffset = 10f;

    public AudioClip spawnClip;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            Random.Range(lowestPoint, highestPoint),
            0
        );

        Instantiate(pipe, spawnPosition, transform.rotation);

        // Play sound safely (no stacking / no multiple AudioSource issues)
        if (spawnClip != null)
        {
            AudioSource.PlayClipAtPoint(spawnClip, transform.position);
        }
    }
}