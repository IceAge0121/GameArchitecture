using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStrategy : IAnimalStrategy
{
    public void Walk()
    {
        Debug.Log("Dog can walk!");
    }
}
