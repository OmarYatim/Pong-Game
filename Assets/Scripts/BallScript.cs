using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] float speed = 25;
    [SerializeField] int MaxScore = 15;

    [SerializeField] Text ScoreLeftText;
    [SerializeField] Text ScoreRightText;
    [SerializeField] Text WinText;

    int ScoreLeft = 0;
    int ScoreRight = 0;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.right * speed;
    }

    float BallDirection(Vector2 BallPos, Vector2 RacketPos, float RacketHeight)
    {
        return (BallPos.y - RacketPos.y) / RacketHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "RacketRight")
        {
            float y = BallDirection(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 Dir = new Vector2(-1,y).normalized;
            rb2d.velocity = Dir * speed;
        }
        if (collision.gameObject.name == "RacketLeft")
        {
            float y = BallDirection(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 Dir = new Vector2(1, y).normalized;
            rb2d.velocity = Dir * speed;
        }
        if(collision.gameObject.name == "WallLeft")
        {
            ScoreRight++;
            ScoreRightText.text = ScoreRight.ToString();
            if(ScoreRight == MaxScore)
            {
                WinText.text = "Player 1 a gagné";
                Time.timeScale = 0;
            }
        }
        if (collision.gameObject.name == "WallRight")
        {
            ScoreLeft++;
            ScoreLeftText.text = ScoreLeft.ToString();
            if (ScoreLeft == MaxScore)
            {
                WinText.text = "Player 2 a gagné";
                Time.timeScale = 0;
            }
        }
    }

    public void PLay()
    {
        Time.timeScale = 1;
    }

}
