using SmallHedge.SoundManager;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static SourceBase;

public class SourceBush : SourceBase
{
    public override void DropResource(float dummy)
    {
        StartCoroutine(DropResourcesCoroutine());
        base.DropResource(dummy);
    }

    private IEnumerator DropResourcesCoroutine()
    {
        float randNum = Random.Range(0.01f, 1f);

        foreach (var resource in resourceDrops)
        {
            if (resource.dropChance < randNum) continue;

            GameObject itemToDrop = itemManager.GetGameObject(resource.item.id);

            for (uint i = 0; i < resource.value; i++)
            {
                GameObject drop = Instantiate(itemToDrop, dropPoint.position, Quaternion.identity);
                Vector3 rotation = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                drop.GetComponent<ItemPickUp>().LaunchInDirection(rotation);

                SoundManager.PlaySound(SoundType.DropApple);
                yield return new WaitForSeconds(0.5f); 
            }
        }
    }

    public void BeforDestroy()
    {
        UIManager.Instance.HideInteraction();
        UpdateManager.Instance.RemoveUpdatable(this);
    }
}
