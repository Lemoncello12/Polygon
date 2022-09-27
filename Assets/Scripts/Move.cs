using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 9;
    public bool cubeIsOnTheGround = true;
    private Rigidbody rb;
    public TextMeshProUGUI ScoreText;
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        if (Score >= 4)
        {
            YouWin();
        }
    }

    void YouWin()
    {
        ScoreText.text = "You Win";
        Time.timeScale = 0f;
    }



    void PlayerMove()
    {
        float leftRight = Input.GetAxis("Horizontal");
        float forwardBack = Input.GetAxis("Vertical");
        Vector3 movePlayer = new Vector3(leftRight, 0, forwardBack) * speed * Time.deltaTime;
        transform.Translate(movePlayer, Space.Self);

        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            cubeIsOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entered");
        if (collision.gameObject.tag == ("Ground"))
        {
            cubeIsOnTheGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            AddScore();
        }
        
    }

    void AddScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }
}
