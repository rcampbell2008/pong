using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ball : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigid;
    public TextMeshProUGUI player1_score;
    public TextMeshProUGUI player2_score;
    public int player1;
    public int player2;
    public float ballspeedreturn = 0;
    public bool playerone;
    public bool playertwo;
    public Powerups currentpowerup;
    public bool ispoweractive;
    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = new Vector2(5, 1);
        player1 = 0;
        player2 = 0;
        playerone = false;
        playertwo = false;
        currentpowerup = ScriptableObject.CreateInstance<fireball>();
        currentpowerup.SetBall(this);
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Mathf.Abs(rigid.velocity.x) < 3f && (ispoweractive == false))
        {
            if(rigid.velocity.x < 0f && rigid.velocity.x > -3f)
            {
                rigid.velocity = new Vector2(-3, rigid.velocity.y);
            }
            else
            {
                rigid.velocity = new Vector2(3, rigid.velocity.y);
            }
        }
        else if (currentpowerup.type == "fireball" && ispoweractive == true)
        {
            float goaly = rigid.velocity.y * 2f;
            if (goaly > 6)
            {
                goaly = 6;
            } else if (goaly < -6)
            {
                goaly = -6;
            }
            if(rigid.velocity.x < 0f && rigid.velocity.x > -3f)
            {
                rigid.velocity = new Vector2(-6, goaly);
            }
            else
            {
                rigid.velocity = new Vector2(6, goaly);
                Debug.Log(currentpowerup + " " + "tyerf");
            }
        }
        if (Input.GetKey(KeyCode.X))
        {
            ispoweractive = true;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            ispoweractive = false;
        }
        if (ispoweractive)
        {
            currentpowerup.poweraction();
        }
        //x
        //what powerup
        //mess
        //Debug.Log(currentpowerup + " " + ispoweractive);
    }
   




       
 
   public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player1"))
        {
            float floot = transform.position.y - collision.gameObject.transform.position.y;
            rigid.velocity = new Vector2(-5*Mathf.Cos(floot), 5*Mathf.Sin(floot));
            rigid.velocity += new Vector2(-ballspeedreturn, 0);
            playerone = true;
            playertwo = false;
            //this.gameObject.transform.position = Vector2.Reflect(this.gameObject.transform.position, -Vector2.right);
        }
        if (collision.gameObject.CompareTag("PowerUp" )) 
        {
            Debug.Log("hitpowerup");
            //currentpowerup = collision.gameObject.GetComponent<Powerups>();
            //currentpowerup.SetBall(this);
        }
        if(collision.gameObject.CompareTag("player2"))
        {
            float floot = transform.position.y - collision.gameObject.transform.position.y;
            rigid.velocity = new Vector2(5 * Mathf.Cos(floot), 5 * Mathf.Sin(floot));
            rigid.velocity += new Vector2(ballspeedreturn, 0);
            playertwo = true;
            playerone = false;
            //this.gameObject.transform.position = Vector2.Reflect(this.gameObject.transform.position, Vector2.right);
        }
        if (collision.gameObject.CompareTag("top"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -5);
        }
        if (collision.gameObject.CompareTag("bottom"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 5);
        }
        if (collision.gameObject.tag == "p1goal")
        {
            //p1score = player_1.Instance.score += 1;
            // textMesh.text = p1_score.ToString();
            // Debug.Log(p1_score);
            // float floot = transform.position.y - collision.gameObject.transform.position.y;
            // rigid.velocity = new Vector2(5 * Mathf.Cos(floot), -5 * Mathf.Sin(floot));
            //rigid.velocity = new Vector2(-5 * Mathf.Cos(floot), 5 * Mathf.Sin(floot));
            this.transform.position = Vector3.zero;
            player2 += 1;
            player2_score.text = player2.ToString();
        }


        if (collision.gameObject.CompareTag("p2 goal"))
        {
            // p2_score = player_2.Instance.score += 1;
            // textMesh.text = p2_score.ToString();
            //Debug.Log(p2_score);
            //float floot = transform.position.y - collision.gameObject.transform.position.y;
            //rigid.velocity = new Vector2(5 * Mathf.Cos(floot), 5 * Mathf.Sin(floot));
            this.transform.position = Vector3.zero;
            player1+= 1;
            player1_score.text = player1.ToString();
        }

    }
}
