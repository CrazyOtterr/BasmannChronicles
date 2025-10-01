using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TMP_Text coin_text;
    // public GameObject spawn_point;
    public static int coins = 0;
    public static int hp = 100;
    public static float stamina = SkillSystem.currentStamina;
    public static float realStamina = SkillSystem.currentStamina;
    [SerializeField] private Image _health;
    [SerializeField] private Image _stamina;
    private float Full;
    public static bool isHitRight = false;
    public static bool isHitLeft = false;
    public static bool isHitFront = false;
    public static bool isHitBack = false;
    public static int receivedDamage;
    bool alreadyTookDamage = false;
    public static bool canStaminaReplenish = true;
    public GameObject rightPanel;
    public GameObject leftPanel;
    public GameObject frontPanel;
    public GameObject backPanel;

    void Awake()
    {
        Full = hp;
    }

    void Update()
    {
        if (realStamina < 0)
        {
            realStamina = 0;
        }
        if (realStamina != SkillSystem.currentStamina && canStaminaReplenish)
        {
            realStamina += Time.deltaTime * 1f;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SelfDamage();
        }

        coin_text.text = coins.ToString();
        // if (hp <= 0)
        //     Respawn();

        if (!alreadyTookDamage)
        {
            if (isHitRight)
            {
                isHitRight = false;
                rightPanel.SetActive(true);
                rightDamage(receivedDamage);
            }

            if (isHitLeft)
            {
                isHitLeft = false;
                leftPanel.SetActive(true);
                leftDamage(receivedDamage);
            }
            
            if (isHitFront)
            {
                isHitFront = false;
                frontPanel.SetActive(true);
                frontDamage(receivedDamage);
            }
            
            if (isHitBack)
            {
                isHitBack = false;
                backPanel.SetActive(true);
                backDamage(receivedDamage);
            }
            
            alreadyTookDamage = true;
            Invoke(nameof(ResetDamage), 0.5f);
        }
        stamina = Mathf.Lerp(stamina, realStamina, 0.05f);
    }

    void FixedUpdate()
    {
        _health.fillAmount = hp / Full;
        _stamina.fillAmount = stamina / SkillSystem.currentStamina;
    }

    void SelfDamage()
    {
        hp -= 10;
    }

    private void ResetDamage()
    {
        rightPanel.SetActive(false);
        leftPanel.SetActive(false);
        frontPanel.SetActive(false);
        backPanel.SetActive(false);
        alreadyTookDamage = false;
    }

    public void rightDamage(int damage)
    {
        hp -= damage;
    }
    
    public void leftDamage(int damage)
    {
        hp -= damage;
    }

    public void frontDamage(int damage)
    {
        hp -= damage;
    }

    public void backDamage(int damage)
    {
        hp -= damage;
    }

    public void ReduceStamina(float amount)
    {
        canStaminaReplenish = false;
        realStamina = stamina - amount;
        StopAllCoroutines();
        StartCoroutine(WaitAndUpdate());
    }
    public IEnumerator WaitAndUpdate()
    {
        float d = 0;
        while(d < 2f)
        {
            d += Time.deltaTime;
            yield return null;
        }
        canStaminaReplenish = true;
    }

    // void Respawn()
    // {
    //     hp = 100;
    //     gameObject.transform.position = spawn_point.transform.position;
    // }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Fog"))
    //     {
    //         Respawn();
    //     }
    // }
}