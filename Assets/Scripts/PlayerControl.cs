using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    bool gameFinishedSoundPlayed = false;

    bool CrashPlayed;
    private int coins = 0;
    public int coinsToNextLevel = 10;
    public TextMeshProUGUI coinText;
    public GameObject nextLevelPanel;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip crash;
    public AudioClip turningSound;
    public AudioClip engineSound;
    public AudioClip borderBumpingSound;
    public AudioClip GameStart;

    public ParticleSystem Explosion;
    public ParticleSystem Fire;
    public ParticleSystem CaughtCoin;
    public ParticleSystem LeftWheelSmoke;
    public ParticleSystem RightWheelSmoke;
    public ParticleSystem LeftBorderContact;
    public ParticleSystem RightBorderContact;

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

        CrashPlayed = false;

        playerAudio.PlayOneShot(GameStart, 1f);

    }

// Update is called once per frame
void Update()
    {
        lrInput = Input.GetAxis("Horizontal");

        if (!gameOver) {
            //keeps the car in place on the x-axis
            transform.position = new Vector3(defaultCarPosition.x, transform.position.y, transform.position.z);

            //moves the car left and right within an allowed range
            if (transform.position.z > -101 && transform.position.z < -79)
            {
                transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed * lrInput);
            }
            else
            {
                if (transform.position.z < -101)
                {
                    LeftBorderContact.Play();
                    transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed * 1);
                }
                else
                {
                    RightBorderContact.Play();
                    transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed * -1);
                }
                transform.localEulerAngles = defaultCarAngle;
                playerAudio.PlayOneShot(borderBumpingSound, 0.03f);
            }


            //rotates car when input is received, but resets to face forward if no input
            if (transform.localEulerAngles.y > defaultCarAngle.y - maxCarTurningAngle
                && transform.localEulerAngles.y < defaultCarAngle.y + maxCarTurningAngle)
            {
                transform.Rotate(Vector3.up, turnSpeed * lrInput * Time.deltaTime);
            }
            if (lrInput == 0)
            {
                transform.localEulerAngles = defaultCarAngle;
            }

            //front wheels turning based on input
            if (lrInput < 0) //turns left
            {
                frontWheelL.transform.localEulerAngles =
                    new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxWheelTurningAngle, defaultWheelAngle.z);
                frontWheelR.transform.localEulerAngles =
                    new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxWheelTurningAngle, defaultWheelAngle.z);
                playerAudio.PlayOneShot(turningSound, .02f);
                LeftWheelSmoke.Play();
                RightWheelSmoke.Play();
            }
            else if (lrInput > 0) //turns right
            {
                frontWheelL.transform.localEulerAngles =
                    new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxWheelTurningAngle, defaultWheelAngle.z);
                frontWheelR.transform.localEulerAngles =
                    new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxWheelTurningAngle, defaultWheelAngle.z);
                playerAudio.PlayOneShot(turningSound, .02f);
                LeftWheelSmoke.Play();
                RightWheelSmoke.Play();
            }
            else
            { //brings wheels back to default angle when no input
                frontWheelL.transform.localEulerAngles = defaultWheelAngle;
                frontWheelR.transform.localEulerAngles = defaultWheelAngle;
                StopCoroutine(RepeatSound(engineSound));
            }
        }
        if (gameOver)
        {
            //Explosion particle system gets detached from time to make it run even after Time.timeScale = 0;
            Explosion.Simulate(Time.unscaledDeltaTime, true, false);
            Fire.Simulate(Time.unscaledDeltaTime, true, false);
            LeftWheelSmoke.Simulate(Time.unscaledDeltaTime, true, false);
            RightWheelSmoke.Simulate(Time.unscaledDeltaTime, true, false);
            LeftBorderContact.Simulate(Time.unscaledDeltaTime, true, false);
            RightBorderContact.Simulate(Time.unscaledDeltaTime, true, false);

            //stops the sound
            if (!CrashPlayed) {
                playerAudio.Stop();
                playerAudio.PlayOneShot(crash, 1.0f);
                CrashPlayed = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Explosion.Play();
            Fire.Play();
            Debug.Log("Game Over!!");
            gamemanager.gameOver();
            //Stop the time
            Time.timeScale = 0;
            //this is to stop the all the game sounds and play
            //only the sound that indicated that game has finished
            if (!gameFinishedSoundPlayed)
            {
                playerAudio.Stop();
                playerAudio.PlayOneShot(crash, 1.0f);
                gameFinishedSoundPlayed = true;
            }
        }

        if (collision.gameObject.CompareTag("Money"))
        {
            CaughtCoin.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            coins++;
            coinText.text = "Coins: " + coins + " / 10";
            Destroy(collision.gameObject);

            if (coins >= coinsToNextLevel)
            {
                Time.timeScale = 0;
                nextLevelPanel.SetActive(true);
                //this is to stop the all the game sounds and play
                //only the sound that indicated that game has finished
                if (!gameFinishedSoundPlayed) {
                    playerAudio.Stop();
                    playerAudio.PlayOneShot(moneySound, 1.0f);
                    gameFinishedSoundPlayed = true;
                }
            }
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