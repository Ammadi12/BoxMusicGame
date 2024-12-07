using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform endPoint;
    public GameObject player;

    public void LoseGame()
    {
        Debug.Log("Game Over! Volume reached the maximum.");
        Time.timeScale = 0;
    }
    void Update()
    {
        // Win condition
        if (player.transform.position.z >= endPoint.position.z)
        {
            WinGame();
        }
    }
    private void WinGame()
    {
        Debug.Log("You Win! Level Complete.");
        Time.timeScale = 0;
    }
}
