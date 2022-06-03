using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button quitBtn;

    private void Start()
    {
        playBtn.onClick.AddListener(Play);
        settingBtn.onClick.AddListener(Options);
        quitBtn.onClick.AddListener(Quit);
    }

    private void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
