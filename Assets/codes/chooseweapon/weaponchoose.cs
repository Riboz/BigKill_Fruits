using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class weaponchoose : MonoBehaviour
{
    // Start is called before the first frame update
    public string[]weapon;
    public Text weaponsectext;
    void Start()
    {
        StartCoroutine(weapontext());
    }
    IEnumerator weapontext()
    {
        for(int i=0;i<=weapon.Length-1;i++)
        {
            weaponsectext.text=weapon[i];
            yield return new WaitForSeconds(0.5f);
            if(i==2){i=-1; yield return new WaitForSeconds(0.5f);}

        }
    }
  
}
