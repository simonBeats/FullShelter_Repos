using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour {

    public AnimalSystem aSystem;
    public GameObject startCanvas;
    public GameObject endCanvas;

    public Slider deadCatsDisplay;
    public Text deadDisplayText;
    public Text adoptedDisplayText;

    private void Update()
    {
        deadCatsDisplay.value = 10 - aSystem.deadCats;

        if(aSystem.deadCats >= 10)
        {
            GameOver();
        }

        deadDisplayText.text = "Cats dead: " + aSystem.deadCats;
        adoptedDisplayText.text = "Cats adopted: " + aSystem.adoptedCats;
    }

    public void GameOver()
    {
        startCanvas.SetActive(false);
        endCanvas.SetActive(true);

        aSystem.StopAllCoroutines();
        aSystem.animals.Clear();
        
        
    }
}
