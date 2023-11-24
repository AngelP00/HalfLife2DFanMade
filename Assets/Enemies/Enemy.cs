using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float life;
    public Animator anim;
    public float life_complete;
    //public GameObject life_bar;
    public Transform bar_red;
    //public string script_name;
    //public MonoBehaviour script;
    //public GameObject obj;
    //public Component comp;
    //public compo
    public Animator anim_life_bar;
    //public float time_show_life = 0;


    // Use this for initialization
    void Start ()
    {
        life_complete = life;
        //new MonoBehaviour().
        anim_life_bar.SetBool("Show_life_bar", false);
    }
    /*
	// Update is called once per frame
	void Update () {
		
	}
    */
    public void Func_damage_life(int damage)
    {
        life-= damage;
        //Debug.Log("Life: " + life);
        //script.
        //obj.GetComponent<ScriptableObject>().ToString(
        Func_enemy_damage();
        if(life <= 0)
        {
            Func_enemy_dead();
        }
    }

    public void Func_enemy_damage()
    {
        bar_red.localScale = new Vector3(life/life_complete, 1, 1);
        //Debug.Log("Damage enemy");
        //Debug.Log("Life in bar: "+life/life_complete);
    }
    public void Func_enemy_dead()
    {
        anim.SetTrigger("Dead");
        //Debug.Log("Enemy dead");
    }



    public void Func_show_life_bar()
    {
        //life_bar.SetActive(true);
        anim_life_bar.SetBool("Show_life_bar", true);
        //anim_life_bar.SetTrigger("Show_life_bar");
        Debug.Log("Mostrar vida");
    }
    /*
    public void Func_no_show_life_bar()
    {
        //life_bar.SetActive(false);
        anim_life_bar.SetBool("Show_life_bar", false);
    }
    */
}
