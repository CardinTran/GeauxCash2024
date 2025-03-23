using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;

    public void GameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("GameOverUI is not assigned in GameManager!");
        }
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameOver();
        }
    }

}
