using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D r2;

    public int score = 0;
    public static player_2 Instance;
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
        if (Input.GetKey(KeyCode.S))
        {
            y_axis = -4;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                y_axis = -3 * movespeedmod;

            }
            else
            {
                y_axis = -3;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            y_axis = 4;
            if (Input.GetKey(KeyCode.LeftShift))
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
