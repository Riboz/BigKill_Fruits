using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class reloadimagedotween : MonoBehaviour
{
    // Start is called before the first frame update
    int i=0;
    void OnEnable()
    {
        StartCoroutine(Dotween());
    }
 IEnumerator Dotween()
 {
    while( i==0)
    {

    this.transform.DOScale(new Vector3(1.5f,1.5f,0),2f);

    yield return new WaitForSeconds(1f);

    this.transform.DOScale(new Vector3(1,1,0),2f);
    
    yield return new WaitForSeconds(1f);
    }
    
 }
    // Update is called once per frame
    void Update()
    {
        
    }
}
