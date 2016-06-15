﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// just references to images and such
/// </summary>
public class HolderOfThings : MonoBehaviour
{
    [SerializeField]
    private Image creatureBackground;
    [SerializeField]
    private Image creatureImage;
    
    private string uniqueID;

    public Image CreatureImage
    {
        get { return creatureImage; }
    }
    public Image CreatureBackground
    {
        get { return creatureBackground; }
    }

    public string UniqueID
    {
        get { return uniqueID; }
        set { uniqueID = value; }
    }
}