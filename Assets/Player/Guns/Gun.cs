using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject mira;
    public GameObject gun;
    public GameObject head;
    public bool fire = false;
    public Transform trans_Player;

    public Animator anim_gun;

    //public int max_bullets;
    public int max_bullets_in_charger = 30;
    public int bullets = 100;
    public int bullets_in_charger = 30;

    //public Transform point_center;

    public GameObject prefap_bullet;
    //public Transform start_bullet;
    
    public float time_between_shots;
    public bool recharging = false;
    /*
    [Header("_9mm")]
    public GameObject prefap_bullet_9mm;
    public float time_between_shots_9mm;

    [Header("_mp7")]
    public GameObject prefap_bullet_mp7;
    public float time_between_shots_mp7;

    [Header("_shotgun")]
    public GameObject prefap_bullet_shotgun;
    public float time_between_shots_shotgun;
    */
    public EventSystem event_System;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /**
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Sobre UI");
        }
        */

        if (Input.GetButtonDown("Fire1"))
        {
            //mira.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            //mira.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4.63f));
            //mira.transform.position = new Vector3(mira.transform.position.x, mira.transform.position.y, 0);
            Debug.Log("Fire1");
            //if(EventSystem.current.IsPointerOverGameObject() == false)//Si el mouse no está sobre un elemento de la UI
            //{
                fire = true;
            //}

            /*
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), 15);
            Debug.Log("Collision: " + hit.collider.gameObject.layer);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.layer != 5)
                {

                }
            }
            */
            //}


            //Debug.Log("Fire");
            //fire = true;
            //mira.gameObject.GetComponent<SpriteRenderer>().enabled = true;//La mira es visible
        }
        if(Input.GetButtonUp("Fire1"))
        {
            anim_gun.SetBool("Shoting", false);
            fire = false;
            head.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            gun.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            mira.gameObject.GetComponent<SpriteRenderer>().enabled = false;//La mira no es visible
        }


        if (fire)
        {
            Func_fire();
        }
        //Recarga si el cargador no tiene balas, si no está recargando y si hay balas
        if ((bullets_in_charger <= 0) && (recharging == false) && bullets > 0)
        {
            //anim_gun.SetTrigger("Recharg");
            //recharging = true;
            //bullets = 30;
            Func_start_recharging();
        }
    }
    public void Func_fire()
    {
        mira.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4.63f));
        mira.transform.position = new Vector3(mira.transform.position.x, mira.transform.position.y, 0);

        //Debug.Log(trans_Player.rotation.y);//1 es igual a 180 grados
        //Debug.Log(Quaternion.Euler(0,trans_Player.rotation.y,0));

        //if (((trans_Player.localScale.x == 1) && (trans_Player.position.x < mira.transform.position.x)) || ((trans_Player.localScale.x == -1) && (trans_Player.position.x > mira.transform.position.x)))
        if ((((trans_Player.localScale.x == 1) && (trans_Player.position.x < mira.transform.position.x)) || ((trans_Player.localScale.x == -1) && (trans_Player.position.x > mira.transform.position.x))) && (bullets_in_charger > 0) && (Gun_selector.shot_area == true))
        {
            //if(EventSystem.current.IsPointerOverGameObject() == false)//Si el mouse no está sobre un elemento de la UI
            //{
                
            //}
            anim_gun.SetBool("Shoting", true);
            head.transform.up = head.transform.position - mira.transform.position;
            //gun.transform.up = gun.transform.position+ new Vector3(0.4020002f, 0.03800005f, 0) - mira.transform.position;
            gun.transform.up = gun.transform.position - mira.transform.position;
            //point_center.up = gun.transform.position - mira.transform.position;



            //Instantiate(prefap_bullet, gameObject.transform);
            //Debug.Log("Shoting");
            mira.gameObject.GetComponent<SpriteRenderer>().enabled = true;//La mira es visible

        }
        else
        {
            anim_gun.SetBool("Shoting", false);
            head.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            gun.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            mira.gameObject.GetComponent<SpriteRenderer>().enabled = false;//La mira no es visible
        }

        /*
        if ((trans_Player.localScale.x == 1) && (trans_Player.position.x < mira.transform.position.x))
        {
            head.transform.up = head.transform.position - mira.transform.position;
            guns.transform.up = guns.transform.position - mira.transform.position;

            
            Instantiate(prefap_bullet, gameObject.transform);
            Debug.Log("Shoting");
            mira.gameObject.GetComponent<SpriteRenderer>().enabled = true;//La mira es visible
        }
        else if ((trans_Player.localScale.x == -1) && (trans_Player.position.x > mira.transform.position.x))
        {
            head.transform.up = head.transform.position - mira.transform.position;
            guns.transform.up = guns.transform.position - mira.transform.position;

            Instantiate(prefap_bullet, gameObject.transform);
            Debug.Log("Shoting");
            mira.gameObject.GetComponent<SpriteRenderer>().enabled = true;//La mira es visible
        }
        else
        {
            head.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            guns.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            mira.gameObject.GetComponent<SpriteRenderer>().enabled = false;//La mira no es visible
        }
        */
    }
    public void Func_shot()
    {
        Instantiate(prefap_bullet, gameObject.transform);
        Debug.Log("Fun_Shot");
        bullets_in_charger -= 1;
        Debug.Log("Bullets: " + bullets_in_charger);
        //if ((bullets_in_charger <= 0) && (recharging == false) && bullets > 0)
        /*
        if ((bullets_in_charger <= 0) && (recharging == false) && bullets > 0)
        {
            anim_gun.SetTrigger("Recharg");
            recharging = true;
            //bullets = 30;
        }
        */
    }
    public void Func_start_recharging()
    {
        anim_gun.SetTrigger("Recharg");
        recharging = true;
    }
    public void Func_end_recharging()
    {
        if(bullets >= max_bullets_in_charger)
        {
            bullets_in_charger = max_bullets_in_charger;
            bullets-= max_bullets_in_charger;
        }
        else
        {
            bullets_in_charger = bullets;
            bullets = 0;
        }
        recharging = false;
        Debug.Log("End_recharging ");
    }
    /*
    public void Func_ray()
    {
        
        //RaycastHit hit;
        //Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider != null)
            {
                //Le dió a algo
                //Destroy(hit.collider.gameObject);
                //if (hit.collider.gameObject.CompareTag("TagPortón"))
                //{
                //    Debug.Log("Porton");
                //    hit.collider.gameObject.GetComponent<Portón_01>().Func_Abrir_CerrarPorton();
                //}
                if (hit.collider.gameObject.layer != 5)
                {

                }
            }
        }
    }*/
    
}
