using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool flag = false;
    private float speed = 0.1f;
    private float timer = 0;
    public Sprite pig_down;
    public Sprite pig_up;
    public Sprite pig_right;
    public Bomb bomb;
    public Joystick joystick;
    public GameObject farmer;   



    [System.Obsolete]

    private void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            float x = transform.rotation.x;
            float y = transform.rotation.y;

            //bomb = Instantiate(bomb, transform.position, transform.rotation);
            // bomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.01f,0.01f) * 100f, ForceMode2D.Impulse);
        }

        transform.position += new Vector3(speed, 0, 0) * joystick.Horizontal;
        transform.position += new Vector3(0, speed, 0) * joystick.Vertical;

        Debug.Log(joystick.Vertical);

        if (joystick.Horizontal < -0.90)
        {
            GetComponent<SpriteRenderer>().sprite = pig_right;
            GetComponent<SpriteRenderer>().flipX = true;

        }
        if (joystick.Horizontal > 0.90)
        {
            GetComponent<SpriteRenderer>().sprite = pig_right;
            GetComponent<SpriteRenderer>().flipX = false;

        }

        if (joystick.Vertical < -0.30)
        {
            GetComponent<SpriteRenderer>().sprite = pig_down; //выполняем

            timer += Time.deltaTime; //добавить в таймер
            if (timer < 0.2f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (timer > 0.4f && timer < 0.7f)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (timer > 0.7f) { timer = 0; }
        }

        if (joystick.Vertical > 0.30)
        {
            GetComponent<SpriteRenderer>().sprite = pig_up; //выполняем

            timer += Time.deltaTime; //добавить в таймер
            if (timer < 0.2f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (timer > 0.4f && timer < 0.7f)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (timer > 0.7f) { timer = 0; }
        }

    }

    public void OnBombButtonAtack()
    {
        bomb = Instantiate(bomb, transform.position, transform.rotation);
        bomb.gameObject.active = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == farmer.name)
        {
            Destroy(farmer);

            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

    }
}
