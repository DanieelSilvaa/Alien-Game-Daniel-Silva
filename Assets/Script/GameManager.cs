using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject buttonNext;
    [SerializeField] Spaceship player;
    [SerializeField] int cantEn;

    Animal animal;
    bool finish = false;
    bool gameP = false;
    
   

    // Start is called before the first frame update
    void Start()
    {
        
        canvas.SetActive(false);
        buttonNext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && finish == false)
        {
            PauseGame();
        }
        
    }
    public void StartGame()
    {
       
        SceneManager.LoadScene(1);
       


    }
    void PauseGame()
    {
        gameP = gameP ? false : true;
        canvas.SetActive(gameP);
        player.gamePaused = gameP;
        Time.timeScale = gameP ? 0 : 1;
    }
   public void ReducirNumEnemigos()
    {
        cantEn --;
        if (cantEn < 1)
        {
            Win();
            
        }
    }
    void Win()
    {

        buttonNext.SetActive(true);
        player.gamePaused = true;
        finish =! finish;
        Time.timeScale = 0;
      
    }
    public void NextLevel(int level)
    {

       
        player.gamePaused = false;
        Time.timeScale = 1;

        SceneManager.LoadScene(level);
    }
}
