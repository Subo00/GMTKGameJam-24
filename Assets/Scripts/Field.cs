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

    protected override void Start()
    {
        collector = GetComponentInChildren<CollectorCollider>();
        if( collector == null )
        {
            Debug.LogError("Collector not properly set up");
        }

        collector.SetNeededItems(new List<ItemStack> { new ItemStack(appleData, neededNumber) });
        base.Start();
    }

    public void ReportBool(bool value)
    {
        currentNumber++;
        if(value)
        {
            Debug.Log("LEVEL UP");
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
