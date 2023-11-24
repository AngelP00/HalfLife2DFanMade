using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //public Rigidbody2D rb;//Rigidbody de este objeto
    public Rigidbody rb;//Rigidbody de este objeto
    public Animator anim_Player;
    public SpriteRenderer sp_r;
    public float velocidad = 50;
    public bool avanzar = false;
    //public bool onFloor = false;
    public int cont_F = 0;
    public bool atack_Crowbar = false;//Para saber si está atacando con la crowbar
    public int daño_Crowbar = 50;

    // Use this for initialization
    void Start ()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();//Busca el Rigidbody y lo guarda
    }

    // Update is called once per frame
    void Update ()
    {
        //rb.AddForce(new Vector3(velocidad * Time.deltaTime, 0,0), ForceMode2D.Force);
        if (avanzar)
        {
            anim_Player.SetBool("Avanzar", true);
            quitAceleracion();
            Func_avanzar();
        }
        else
        {
            quitAceleracion();//Quita la aceleracion en cada frime(quizas relentiza un poco)
        }
        //Debug.Log("Player velocity_y: " + rb.velocity.y);

    }

    public void Func_activar_derecha()
    {
        avanzar = true;
        sp_r.flipX = false;
    }
    public void Func_activar_izquierda()
    {
        avanzar = true;
        sp_r.flipX = true;
    }
    public void Func_desactivar_avanzar()
    {
        //quitAceleracion();
        avanzar = false;
        anim_Player.SetBool("Avanzar", false);
    }

    public void Func_avanzar()//En este proyecto la izquierda y la derecha es la cordena z
    {
        //quitAceleracion();
        if (sp_r.flipX)
        {
            rb.AddForce(new Vector3(-velocidad * Time.deltaTime, 0, 0), ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(new Vector3(velocidad * Time.deltaTime, 0, 0), ForceMode.Impulse);
        }
    }
    public void quitAceleracion()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }
    //Jump
    public void Func_Activat_Jump()
    {
        if (cont_F > 0)//Ante onFloor
        {
            //rb.AddForce(new Vector3(0, 250, 0), ForceMode2D.Force);
            //anim_Player.SetTrigger("Jump");
            anim_Player.SetBool("Jumping", true);
            //onFloor = false;
        }
    }
    public void Func_Jump()
    {
        rb.AddForce(new Vector3(0, 4.5f, 0), ForceMode.Impulse);
    }
    //

    //Atack_Crowbar
    public void Func_Atack_Crowbar()
    {
        anim_Player.SetTrigger("Atack_Crowbar");
    }
    public void Func_Anim_Atack_Crowbar()//Funcion para saber cuando está atacando con la crowbar
    {
        atack_Crowbar = !atack_Crowbar;
        Debug.Log(atack_Crowbar);
    }
    //

    private void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.layer == 8)
        {
            //onFloor = true;
            cont_F+= 1;
            anim_Player.SetBool("Jumping", false);
        }
        /*
        if ((obj.transform.tag == "Box") && atack_Crowbar)//Si es la caja y si esta atacando con la crowbar
        {
            Debug.Log("Dañar box");
            obj.gameObject.GetComponent<Script_Box>().Func_Restar_vida(daño_Crowbar);//Se le resta vida a la caja
        }
        */
    }
    private void OnCollisionExit(Collision obj)
    {
        if (obj.gameObject.layer == 8)
        {
            //onFloor = false;
            cont_F-= 1;
        }
    }
    private void OnTriggerEnter(Collider obj)
    {
        if ((obj.transform.tag == "Box") && atack_Crowbar)//Si es la caja y si esta atacando con la crowbar
        {
            Debug.Log("Dañar box");
            obj.gameObject.GetComponent<Script_Box>().Func_Restar_vida(daño_Crowbar);//Se le resta vida a la caja
            //Destroy(obj.gameObject);
        }
        else if((obj.transform.tag == "Enemy") && atack_Crowbar)//Si es un emigo y si esta atacando con la crowbar
        {
            obj.gameObject.GetComponent<Enemy>().Func_damage_life(daño_Crowbar);//Se le resta vida al enemigo
        }
    }
}
