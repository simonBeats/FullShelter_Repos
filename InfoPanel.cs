using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoPanel : MonoBehaviour {

    public Animal selectedAnimal;
    public GameObject info;

    public string animalName;
    public int animalFood;
    public int animalWater;

    public bool animalIsDog;

    public Text nameText;
    

    public Slider foodSlider;
    public Slider waterSlider;

    public void SetNewAnimal(Animal select)
    {
        selectedAnimal = select;
        info.SetActive(true);
    }

    public void CloseInfoPanel()
    {
        selectedAnimal = null;
    }

    private void Update()
    {
        if(selectedAnimal != null)
        {
            nameText.text = "Name: " + selectedAnimal.petName;
            foodSlider.value = selectedAnimal.food;
            waterSlider.value = selectedAnimal.water;

        }
        else
        {
            info.SetActive(false);
            
        }
    }


    
}
