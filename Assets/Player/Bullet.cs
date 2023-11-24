using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public Transform direction_Bullet;
    //public int velocity = 700;
    public float time_life = 5;
    //public float cont;
    public Vector3 heading;
    public GameObject blood;
    public int daño_bala = 10;
    public int velocity = 7;

    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(new Vector3(4.5f, 0, 0), ForceMode.Impulse);
        //rb.AddForce(transform.right*velocity);
        //trans_mira = GameObject.FindGameObjectWithTag("Mira").transform;
        //heading = trans_mira.position - gameObject.transform.position;
        //heading = new Vector3(gameObject.transform.localPosition.x + 1, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z) - gameObject.transform.position;
        //heading = new Vector3(gameObject.transform.localPosition.x + 1, gameObject.transform.localPosition.y, 0) - gameObject.transform.localPosition;
        heading = direction_Bullet.position - gameObject.transform.position;
        //rb.AddForce((trans_mira.position - gameObject.transform.position) * 7, ForceMode.Impulse);
        rb.AddForce((heading/heading.magnitude).normalized * velocity, ForceMode.Impulse);
        //rb.AddForceAtPosition(new Vector3(1, 1, 0), direction_Bullet.position, ForceMode.Impulse);
        //rb.AddForce()
        //rb.AddForce(new Vector3(4.5f, 0, 0), ForceMode.Impulse);
        gameObject.transform.parent = null;
        Destroy(gameObject, time_life);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        //Func_destroy();
        //rb.AddExplosionForce(400, collision.transform.position, 200);
        if(collision.gameObject.tag == "Enemy")
        {
            blood.gameObject.SetActive(true);
            blood.transform.parent = collision.gameObject.transform;
            collision.gameObject.GetComponent<Enemy>().Func_damage_life(daño_bala);//Se le resta vida al enemigo
            collision.gameObject.GetComponent<Enemy>().Func_show_life_bar();
            Func_destroy();
        }
        else
        {
            rb.useGravity = true;
        }
    }
    public void Func_destroy()
    {
        Destroy(gameObject);
    }
}
