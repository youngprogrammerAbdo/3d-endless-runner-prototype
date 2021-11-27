using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button PlayAgain;
    [SerializeField] private GameObject endGameUI;
    public bool gameEnded=false;
    public float pathSidesValue = 2;
    public float swipeLenght = 100;
    [SerializeField] private AudioClip Lose;
    private AudioSource sr;
    private void Start()
	{
        PlayAgain.onClick.AddListener(playAgain);
        sr = GetComponent<AudioSource>();
    }
    // Singleton Desgin Pattern To manage Game
	private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    public void endTheGame() 
    {
        sr.PlayOneShot(Lose);
        ObstaclesManager.Instance.StopCreatingObstacle();
        Time.timeScale = 0;
        endGameUI.SetActive(true);
        gameEnded = true;
    }
    private void playAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
