using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health 3";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int playerHealth)
    {
        healthText.text = "Health " + playerHealth.ToString();
    }
}
