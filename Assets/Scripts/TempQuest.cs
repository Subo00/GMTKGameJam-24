using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TempQuest : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject progressText;

    //Clouds unlocking
    [SerializeField] GameObject cloudGOParent;
    [SerializeField] private GameObject[] clouds;

    private int current = 0;
    private static int goal = 100;
    private int check = 1;
    private int index = 0;

    public static TempQuest Instance;

    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
       
        foreach(GameObject cloud in clouds)
        {
            cloud.SetActive(false);
        }
    }

    public void OnTreeSpawn()
    {
        current++;
        UpdateScore();
        CheckCloud();
    }

    private void UpdateScore()
    {
        Debug.Log(current + " / " + goal);
        progressText.GetComponent<TextMeshProUGUI>().text = current.ToString() + " / " + goal.ToString(); 
        if(current == goal)
        {
            winScreen.SetActive(true);
        }
    }

    private void CheckCloud()
    {
        if(current == check)
        {
            clouds[index].SetActive(true);
            check *= 2;
            index++;
        }
    }
}
