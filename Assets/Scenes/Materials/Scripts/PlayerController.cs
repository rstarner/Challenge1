using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text livesText;
    public Text loseText;


    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        SetCountText();
        
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

     void OnTriggerEnter(Collider other)


    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1; // I added this code to track the score and count separately.
            SetAllText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1; // this removes 1 from the score
            SetAllText();
        }
    }

    private void SetAllText()
    {
        throw new NotImplementedException();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 16)
        {
            winText.text = "LVL 1 COMPLETE!";
        }
    }

    void SetlivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives >= 0)
        {
            loseText.text = "Game Over!";
        }
    }
}

