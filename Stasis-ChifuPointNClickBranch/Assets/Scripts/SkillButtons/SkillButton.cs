using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsButton : MonoBehaviour
{
    public int id;
    public Color notColor,gotColor;
    public void UpdateUI(bool isGot)
    {
        GetComponent<Image>().color = isGot ? gotColor : notColor;
    }
}