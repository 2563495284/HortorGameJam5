using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroAttrRender : MonoBehaviour
{
    
    public Text attrName;

    public Text attrDesc;

    public void OnData(string attrName, string attrDesc)
    {
        this.attrName.text = EHeroAttr.Name(attrName);
        this.attrDesc.text = attrDesc;
    }
}
