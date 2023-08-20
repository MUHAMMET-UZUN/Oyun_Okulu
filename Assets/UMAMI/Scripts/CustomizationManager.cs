using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    public GameObject hatSlot;
    public GameObject[] hats;

    public void WearHat(int index)
    {
        hats[index].SetActive(true);

        for (int i = 0; i < hats.Length; i++)
        {
            if (i == index) continue;
            hats[i].SetActive(false);
        }
    }
}
