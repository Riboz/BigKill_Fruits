using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] weapons;
    Rigidbody2D rb;
    public  GameObject reloadimage;
    public Transform Weaponpos;
    void Start()
    {
   

     int randomint=Random.Range(0,3);

     rb=GetComponent<Rigidbody2D>();

     GameObject weapon=Instantiate(weapons[randomint],Weaponpos.position,Quaternion.identity);
     weapon.GetComponent<Hweapon>().isplayer=true;
    weapon.GetComponent<Hweapon>().reloadimage=reloadimage;
     weapon.transform.SetParent(this.transform);

      StartCoroutine(weaponplace(weapon));
    }
    IEnumerator weaponplace(GameObject weapon)
    {
        for(int i=3;i>=2;i++)
        { 
        yield return new WaitForSeconds(0.02f);
        weapon.transform.position=Weaponpos.position;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     Movement();   
    }
    public void Movement()
    {
        float Horizontalx=Input.GetAxis("Horizontal");
        float Verticaly=Input.GetAxis("Vertical");
        rb.velocity=new Vector2(Horizontalx*4,Verticaly*4);
        
    }
    
}
