﻿using System.Collections;
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
    private int keyGet;
    int sceneNum = 12;
    public GameObject keyModel;
    public GameObject blueKey;
    public GameObject blackKey;
    public GameObject greenKey;
    public GameObject redKey;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        secretGet = save.secrets[SceneManager.GetActiveScene().buildIndex - 1];   
        Material blueMat = blueKey.GetComponent<MeshRenderer>().material;
        Material blackMat = blackKey.GetComponent<MeshRenderer>().material;
        Material greenMat = greenKey.GetComponent<MeshRenderer>().material;
        Material redMat = redKey.GetComponent<MeshRenderer>().material;
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
        if (save.sprintLock)
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
        else if (keyGet != 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (other.gameObject.CompareTag("BlueKey"))
                {
                    keyGet = 2;
                }
                else if (other.gameObject.CompareTag("BlackKey"))
                {
                    
                    keyGet = 1;
                }
                else if (other.gameObject.CompareTag("GreenKey"))
                {
                    
                    keyGet = 3;
                }
                else if (other.gameObject.CompareTag("RedKey"))
                {
                    
                    keyGet = 4;
                }
            }
            
        }
        
    }

    void KeyUpdate()
    {
        if (keyGet != 0)
        {
            if (keyModel.ActiveSelf == false)
            {
                if (keyGet == 1)
                {
                    
                }
                else if (keyGet == 2)
                {

                }
                else if (keyGet == 3)
                {

                }
                else if (keyGet == 4)
                {

                }
                keyModel.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && keyGet != 0)
        {

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
