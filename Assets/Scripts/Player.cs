using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public int health = 3;
    public GameObject panel;
    public bool show;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Cursor.visible = false;
        show = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShowPanelRoutine());
    }
    public void RemoveHealth (int playerHealth)
    {
        health -= playerHealth;
        gameManager.UpdateHealth(health);

    }

    public void AddHealth(int playerHealth)
    {
        health += playerHealth;
        gameManager.UpdateHealth(health);

    }

    IEnumerator ShowPanelRoutine()
    {
        if(show == true)
        {
            panel.SetActive(true);
            yield return new WaitForSeconds(10);
            panel.SetActive(false);
            show = false;
        }
    }
}
