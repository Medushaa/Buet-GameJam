using System.Collections;
using UnityEngine;

public class CircleScaler : MonoBehaviour
{
    public Vector3 startScale = new Vector3(1.77f, 2.1f, 1f); 
    public Vector3 endScale = new Vector3(18f, 18f, 1f); 
    public float duration = 1f;

    void Start()
    {
        transform.localScale = startScale;
        StartCoroutine(ScaleOverTime());
    }

    IEnumerator ScaleOverTime()
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        transform.localScale = endScale;
        Destroy(gameObject);
    }
}
