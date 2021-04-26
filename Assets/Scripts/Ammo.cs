using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public static int ammoNum;
    Text ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammoNum = 10;
        ammo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text = "Ammo: " + ammoNum;
    }
}
