using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] GameObject agente;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agente.transform.position= Vector2.zero;
        Vector2 miVector2= agente.transform.localScale;
        miVector2.x= miVector2.x+(2f*Time.deltaTime);
        miVector2.y= miVector2.y+(2f*Time.deltaTime);

        agente.transform.localScale= miVector2;
    }
}
