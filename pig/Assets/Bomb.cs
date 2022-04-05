using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public GameObject enemy;
    public GameObject explosion;
    public GameObject pig;
    private float timer = 0;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {

        explosion.active = false;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > 3f && timer < 4f)
        {
            timer += Time.deltaTime;
            explosion.active = true;
       
        }
        if (timer > 4.5f)
        {
            gameObject.active = false;
            explosion.active = false;
        }
    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D other)
    {
        if (timer > 3f && timer < 4f)
        {
            if (other.gameObject.name == enemy.name)
            {
                enemy.transform.position = new Vector3(100, 100, 100);

                gameObject.active = false;

                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
            if (other.gameObject.name == pig.name)
            {
                Destroy(pig);

                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
    }

    [System.Obsolete]
    void OnTriggerStay2D(Collider2D other)
    {
        if (timer > 3f && timer < 4f)
        {
            if (other.gameObject.name == enemy.name)
            {
                enemy.transform.position = new Vector3(100, 100, 100);

                gameObject.active = false;

                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
            if (other.gameObject.name == pig.name)
            {
                Destroy(pig);

                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
    }
}