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

    private int cubeIsOnTheGround;
    public int maxJump = 1;
    public bool secretGet = false;

    public TextMeshProUGUI ScoreText;
    public int score;
    private float sprint = 1;
    public float sprintTo = 3f;
    public int scoreToWin = 4;
    public LocalSave save;
    public GameObject gun;
    public int keyGet;
    int sceneNum = 16;
    public GameObject keyModel;
    public GameObject blueKey;
    public GameObject blackKey;
    public GameObject greenKey;
    public GameObject redKey;
    public Material blackMat;
    public Material blueMat;
    public Material greenMat;
    public Material redMat;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        
        if (SceneManager.GetActiveScene().buildIndex <= 13)
        {
            secretGet = save.newsecrets[SceneManager.GetActiveScene().buildIndex - 1];
        }
        else if (SceneManager.GetActiveScene().buildIndex > 13)
        {
            secretGet = save.newsecrets[SceneManager.GetActiveScene().buildIndex - 4];
        }
    }
    public void SaveStart()
    {
        if (save.gunLock == true)
        {
            gun.SetActive(true);
        }
        if (save.jumpLock)
        {
            maxJump = 2;
        }
        cubeIsOnTheGround = maxJump;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (SceneManager.GetActiveScene().buildIndex < 13 || SceneManager.GetActiveScene().buildIndex > 15)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }

        PlayerMove();
        KeyUpdate();

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
        save.LoadSecrets();
        if (SceneManager.GetActiveScene().buildIndex == sceneNum)
        {
            SceneManager.LoadScene(0);
        } 
        else
        {
            if (SceneManager.GetActiveScene().buildIndex != 12)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(16);
            }
            
        }
        

    }


    void PlayerMove()

    {
        float leftRight = Input.GetAxis("Horizontal");
        float forwardBack = Input.GetAxis("Vertical");
        //Vector3 movePlayer = transform.position;
        //movePlayer.x = movePlayer.x + leftRight * speed * 10 * Time.deltaTime;
        //movePlayer.z = movePlayer.z + forwardBack * speed * 10 * Time.deltaTime;
        if (save.sprintLock == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                sprint = sprintTo;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                sprint = 1;
            }
        }
        
        Vector3 movePlayer = new Vector3(leftRight, 0, forwardBack) * speed * sprint * Time.deltaTime;
        transform.Translate(movePlayer, Space.Self);
        //rb.MovePosition(movePlayer);
        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            cubeIsOnTheGround = cubeIsOnTheGround - 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entered");
        if (collision.gameObject.tag == ("Ground") || collision.gameObject.tag ==("StorageCube"))
        {
            cubeIsOnTheGround = maxJump;
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
        else if (other.gameObject.CompareTag("GunActivate"))
        {
            other.gameObject.SetActive(false);
            save.PowerUpGet(0);
        }
        else if (other.gameObject.CompareTag("JumpActivate"))
        {
            other.gameObject.SetActive(false);
            save.PowerUpGet(1);
        }
        else if (other.gameObject.CompareTag("SprintActivate"))
        {
            other.gameObject.SetActive(false);
            save.PowerUpGet(2);
        }
        else if (other.gameObject.CompareTag("BlackLock") && keyGet == 1)
        {
            keyGet = 0;
            keyModel.SetActive(false);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("BlueLock") && keyGet == 2)
        {
            keyGet = 0;
            keyModel.SetActive(false);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("GreenLock") && keyGet == 3)
        {
            keyGet = 0;
            keyModel.SetActive(false);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("RedLock") && keyGet == 4)
        {
            keyGet = 0;
            keyModel.SetActive(false);
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
        else if (keyGet == 0)
        {
            if (other.gameObject.CompareTag("BlueKey"))
                {
                    keyGet = 2;
                    other.gameObject.SetActive(false);
                }
                else if (other.gameObject.CompareTag("BlackKey"))
                {
                    
                    keyGet = 1;
                    other.gameObject.SetActive(false);
                }
                else if (other.gameObject.CompareTag("GreenKey"))
                {
                    keyGet = 3;
                    other.gameObject.SetActive(false);
                }
                else if (other.gameObject.CompareTag("RedKey"))
                {
                    
                    keyGet = 4;
                    other.gameObject.SetActive(false);
                }
        }
        
    }

    void KeyUpdate()
    {
        if (keyGet != 0)
        {
            if (keyModel.activeSelf == false)
            {
                if (keyGet == 1)
                {
                    keyModel.GetComponent<MeshRenderer>().material = blackMat;
                }
                else if (keyGet == 2)
                {
                    keyModel.GetComponent<MeshRenderer>().material = blueMat;
                }
                else if (keyGet == 3)
                {
                    keyModel.GetComponent<MeshRenderer>().material = greenMat;
                }
                else if (keyGet == 4)
                {
                    keyModel.GetComponent<MeshRenderer>().material = redMat;
                }
                keyModel.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && keyGet != 0)
        {
            keyModel.SetActive(false);
            Vector3 KeyPos = new Vector3(transform.position.x,transform.position.y + 2f,transform.position.z + 1f);
            if (keyGet == 1)
            {
                GameObject newKey = Instantiate(blackKey,KeyPos,transform.rotation);
            }
            else if (keyGet == 2)
            {
                GameObject newKey = Instantiate(blueKey,KeyPos,transform.rotation); 
            }
            else if (keyGet == 3)
            {
                GameObject newKey = Instantiate(greenKey,KeyPos,transform.rotation);  
            }
            else if (keyGet == 4)
            {
                GameObject newKey = Instantiate(redKey,KeyPos,transform.rotation);    
            }
            keyGet = 0;
        }
    }


    void AddScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }

    public void Up()
    {
        transform.position = new Vector3(transform.position.x, 400, transform.position.z);
    }




}
