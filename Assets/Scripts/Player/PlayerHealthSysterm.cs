using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public class PlayerHealthSysterm : MonoBehaviour
{
    public float v_sanity_damage;
    public float v_health_damage;
    public float v_sanity_damage_base;
    public float v_health_damage_base;
    public float v_sanity_heal;
    public float v_health_heal;
    public float v_damage_time;
    public HealthAndSanity PlayerHP;
    private EventInputAction eventInputAction;
    public GameObject UI;
    public UI_info_script ui_script;
    public bool pouse = false;

    private Thread _t1;

   private void Start()
    {
        PlayerHP = new HealthAndSanity(100, 100);
        v_sanity_damage = 1.0f;
        v_health_damage = 0.1f;
        v_health_damage_base = 0.1f;
        v_sanity_heal = 0.5f;
        v_health_heal = 10.0f;
        v_damage_time = 2.0f;

        InvokeRepeating("Insanity", 3.0f, 1.0f);
        InvokeRepeating("HealthDamegeFromInsanity", 0.0f, v_damage_time);
    }
    private void Awake()
    {
        eventInputAction = new EventInputAction();
        UI = GameObject.Find("UI");
        ui_script = UI.GetComponent<UI_info_script>();
        
    }
    private void OnEnable()
    {
        eventInputAction.Player.selfHarmHealth.performed += Oucheeee;
        eventInputAction.Player.selfHarmHealth.Enable();

        eventInputAction.Player.selftHealHealth.performed += AleUlga;
        eventInputAction.Player.selftHealHealth.Enable();

        eventInputAction.Player.selftHarmSanity.performed += Szalenstwo;
        eventInputAction.Player.selftHarmSanity.Enable();

        eventInputAction.Player.selftHealSanity.performed += Relax;
        eventInputAction.Player.selftHealSanity.Enable();

    }
    private void Oucheeee(InputAction.CallbackContext obj)
    {
        PlayerHP.HealthDamage(10.0f);
        
    }

    private void AleUlga(InputAction.CallbackContext obj)
    {
        PlayerHP.HealthHeal(10.0f);
    }

    private void Szalenstwo(InputAction.CallbackContext obj)
    {
        PlayerHP.SanityDamage(5.0f);
    }

    private void Relax(InputAction.CallbackContext obj)
    {
        PlayerHP.SanityHeal(6.0f);
    }

    private void Update()
    {
        Debug.Log("¯ycie: " + PlayerHP.GetHealthPercent().ToString() + " psycha: " + PlayerHP.GetSanityPercent().ToString());
        //Debug.Log("¯ycie: " + PlayerHP.GetHealth() + " psycha: " + PlayerHP.GetSanity());
        ui_script.UpdateHealth(PlayerHP.GetHealth());
        ui_script.UpdateSanity(PlayerHP.GetSanity());
    }



   

    void Insanity() 
    {
        PlayerHP.SanityDamage(v_sanity_damage);
    }

    void HealthDamegeFromInsanity()
    {
        v_health_damage = v_health_damage_base;
        if (PlayerHP.GetSanityPercent() < 0.70f)
        {
            v_health_damage = ((1.0f - PlayerHP.GetSanityPercent())*5.0f);
            PlayerHP.HealthDamage(v_health_damage);
            v_health_damage = v_health_damage_base;
        }
        if (PlayerHP.GetSanityPercent() > 0.80f)
        {
            PlayerHP.HealthHeal(v_health_heal);
        }
        
    }

}
