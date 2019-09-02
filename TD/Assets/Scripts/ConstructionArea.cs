using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionArea : MonoBehaviour
{
    public void Upgrade()
    {
        Debug.Log(gameObject.name + " Upgrade");
    }

    public void SetToArrow()
    {
        Debug.Log("Arrow tower");
    }

    public string WhatItIs()
    {
        return "ConstructionArea";
    }
}
