using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public int difficultyIndex = 1;
    public string[] difficulties;
    public string difficultyString;

    public int[] difficultiesValues;


    public Text display;

    private void Update()
    {
        difficultyString = difficulties[difficultyIndex];
        display.text = difficultyString;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("WaitTime", difficultiesValues[difficultyIndex]);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeDifficulty(bool up)
    {
        if (up)
        {
            if(difficultyIndex == difficulties.Length - 1)
            {
                difficultyIndex = 0;
                return;
            }
            difficultyIndex++;
        }

        if (!up)
        {
            if (difficultyIndex == 0)
            {
                difficultyIndex = difficulties.Length - 1;
                return;
            }
            difficultyIndex--;
        }
    }
}
