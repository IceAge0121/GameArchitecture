using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalExamples : MonoBehaviour
{
    IAnimalStrategy animalStrategy;

    // Start is called before the first frame update
    void Start()
    {
        animalStrategy = new LionStrategy();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            animalStrategy = new LionStrategy();
            UpdateAnimalBehaviour();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            animalStrategy = new CatStrategy();
            UpdateAnimalBehaviour();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animalStrategy = new DogStrategy();
            UpdateAnimalBehaviour();
        }
    }

    void UpdateAnimalBehaviour()
    {
        animalStrategy.Walk();
    }
}
