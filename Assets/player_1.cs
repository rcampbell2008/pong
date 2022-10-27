using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_1 : MonoBehaviour
{


    public Rigidbody2D r2;
    public int score = 0;
    public static player_1 Instance;
    public float movespeedmod;
    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y_axis = 0;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            y_axis = -3;
            
            if (Input.GetKey(KeyCode.Delete))
            {
                y_axis = -3 * movespeedmod;

            }
            else
            {
                y_axis = -3;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y_axis = 3;
            if (Input.GetKey(KeyCode.Delete))
            {
                y_axis = 3 * movespeedmod;

            }
            else
            {
                y_axis = 3;
            }
        }
        r2.velocity = new Vector2(0, y_axis);
        
    }
}
