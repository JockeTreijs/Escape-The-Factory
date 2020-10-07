using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text healthText;
    public Player player;
    private Button startButton;
    private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health 3";

        player = GameObject.Find("Player").GetComponent<Player>();

        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);

        quitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    public void UpdateHealth(int playerHealth)
    {
        healthText.text = "Health " + playerHealth.ToString();
    }

    public void GameOver()
    {
        if (player.health <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
