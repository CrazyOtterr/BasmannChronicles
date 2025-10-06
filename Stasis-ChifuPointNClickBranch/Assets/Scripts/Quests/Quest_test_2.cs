using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_test_2 : MonoBehaviour
{
    public static int quest_test_2_stage = 0;
    private bool d = false;

    void Update()
    {
        if (quest_test_2_stage == 10)
        {
            if (Player.coins == 3)
            {
                quest_test_2_stage = 20;
            }
        }
        if (quest_test_2_stage == 255 && !d)
        {
            SkillSystem.canBuyAccuracy = true;
            d = true;
        }
    }
}
