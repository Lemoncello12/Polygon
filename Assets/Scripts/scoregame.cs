using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class scoregame : MonoBehaviour
{
    public float speed = 4.5f;
    private Rigidbody rb;

    public float jumpForce = 9;

    public bool cubeIsOnTheGround = true;
    public bool secretGet = false;

    public TextMeshProUGUI ScoreText;
    public int score;
    public int scoreToWin = 4;
    public LocalSave save;
    int sceneNum = 12;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        secretGet = save.secrets[SceneManager.GetActiveScene().buildIndex - 1];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        PlayerMove();

        if (score >= scoreToWin)
        {
            YouWin();

        }


    }


    void YouWin()
    {
        ScoreText.text = "You Win";
        //Time.timeScale = 0f;
        save.LevelComplete(secretGet);
        if (SceneManager.GetActiveScene().buildIndex == sceneNum)
        {
            SceneManager.LoadScene(0);
        } 
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        

    }


    void PlayerMove()

    {
        float leftRight = Input.GetAxis("Horizontal");
        float forwardBack = Input.GetAxis("Vertical");
        //Vector3 movePlayer = transform.position;
        //movePlayer.x = movePlayer.x + leftRight * speed * 10 * Time.deltaTime;
        //movePlayer.z = movePlayer.z + forwardBack * speed * 10 * Time.deltaTime;
        Vector3 movePlayer = new Vector3(leftRight, 0, forwardBack) * speed * Time.deltaTime;
        transform.Translate(movePlayer, Space.Self);
        //rb.MovePosition(movePlayer);
        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            cubeIsOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entered");
        if (collision.gameObject.tag == ("Ground") || collision.gameObject.tag ==("StorageCube"))
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
        else if (other.gameObject.CompareTag("Secret"))
        {
            secretGet = true;
            other.gameObject.SetActive(false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Door")
        {
            if(other.GetComponent<Autodoor>().Moving == false)
            {
                other.GetComponent<Autodoor>().Moving = true;
            }
        }
    }


    void AddScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }




}
