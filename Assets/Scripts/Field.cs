using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : Interactable, Master
{
    CollectorCollider collector;
    public ItemData data;
    public uint stackNum = 3;

    protected override void Start()
    {
        collector = GetComponentInChildren<CollectorCollider>();
        if( collector == null )
        {
            Debug.LogError("Collector not properly set up");
        }

        collector.SetNeededItems(new List<ItemStack> { new ItemStack(data, stackNum) });
        base.Start();
    }

    public void ReportBool(bool value)
    {
        if(value)
        {
            Debug.Log("LEVEL UP");
        }
        else
        {
            Debug.Log("NOT YET");
        }
    }

    protected override void OnUpdate()
    {
        
    }
}
