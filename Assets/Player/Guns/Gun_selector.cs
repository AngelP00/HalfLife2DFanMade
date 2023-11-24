using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_selector : MonoBehaviour
{
    public GameObject _9mm;
    public GameObject magnum;
    public GameObject mp7;
    public GameObject shotgun;
    public GameObject crossbow;
    public GameObject gravity_gun;
    public GameObject RPG;
    public GameObject pulse_rifle;
    public GameObject grenade;
    public static bool shot_area = false;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    public void Func_select_9mm()
    {
        Func_deselect_arm();
        _9mm.SetActive(true);
    }
    public void Func_select_magnum()
    {
        Func_deselect_arm();
        magnum.SetActive(true);
    }
    public void Func_select_mp7()
    {
        Func_deselect_arm();
        mp7.SetActive(true);
    }
    public void Func_select_shotgun()
    {
        Func_deselect_arm();
        shotgun.SetActive(true);
    }
    public void Func_select_crossbow()
    {
        Func_deselect_arm();
        crossbow.SetActive(true);
    }
    public void Func_select_gravity_gun()
    {
        Func_deselect_arm();
        gravity_gun.SetActive(true);
    }
    public void Func_select_RPG()
    {
        Func_deselect_arm();
        RPG.SetActive(true);
    }
    public void Func_select_pulse_rifle()
    {
        Func_deselect_arm();
        pulse_rifle.SetActive(true);
    }
    public void Func_select_grenade()
    {
        Func_deselect_arm();
        grenade.SetActive(true);
    }
    public void Func_deselect_arm()
    {
        _9mm.SetActive(false);
        magnum.SetActive(false);
        mp7.SetActive(false);
        shotgun.SetActive(false);
        crossbow.SetActive(false);
        gravity_gun.SetActive(false);
        RPG.SetActive(false);
        pulse_rifle.SetActive(false);
        grenade.SetActive(false);
    }
    public void Func_shot_area()
    {
        shot_area = !shot_area;
        Debug.Log("Shot_area" + shot_area);
    }
}
