using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    // Start is called before the first frame update
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("wall"))
        {
           Destroy(this.gameObject);
        }
        //playerle bağlantı kurulsun eğer damagable sa destroy edilmesin fln filan
    }
}
