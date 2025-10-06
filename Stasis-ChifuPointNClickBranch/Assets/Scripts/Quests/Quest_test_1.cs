using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;

public class Quest_test_1 : MonoBehaviour
{
    public static int quest_test_1_stage = 0;
    
    private void Awake()
    {
        print("Test Quest 1 started!");
        quest_test_1_stage = 10;
    }

    void Update()
    {
        if (quest_test_1_stage != 0 && quest_test_1_stage != 255)
        {
            if (Player.coins == 1)
            {
                print("Test quest 1 completed!");
                quest_test_1_stage = 255;
            }
        }
    }
}
