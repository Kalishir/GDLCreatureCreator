﻿using UnityEngine;
using UnityEngine.Assertions;

public class CreatureManager : MonoBehaviour
{
    [SerializeField] private GameObject creaturePrefab;

    private void Start()
    {
        // TODO: Remove test.
        Creature creature = SpawnCreature("Dragon");
        Creature creature2 = SpawnCreature("Dragon");
        Creature babyCreature = Breed(creature, creature2);
        Assert.IsNotNull(babyCreature, "Breeding failed!");
    }

    /// <summary>
    /// Spawns a creature into the scene.
    /// </summary>
    /// <param name="fileName">The json filename of the creature without extension.</param>
    private Creature SpawnCreature(string fileName)
    {
        GameObject creatureGameObject = Instantiate(creaturePrefab);
        var creatureData = JsonUtility.FromJson<CreatureData>(Resources.Load<TextAsset>(fileName).text);
        var creature = creatureGameObject.GetComponent<Creature>();
        creature.SetCreatureData(creatureData);

        return creature;
    }

    /// <summary>
    /// Breeds two creatures and creates a new one.
    /// </summary>
    /// <returns>The newly created creature. Returns null if creature types do not match.</returns>
    public Creature Breed(Creature creature1, Creature creature2)
    {
        Creature retVal = null;
        if (creature1.Type == creature2.Type)
        {
            retVal = SpawnCreature(creature1.Type.ToString());
        }
        return retVal;
    }
}
