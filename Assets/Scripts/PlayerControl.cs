using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float sidewaysSpeed = 10;
    public float turnSpeed;

    public float maxWheelTurningAngle = 30f;
    private float maxCarTurningAngle = 15f;
    public GameObject frontWheelR;
    public GameObject frontWheelL;
    private Vector3 defaultWheelAngle;
    private Vector3 defaultCarAngle;
    private Vector3 defaultCarPosition;

    private float lrInput;
    public bool gameOver = false;

    private int coins = 0;
    public TextMeshProUGUI coinText;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip crash;
    public AudioClip turningSound;
    public AudioClip engineSound;

    public GameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        //receives initial angles for wheels and car and car position
        defaultWheelAngle = frontWheelL.transform.localEulerAngles;
        defaultCarAngle = transform.localEulerAngles;
        defaultCarPosition = transform.position;

        playerAudio = GetComponent<AudioSource>();
        StartCoroutine(RepeatSound(engineSound));
    }

    // Update is called once per frame
    void Update()
    {
        lrInput = Input.GetAxis("Horizontal");

        if (!gameOver) {
            // Keeps the car in place on the x-axis
            transform.position = new Vector3(defaultCarPosition.x, transform.position.y, transform.position.z);

            // Moves the car left and right within an allowed range
            if (transform.position.z > -101 && transform.position.z < -79)
            {
                transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed * lrInput);
            }
            else
            {
                transform.localEulerAngles = defaultCarAngle;
            }

            // Rotates car when input is received, but resets to face forward if no input
            if (transform.localEulerAngles.y > defaultCarAngle.y - maxCarTurningAngle
                && transform.localEulerAngles.y < defaultCarAngle.y + maxCarTurningAngle)
            {
                transform.Rotate(Vector3.up, turnSpeed * lrInput * Time.deltaTime);
            }
            if (lrInput == 0)
            {
                transform.localEulerAngles = defaultCarAngle;
            }

            // Front wheels turning based on input
            if (lrInput < 0) // Turns left
            {
                frontWheelL.transform.localEulerAngles =
                    new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxWheelTurningAngle, defaultWheelAngle.z);
                frontWheelR.transform.localEulerAngles =
                    new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxWheelTurningAngle, defaultWheelAngle.z);
                playerAudio.PlayOneShot(turningSound, .02f);
            }
            else if (lrInput > 0) // Turns right
            {
                frontWheelL.transform.localEulerAngles =
                    new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxWheelTurningAngle, defaultWheelAngle.z);
                frontWheelR.transform.localEulerAngles =
                    new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxWheelTurningAngle, defaultWheelAngle.z);
                playerAudio.PlayOneShot(turningSound, .02f);
            }
            else
            { // Brings wheels back to default angle when no input
                frontWheelL.transform.localEulerAngles = defaultWheelAngle;
                frontWheelR.transform.localEulerAngles = defaultWheelAngle;
                StopCoroutine(RepeatSound(engineSound));
            }
        }
    }

    // OnCollisionEnter must be outside of the Update method
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crash, 1.0f);
            Debug.Log("Game Over!!");
            gamemanager.gameOver();
            // Pause the game
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Money"))
        {
            playerAudio.PlayOneShot(moneySound, 1.0f);
            coins++;
            coinText.text = "Coins: " + coins;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator RepeatSound(AudioClip clip)
    {
        while (true)
        {
            playerAudio.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length);
        }
    }
}