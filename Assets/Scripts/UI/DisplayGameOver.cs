using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayGameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button yesBtn;
    [SerializeField] private Button noBtn;
   
    private void Start()
    {
        Initialize();

        FindObjectOfType<PlayerHealth>().onDead += ShowGameOver;
    }

    private void Initialize()
    {
        gameOverPanel.SetActive(false);
        yesBtn.onClick.AddListener(Retry);
        noBtn.onClick.AddListener(MainMenu);
    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    private void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
