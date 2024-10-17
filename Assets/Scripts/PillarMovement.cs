using UnityEngine;

public class PillarMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -15f) 
        {
            Destroy(gameObject);
        }
    }
}
