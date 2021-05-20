using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update

    /*public GameObject greenObject;
    public GameObject redObject;
    public GameObject yellowObject;
    public GameObject blueObject; */

    public bool FreezeY = false;
 
    private float timer = 0.2f,jumpDistance=0.0f;
    private Vector3 originPos;
    public GameObject particles;
    public AudioClip deathSound;
    public AudioSource audioSource;
    void Start()
    {
        
        originPos = transform.position;
         Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(),false);
    }

    [SerializeField] public float speed;
    public Transform obj;

    public void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(-speed, 0, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;

        obj.transform.position += tempVect;
        timer -= Time.deltaTime;
        Vector3 currentPos = transform.position;
        if (FreezeY)
        {
            if(timer<=0)
            {
                currentPos.y = originPos.y;
                FreezeY = false;
                timer = Random.Range(0.5f, 1.5f);
            } 
        }
        else
        {
            if (timer <= 0)
            {
                jumpDistance = Random.Range(1.3f, 2f);
                currentPos.y = originPos.y + jumpDistance;
                FreezeY = true;
                timer = 0.2f;
            }
        }
      
        transform.position = currentPos;
    }
    
   IEnumerator DieTime(Collision2D col)
    {
        gameObject.GetComponent<Collider2D>().enabled=false;
        gameObject.GetComponent<SpriteRenderer>().enabled=false;
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(col.gameObject);
        audioSource.clip=deathSound;
        audioSource.PlayOneShot(deathSound);
        //audioSource.enabled=false;
        yield return new WaitForSeconds(1);         
        Destroy(gameObject);
            

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        /*if(GameObject.FindGameObjectWithTag("GreenEnemy")) {
            Destroy(greenObject);
        }
        if(GameObject.FindGameObjectWithTag("RedEnemy")) {
            Destroy(redObject);
        }
        if(GameObject.FindGameObjectWithTag("YellowEnemy")) {
            Destroy(yellowObject);
        } 
        if(GameObject.FindGameObjectWithTag("BlueEnemy")) {
            Destroy(blueObject);
        } 
       
        Destroy(col.gameObject);    */


        if (col.gameObject.tag == "Bullet")
        {
            StartCoroutine(DieTime(col));

            //Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "CannonBullet")
        {
            StartCoroutine(DieTime(col));
           // Instantiate(particles, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            
        }

        if (col.gameObject.tag == "Ally" || col.gameObject.tag == "Enemy")
        {
            //StartCoroutine(DieTime(col));
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            
        }

    }


}
