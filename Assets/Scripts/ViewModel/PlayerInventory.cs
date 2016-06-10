﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;
    [SerializeField] private GameObject inventoryList;
    [SerializeField] private CreatureList creatureList;


    // Use this for initialization
    void Start()
    {
        creatureList = new CreatureList();
        PopulatePlayerInventory(creatureList);
    }


    private void PopulatePlayerInventory(CreatureList list)
    {
        list.AddCreature(CreatureManager.Manager.GetCreatureOfType(CreatureType.Slime));
        list.AddCreature(CreatureManager.Manager.GetCreatureOfType(CreatureType.Slime));

        foreach (var creature in creatureList.Creatures)
        {
            GameObject newCreaturePanel = CreateCreatureObject(creature);
            newCreaturePanel.transform.SetParent(inventoryList.transform, false);

        }
    }

    private GameObject CreateCreatureObject(Creature creature)
    {
        if (creaturePrefab == null)
            return null;

        GameObject newCreature = GameObject.Instantiate(creaturePrefab);
        newCreature.name = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Name").gameObject.GetComponent<Text>().text = creature.CreatureName;
        newCreature.transform.Find("CreatureInfo/Price/Price").gameObject.GetComponent<Text>().text = creature.CurrentValue.ToString();
        //TODO: Add creature Icon to prefab;
        //TODO: Add event handling to prefab;

        return newCreature;
    }

}