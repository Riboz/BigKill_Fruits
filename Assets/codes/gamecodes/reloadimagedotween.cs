using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public enum who
{
    player,reloadimage
}
public class reloadimagedotween : MonoBehaviour
{
   public who who;
    
    int i=0;
    void OnEnable()
    {
        StartCoroutine(Dotween());
    }
 IEnumerator Dotween()
 {
    if(who==who.reloadimage)
    {
    while( i==0)
    {

    this.transform.DOScale(new Vector3(1.5f,1.5f,0),2f);

    yield return new WaitForSeconds(1f);

    this.transform.DOScale(new Vector3(1,1,0),2f);
    
    yield return new WaitForSeconds(1f);
    }

    }
    if(who==who.player)
    {
    while( i==0)
    {

    this.transform.DOScale(new Vector3(1.1f,1.1f,0),0.75f);

    yield return new WaitForSeconds(1f);

    this.transform.DOScale(new Vector3(1.3f,1.3f,0f),0.75f);
    
    yield return new WaitForSeconds(1f);
    }
    }

    
 }
    // Update is called once per frame
    void Update()
    {
        
    }
}
