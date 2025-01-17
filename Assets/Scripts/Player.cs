using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerSpeed = 2f;
    private Collision2D tempCollision;

    int score = 0;

    public TextMeshProUGUI textMeshPro;

    
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < 0f)
            {
                transform.Translate(-transform.right * playerSpeed * Time.deltaTime);
            }
            else if (mousePos.x>0f)
            {
                transform.Translate(transform.right * playerSpeed * Time.deltaTime);
            }
           






        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            gameObject.SetActive(false);

            // Invoke("PlayerDeath", 1f);
            PlayerDeath();
            
        }
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            score++;
            textMeshPro.text="Score : "+score.ToString();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Break"))
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;
            tempCollision = collision;
            Invoke("Kill", 0.5f);
        }

       

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Left"))
        {
            transform.Translate(-transform.right * 1f * Time.deltaTime);
        }

        if (collision.gameObject.CompareTag("Right"))
        {
            transform.Translate(transform.right * 1f * Time.deltaTime);
        }
    }



    void Kill()
    {
        if (tempCollision != null)
        {
            Destroy(tempCollision.gameObject);
            tempCollision = null; // Clear it after use
        }
    }
    void PlayerDeath()
    {
        SceneManager.LoadScene("Game");
    }
}
