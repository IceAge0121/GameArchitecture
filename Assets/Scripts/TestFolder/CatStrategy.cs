using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStrategy : IAnimalStrategy
{
    public void Walk()
    {
        Debug.Log("Cat can walk!");
    }
}
