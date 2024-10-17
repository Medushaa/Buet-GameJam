using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Sprite frontView;
    public Sprite backView;
    public Sprite leftView;
    public Sprite rightView;
    public float speed = 2f; 

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public RectTransform dialogueBox;
    public TextMeshProUGUI dialogueText;
    private bool isDialogueShown = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        dialogueBox.anchoredPosition = new Vector2(dialogueBox.anchoredPosition.x, -300);
        
        StartCoroutine(ShowDialogue());
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = Vector2.zero;
        bool movementKeyPressed = false; 

        // Horizontal movement
        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical)) // Prioritize horizontal movement
        {
            if (horizontal < 0)
            {
                movement = new Vector2(-1, 0); // Move left
                spriteRenderer.sprite = leftView;
                movementKeyPressed = true;
            }
            else if (horizontal > 0)
            {
                movement = new Vector2(1, 0); // Move right
                spriteRenderer.sprite = rightView;
                movementKeyPressed = true;
            }
        }
        // Vertical movement
        else
        {
            if (vertical < 0)
            {
                movement = new Vector2(0, -1); 
                spriteRenderer.sprite = frontView;
                movementKeyPressed = true;
            }
            else if (vertical > 0)
            {
                movement = new Vector2(0, 1); 
                spriteRenderer.sprite = backView;
                movementKeyPressed = true;
            }
        }

        if (movementKeyPressed)
        {
            rb.velocity = movement * speed; 
        }
        else
        {
            rb.velocity = Vector2.zero; 
        }
    }

    IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Where… am I?";
        dialogueBox.anchoredPosition = new Vector2(dialogueBox.anchoredPosition.x, -157); 
        
        yield return new WaitForSeconds(2f);
        
        dialogueText.text = "This place feels so familiar.";

        isDialogueShown = true;

        yield return new WaitForSeconds(2f);
        HideDialogue();
    }
    void HideDialogue()
    {
        dialogueBox.anchoredPosition = new Vector2(dialogueBox.anchoredPosition.x, -300);
        dialogueText.text = ""; 
        isDialogueShown = false;
    }
}
