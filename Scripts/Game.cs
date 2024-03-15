using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private int score;
    private int enemiesKilled = 0;
    private int lives = 5; // Vidas iniciales
    public Text textScore;
    public Text textLives;
    private bool gameEnded = false;

    void Start()
    {
        UpdateLivesUI();
    }

    public void AddScore()
    {
        score++;
        textScore.text = "Score : " + score;

        enemiesKilled++;
        if (enemiesKilled >= 5 && !gameEnded)
        {
            EndGame();
        }
    }


    private void UpdateLivesUI()
    {
        textLives.text = "Lives : " + lives;
    }

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
        // Aquí podrías llamar a un método para mostrar una pantalla de fin de juego, cargar una nueva escena, etc.
    }
}
