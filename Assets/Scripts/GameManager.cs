using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework.Internal.Filters;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

    public GameManager gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public Button reiniciarButton;
    public Button menuButton;

    private bool gameOverActivo = false;

    void Amake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        if (gameOverPanel != null) 
            gameOverPanel.setActive(false);

        if (reiniciarButton != null)
            reiniciarButton.onClick.AddListener(ReiniciarEscen);

        if (menuButton != null)
            menuButton.onClick.AddListener(IrAlMenu);
    }

    private void Update()
    {
        if (gameOverActivo)
        {
            ReiniciarEscen();
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M))
        {
            IrAlMenu();
        }
    }

    public void GameOver()
    {
        if (gameOverActivo) return;
        gameOverActivo=true;

        if (gameOverPanel != null)
        {
            gameOverPanel.setActive(true);
        }

        if (gameOverText != null)
        {
            gameOverText.text = "GAME OVER\n\nR - Reiniciar\nESC - Menu Principal"; 
        }
    }

    private void setActive(bool v)
    {
        throw new NotImplementedException();
    }

    void ReiniciarEscen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}