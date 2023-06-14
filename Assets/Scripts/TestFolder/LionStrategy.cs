using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionStrategy : IAnimalStrategy
{
    public void Walk()
    {
        Debug.Log("Lion can walk!");
    }
}
