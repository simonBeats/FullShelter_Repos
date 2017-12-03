using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour {

    public string petName;

    public float food;
    public float water;

    public bool dog;

    public float minusSpeed = 1f;

    public GameObject imHungry;
    public GameObject imThirsty;
    public GameObject loveMe;

    public AudioClip dieSound;
    public AudioClip adoptSound;

    public int dieCountDown = 15;
    public int adoptCountDownBuffer;
    public int adoptCountDown;
    public bool unhappy = false;

    public bool happy = true;

    [SerializeField]
    private bool dieCountDownStarted = false;
    [SerializeField]
    private bool adoptCountDownStarted = false;

    void Start()
    {
        StartCoroutine("ValuesMinus");
        adoptCountDownBuffer = Random.Range(11, 17);
        adoptCountDown = adoptCountDownBuffer;
    }


    private void Update()
    {
        if(food < 20)
        {
            imHungry.SetActive(true);
        }
        else
        {
            imHungry.SetActive(false);
        }

        if (water < 20)
        {
            imThirsty.SetActive(true);
        }
        else
        {
            imThirsty.SetActive(false);
        }

        if(food > 85 && water > 85)
        {
            happy = true;
        }
        else
        {
            happy = false;
        }

        loveMe.SetActive(false);

        if(food <= 0 || water <= 0)
        {
            unhappy = true;
        }
        else
        {
            unhappy = false;
        }

        // Check for unhappy

        if(unhappy == true &&  !dieCountDownStarted)
        {
            StartCoroutine("ZeroHungerThirst");
        }
        if(unhappy == false)
        {
            StopCoroutine("ZeroHungerThirst");
            dieCountDown = 15;
            dieCountDownStarted = false;
        }

        if(dieCountDown == 0)
        {
            Die();
        }

        // Check for happy

        if (happy == true && !adoptCountDownStarted)
        {  
            StartCoroutine("WaitForAdoption");
        }
        if (happy == false && !dieCountDownStarted)
        {
            StopCoroutine("WaitForAdoption");
            adoptCountDown = adoptCountDownBuffer;
            adoptCountDownStarted = false;
        }

        if (adoptCountDown == 0)
        {
            GetAdopted();
        }
    }

    public void Die()
    {
        GetComponentInParent<AnimalSystem>().deadCats++;
        Debug.Log("A cat died");
        Destroy(gameObject);
        GetComponentInParent<AudioManager>().PlaySound(dieSound);
    }

    private void GetAdopted()
    {
        GetComponentInParent<AnimalSystem>().adoptedCats++;
        GetComponentInParent<FoodManagement>().foodResources += 250;
        GetComponentInParent<AudioManager>().PlaySound(adoptSound);
        Debug.Log("A cat got adopted :)");
        Destroy(gameObject);
    }

    IEnumerator ValuesMinus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if(food >= 0)
            {
                food -= 1 * minusSpeed;
            }
            if(water >= 0)
            {
                water -= 2 * minusSpeed;
            }
            
        }
    }

    IEnumerator WaitForAdoption()
    {
        adoptCountDownStarted = true;
        while (true)
        {
            yield return new WaitForSeconds(1);
            adoptCountDown--;
        }
    }

    IEnumerator ZeroHungerThirst()
    {
        dieCountDownStarted = true;
        while (true)
        {
            yield return new WaitForSeconds(1);
            dieCountDown--;
        }
    }
}
