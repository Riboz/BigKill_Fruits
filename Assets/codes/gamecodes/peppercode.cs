using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class peppercode : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI pepperspeak;
    public GameObject choose;
    public string[] dialoge;
    public GameObject PepperDialogepanel;


    // Update is called once per frame
    public void Start()
    {
    StartCoroutine(peppertime());
    }
    IEnumerator peppertime()
    {
        pepperspeak.text="";
        yield return new WaitForSeconds(2f);
        PepperDialogepanel.SetActive(true);
        pepperspeak.text+=" ";
        for(int i=0;i<=dialoge.Length-1;i++)
        {
            pepperspeak.text+=" "+dialoge[i];
        if(i==2)
        {
            yield return new WaitForSeconds(1.2f);
            pepperspeak.text="";
        }
        if(i==7)
        {
            yield return new WaitForSeconds(1.2f);
            pepperspeak.text="";
        }
            yield return new WaitForSeconds(0.7f);
        }
        choose.SetActive(true);

         yield break;
    }
}
