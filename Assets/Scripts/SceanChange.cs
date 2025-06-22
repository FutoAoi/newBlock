using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [Header("ÉVÅ[Éìî‘çÜ")]
    [SerializeField] int index;

    private SpriteRenderer sprite;
    private Color defaultcolor;
    private bool inButton = false;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultcolor = sprite.color;
    }

    private void Update()
    {
        if (inButton == true && Input.GetKeyDown(KeyCode.Space))  
        {
            SceneManager.LoadScene(index);  
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))  
        {
            sprite.color = Color.white;  
            inButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            sprite.color = defaultcolor;
            inButton = false;
        }
    }
}
