using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnimalSystem : MonoBehaviour {

    public List<GameObject> animals = new List<GameObject>();
    public GameObject catPrefab;

    public AudioManager aManager;
    public AudioClip catMeow;

    public GameObject[] positionsPossible;

    public List<GameObject> fullPositions = new List<GameObject>();

    public FoodManagement fManagement;

    public string[] names;

    public int waitTime = 30;

    [Header("Wave")]
    public int wave = 1; 

    public Vector3 randScreenPos;
    public GameObject randPosGameobject;

    public GameObject parentObject;

    public bool shelterFull;
    public int deadCats; // ;-;
    public int adoptedCats; //:)

	void Start () {

        waitTime = PlayerPrefs.GetInt("WaitTime"); 
        StartCoroutine("Clock");

        CreateNewAnimals(Random.Range(3,4));

        
	}

    private void Update()
    {
        if (fullPositions.ToArray().Length == 9)
        {
            shelterFull = true;
        }
        else
        {
            shelterFull = false;
        }

        for(int i = 0; i < animals.ToArray().Length; i++)
        {
            if(animals.ToArray()[i] == null)
            {
                animals.Remove(animals.ToArray()[i]);
                fullPositions.Remove(fullPositions.ToArray()[i]);
            }
        }
    }

    public void CreateNewAnimals(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            randPosGameobject = positionsPossible[Random.Range(0, positionsPossible.Length)];
            randScreenPos = randPosGameobject.transform.position;

            
                if (!fullPositions.ToArray().Contains(randPosGameobject))
                {
                    animals.Add(Instantiate(catPrefab, randScreenPos, gameObject.transform.rotation, parentObject.transform));
                    fullPositions.Add(randPosGameobject);
                
                }
                else
                {
                    i--;
                }
            

        }

        aManager.PlaySound(catMeow);
        GiveAnimalNewName();
    }

    

    public void GiveAnimalNewName()
    {
        for (int i = 0; i < animals.ToArray().Length; i++)
        {
            animals[i].GetComponent<Animal>().petName = names[Random.Range(0, names.Length)];

        }
    }

    private void IncreaseMinusSpeed()
    {
        for (int i = 0; i < animals.ToArray().Length; i++)
        {
            animals[i].GetComponent<Animal>().minusSpeed += Random.Range(0.5f, 0.8f);

        }
    }

    public void NewWave(int animalAmount)
    {
        wave++;
        waitTime -= waitTime / 5;
        IncreaseMinusSpeed();

        if (animals.ToArray().Length + animalAmount > 9)
        {
            CreateNewAnimals(9 - animals.ToArray().Length);
        }
        else
        {
            CreateNewAnimals(animalAmount);
        }
    }

    IEnumerator Clock()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            if(wave >= 7)
            {
                NewWave(5);
                
            }
            if(wave >= 5)
            {
                NewWave(4);
                
            }

            NewWave(3);  
        }
    }

    
}
