using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUps", menuName = "PowerUps/based")]
public class Powerups : ScriptableObject
 

{
    public ball dall;
    public float ballspeed;
    public int scoremod;
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetBall(ball x)
    {
        dall = x;
    }
    public void poweraction()
    {

    }
}
