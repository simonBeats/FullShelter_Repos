using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManagement : MonoBehaviour {

    public int foodResources = 1000;
    public float waterResources;

    public ClickOnAnimal cOnAnimal;

    public Button feedB;
    public Button waterB;

    public AudioManager aManager;
    public AudioClip giveResource;

    public Text foodT;

    void Start()
    {
        waterResources = Mathf.Infinity;
    }

    private void Update()
    {
        foodT.text = foodResources.ToString();

        if(cOnAnimal.selectedAnimal == null)
        {
            return;
        }

        if(foodResources <= 0 || cOnAnimal.selectedAnimal.food >= 100)
        {
            feedB.interactable = false;
        }
        else
        {
            feedB.interactable = true;
        }

        if (cOnAnimal.selectedAnimal.water >= 100)
        {
            waterB.interactable = false;
        }
        else
        {
            waterB.interactable = true;
        }


    }

    public void Feed()
    {
        cOnAnimal.selectedAnimal.food += 10;
        foodResources -= 10;
        aManager.PlaySound(giveResource);
    }

    public void GiveWater()
    {
        cOnAnimal.selectedAnimal.water += 10;
        waterResources -= 10;
        aManager.PlaySound(giveResource);
    }
}
