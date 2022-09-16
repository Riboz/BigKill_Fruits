using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ammo {friend,enemy}

public class bullets : MonoBehaviour
{
    // Start is called before the first frame update
    public ammo Ammo;
    void OnTriggerEnter2D(Collider2D coll)
    {
       if(Ammo==ammo.enemy) 
       {
        if(coll.gameObject.CompareTag("wall"))
        {
           Destroy(this.gameObject);
        }
        if(coll.gameObject.CompareTag("Player"))
        {
            if( coll.gameObject.GetComponent<myplayer>().candamaged)
            {
                coll.gameObject.GetComponent<myplayer>().hp(-1);
           Destroy(this.gameObject);
            }
        }
       }

        if(Ammo==ammo.friend) 
       {
        if(coll.gameObject.CompareTag("wall"))
        {
           Destroy(this.gameObject);
        }
        if(coll.gameObject.CompareTag("Enemy"))
        {
           coll.gameObject.GetComponent<enemy>().enemyhp(-1*myplayer.damagepower);
           Destroy(this.gameObject);
            }
             if(coll.gameObject.CompareTag("choosing"))
        {
           coll.gameObject.GetComponent<choosing>().damageC(-1);
           Destroy(this.gameObject);
            }
        }
       }
        //playerle bağlantı kurulsun eğer damagable sa destroy edilmesin fln filan
    
  }
