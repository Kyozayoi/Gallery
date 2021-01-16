using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator bodyAnimator;

    private CharacterController controller;

    private float forwardSpeed = 10.0f;
    private float rotateSpeed = 3.5f;
    private float jumpSpeed = 4.0f;
    private float gravitySpeed = 20.0f;
    //private float rotation = 0.0f;

    private bool onGround;
    private bool jumped1;
    private Vector3 moveForward;
    private Vector3 moveUpward;
    public bool running = false;

    private Vector3 lastLocation;
    private Quaternion lastRotation;

    public PlayerDetails playerData;
    public int score = 0;
    public int highScore;
    public int gold;
    public int levels = -1;
    private int scoreModifier = 0;

    private void OnEnable()
    {
        playerData = DataManager.LoadPlayer();
        highScore = playerData.highScore;
        gold = playerData.gold;
    }
    private void OnDisable()
    {
        playerData.highScore = highScore;
        playerData.gold = gold;
        DataManager.SavePlayer(this);
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        bodyAnimator.SetTrigger("Running");
        lastLocation = this.transform.position;
        StartCoroutine(startCalculating());
    }

    IEnumerator startCalculating()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            score += scoreModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            onGround = controller.isGrounded;

            if (onGround && moveUpward.y < 0)
            {
                //Debug.Log("Z Position: " + this.transform.position.z);
                moveUpward.y = -1.0f;
                jumped1 = false;
            }

            moveForward = forwardSpeed * transform.forward;
            moveUpward.y -= gravitySpeed * Time.deltaTime;

            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).position.x < Screen.width / 2 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 rotateBy = Input.GetTouch(0).deltaPosition;
                    Rotate(rotateBy.x);
                    if (Input.touchCount > 1)
                    {
                        if (Input.GetTouch(1).position.x > Screen.width / 2 && (Input.GetTouch(1).position.x < Screen.width - 75 && Input.GetTouch(1).position.y < Screen.height - 75) && Input.GetTouch(1).phase == TouchPhase.Began)
                        {
                            Jump();
                        }
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    if (Input.touchCount > 1)
                    {
                        if (Input.GetTouch(1).position.x > Screen.width / 2 && (Input.GetTouch(1).position.x < Screen.width - 75 && Input.GetTouch(1).position.y < Screen.height - 75) && Input.GetTouch(1).phase == TouchPhase.Began)
                        {
                            Jump();
                        }
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (Input.touchCount > 1)
                    {
                        if (Input.GetTouch(1).position.x > Screen.width / 2 && (Input.GetTouch(1).position.x < Screen.width - 75 && Input.GetTouch(1).position.y < Screen.height - 75) && Input.GetTouch(1).phase == TouchPhase.Began)
                        {
                            Jump();
                        }
                    }
                }
                else if (Input.GetTouch(0).position.x > Screen.width / 2 && (Input.GetTouch(0).position.x < Screen.width - 75 && Input.GetTouch(0).position.y < Screen.height - 75) && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Jump();
                }

            }

            controller.Move((moveForward + moveUpward) * Time.deltaTime);
        }

    }

    public void run()
    {
        running = true;
    }

    void Rotate(float rotate)
    {
        //if(rotation + rotate * rotateSpeed * Time.deltaTime > -90.0f && rotation + rotate * rotateSpeed * Time.deltaTime < 90.0f)
        //{
            transform.Rotate(new Vector3(0.0f, rotate * rotateSpeed * Time.deltaTime, 0.0f), Space.Self);
            //rotation += rotate * rotateSpeed * Time.deltaTime;
        //}
        
    }

    void Jump()
    {
        if (jumped1)
        {
            moveUpward.y = Mathf.Sqrt(jumpSpeed * 2f * gravitySpeed);
            jumped1 = false;
            bodyAnimator.SetTrigger("Double Jump");
        }
        if (onGround)
        {
            moveUpward.y = Mathf.Sqrt(jumpSpeed * 2f * gravitySpeed) * .75f;
            jumped1 = true;
            bodyAnimator.SetTrigger("Jump");
        }
    }

    public void newPlatform(int newScore, Vector3 newCP) //, Vector3 checkPoint. Can rename this method to "new platform"
    {
        scoreModifier = newScore;
        lastLocation = newCP;
        lastRotation = this.transform.rotation;
        levels++;
        Debug.Log("Found newest checkpoint");
    }

    public void collect(bool isScore, int value)
    {
        if(isScore)
        {
            score += value;
        }
        else
        {
            gold += value;
        }
    }

    public void fell()
    {
        StopAllCoroutines();
        running = false;
        controller.enabled = false;
        this.transform.position -= new Vector3(0.0f, 10.0f, 0.0f);
        controller.enabled = true;

        if (score > highScore)
        {
            highScore = score;
        }
    }

    public void restartGame()
    {
        scoreModifier = 0;
        score = 0;
        levels = 0;

        controller.enabled = false;
        this.transform.position = new Vector3(0.0f, 0.0f, 5.0f);
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        controller.enabled = true;

        StartCoroutine(startCalculating());
    }

    public void continueGame()
    {
        StartCoroutine(continuing());
    }

    IEnumerator continuing()
    {
        controller.enabled = false;
        this.transform.position = lastLocation;
        this.transform.rotation = lastRotation;
        controller.enabled = true;

        yield return new WaitForSeconds(3.0f);

        running = true;
        StartCoroutine(startCalculating());

    }

}
