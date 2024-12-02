using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coins = 0;
    public TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            Debug.Log("Coin");
            coins++;
            coinText.text = "COIN: " + coins.ToString();
            Destroy(collision.gameObject);

        }
    }
}
