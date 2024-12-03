/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coins = 0;
    public TextMeshProUGUI coinText;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            if (moneySound != null)
            {
                playerAudio.PlayOneShot(moneySound, 1.0f);
            }
            else
            {
                Debug.LogWarning("Money Sound is not assigned in the Inspector!");
            }

            coins++;
            coinText.text = "Coins: " + coins;
            Destroy(collision.gameObject);
        }
    }

}
*/