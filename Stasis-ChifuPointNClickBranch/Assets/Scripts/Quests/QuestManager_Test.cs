using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager_Test : MonoBehaviour
{
    public void SetStage(int quest_id, int new_stage_value)
    {
        if (quest_id == 1) {
            Quest_test_1.quest_test_1_stage = new_stage_value;
        }
        if (quest_id == 2) {
            Quest_test_2.quest_test_2_stage = new_stage_value;
        }
    }
    
    public int CheckStage(int quest_id)
    {
        if (quest_id == 1)
        {
            return Quest_test_1.quest_test_1_stage;
        }
        if (quest_id == 2)
        {
            return Quest_test_2.quest_test_2_stage;
        }
        return -1;
    }
}