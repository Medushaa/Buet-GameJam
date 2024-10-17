using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameMovement : MonoBehaviour
{
    //public float moveSpeed = 5f; // Speed at which the player moves
    public float verticalSpeed = 2f; // Speed for vertical movement
    public ParticleSystem dustParticles; // Reference to the particle system
    public GameManager gameManager;
    public GameObject pauseScreen;

    private void Start()
    {
        gameManager.ResumeGame();
        if (dustParticles != null)
        {
            dustParticles.Play(); // Start playing the particle system
        }
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        // Constantly move to the right
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // Vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 verticalMovement = Vector2.up * verticalInput * verticalSpeed * Time.deltaTime;
        transform.Translate(verticalMovement);

        // Update the particle system position and rotation
        if (dustParticles != null)
        {
            Vector3 dustPosition = transform.position + new Vector3(0, -0.2f, 0); // Adjust as needed
            dustParticles.transform.position = dustPosition;
            dustParticles.transform.rotation = Quaternion.Euler(170, 90, transform.eulerAngles.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Bari khaise");
        if (collision.gameObject.CompareTag("pillar"))
        {

            gameManager.PauseGame(); // Pause the game when ghost hits pillar
            pauseScreen.SetActive(true);
        }
    }
}
