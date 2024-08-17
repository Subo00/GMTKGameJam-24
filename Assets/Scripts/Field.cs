using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : Interactable, Master
{
    CollectorCollider collector;
    public ItemData appleData;
    public ItemData waterData;
    public uint neededNumber = 3;
    private uint currentNumber = 0;

    PlantPrefabGetter plantPrefabGetter;
    GameObject plantGO = null;

    private int currentLevel = 0;

    protected override void Start()
    {
        collector = GetComponentInChildren<CollectorCollider>();
        if( collector == null )
        {
            Debug.LogError("Collector not properly set up");
        }

        collector.SetNeededItems(new List<ItemStack> { new ItemStack(appleData, neededNumber) });
        plantPrefabGetter = PlantPrefabGetter.Instance;

        base.Start();
        inUse = true;
    }

    public void ReportBool(bool value)
    {
        currentNumber++;
        if(value)
        {
            currentLevel++;
            if(plantGO != null)
            {
                Destroy(plantGO);
                plantGO = null;
            }
            Vector3 colliderPosition = collector.transform.position;
            colliderPosition.y = 0.01f;
            Quaternion playerRot = transform.rotation;

            plantGO = Instantiate(plantPrefabGetter.getPlant(currentLevel), colliderPosition, playerRot);
            collector.SetNeededItems(new List<ItemStack> { new ItemStack(waterData, neededNumber) });

        }
        else
        {
            
        }
    }

    protected override void OnUpdate()
    {
        if(currentNumber < neededNumber)
        {
            uiManager.ShowProgressOnObjedct(dropPoint, (int)currentNumber, (int)neededNumber, currentLevel == 0 ? appleData.name : waterData.name);

        }else
        {
            CommonLogic();
        }
    }
}
