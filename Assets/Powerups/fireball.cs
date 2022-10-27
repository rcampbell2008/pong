using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : Powerups
{
    // Start is called before the first frame update
    void Start()
    {
        type = "fireball";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void poweraction()
    {
        dall.rigid.velocity = new Vector2(dall.rigid.velocity.x * 2f, dall.rigid.velocity.y * 2f);
    }
}
