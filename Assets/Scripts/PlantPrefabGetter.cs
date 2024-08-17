using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPrefabGetter : MonoBehaviour
{
    public static PlantPrefabGetter Instance;

    public GameObject Level1Prefab;
    public GameObject Level2Prefab;
    public GameObject Level3Prefab;
    public GameObject Level4Prefab;

    private void Awake()
    {
        Instance = this; 
    }

    public GameObject getPlant(int level)
    {
        switch (level)
        {
            case 1:
                return Level1Prefab;
            case 2:
                return Level2Prefab;
            case 3:
                return Level3Prefab;
            case 4:
                return Level4Prefab;
        }
        return null;
    }
}
