using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnAnimal : MonoBehaviour
{

    public GameObject gameObjectcliked;

    public Animal selectedAnimal;
    public InfoPanel infoP;
   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                



                if (hit)
                {
                    gameObjectcliked = hit.collider.gameObject;

                    
                if (hit.collider.tag == null)
                {
                        return;
                }

                    if(hit.collider.tag == "Animal")
                {
                    
                    selectedAnimal = hit.collider.gameObject.GetComponent<Animal>();

                    infoP.SetNewAnimal(selectedAnimal);
                    
                }

                }

            
        }
    }
    

}