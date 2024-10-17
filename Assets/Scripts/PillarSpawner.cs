using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    public GameObject pillarPrefab; // The pillar prefab
    public float spawnRate = 2f; // Time between spawns
    //public float minHeight = -1f; // Minimum height of the pillar
    //public float maxHeight = 1f;  // Maximum height of the pillar
    public float pillarOffset = 2f; // Distance from the player to spawn the pillar
    private float timer = 0f;
    private bool alternatePillar = false; // To track alternate pillars

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPillar();
            timer = 0f;
        }
    }

    void SpawnPillar()
    {
        Vector3 spawnPosition;

        // Check if the pillar should be flipped
        if (alternatePillar)
        {
            // For flipped pillars, set Y position between 1.5 and 4
            float randomHeightFlipped = Random.Range(1.5f, 4f);
            spawnPosition = new Vector3(transform.position.x + pillarOffset, randomHeightFlipped, 0);
        }
        else
        {
            // For non-flipped pillars, set Y position between -1 and -4
            float randomHeightNonFlipped = Random.Range(-1f, -4f);
            spawnPosition = new Vector3(transform.position.x + pillarOffset, randomHeightNonFlipped, 0);
        }

        // Instantiate pillar
        GameObject newPillar = Instantiate(pillarPrefab, spawnPosition, Quaternion.identity);

        // Get the SpriteRenderer component
        SpriteRenderer pillarSpriteRenderer = newPillar.GetComponent<SpriteRenderer>();

        // Flip the Y-axis for alternate pillars
        if (alternatePillar)
        {
            pillarSpriteRenderer.flipY = true; // Flip the sprite vertically
        }
        else
        {
            pillarSpriteRenderer.flipY = false; // Ensure non-flipped pillars are normal
        }

        // Toggle the alternate pillar flag
        alternatePillar = !alternatePillar;
    }

}
