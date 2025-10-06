using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSystem : MonoBehaviour
{
    public int currentStrength = 3;
    public int currentAccuracy = 50;
    public static float currentStamina = 10f;
    public static bool canBuyAccuracy = false;
    private int[] strengthValues = new int[4] {3, 5, 7, 9};
    private int[] accuracyValues = new int[4] {50, 70, 90, 100};
    private float[] staminaValues = new float[4] {10f, 15f, 20f, 25f};
    private bool[] strengthBools = new bool[3] {false, false, false};
    private bool[] accuracyBools = new bool[3] {false, false, false};
    private bool[] staminaBools = new bool[3] {false, false, false};


    public void BuyStrenght(SkillsButton but)
    {
        for(int i = 0; i < but.id; i++)
        { 
            if(!strengthBools[i]) return;
        }
        if(strengthBools[but.id]) return;
        strengthBools[but.id] = true;
        but.UpdateUI(true);
        currentStrength = strengthValues[but.id+1];
        UpdateStats();
    }

    public void BuyAccuracy(SkillsButton but)
    {
        if (canBuyAccuracy)
        {
            for(int i = 0; i < but.id; i++)
            {
                if(!accuracyBools[i]) return;
            }
            if(accuracyBools[but.id]) return;
            accuracyBools[but.id] = true;
            but.UpdateUI(true);
            currentAccuracy = accuracyValues[but.id+1];
            UpdateStats();
        }
        
    }

    public void BuyStamina(SkillsButton but)
    {
        for(int i = 0; i < but.id; i++)
        {
            if(!staminaBools[i]) return;
        }
        if(staminaBools[but.id]) return;
        staminaBools[but.id] = true;
        but.UpdateUI(true);
        currentStamina = staminaValues[but.id+1];
        UpdateStats();
    }

    public void UpdateStats()
    {
        CombatSystem cs = FindAnyObjectByType<CombatSystem>();
        cs.UpdateSkills(currentStrength,currentAccuracy);
    }
}