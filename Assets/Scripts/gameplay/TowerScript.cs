using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class TowerScript : MonoBehaviour
{

    [SerializeField] public HealthBar healthBar;
    [SerializeField]TextMeshProUGUI scoreText;
    public Text textWon;
    public Text textLost;
    public float health;

    public static int puntos;

    public GameObject gameOver;

    GameObject referenceCamera;
    CameraScript referenceCameraScript;
    public AudioSource audioSource;
    public AudioClip coin;
    public AudioClip boom;
    public AudioClip gameOverSound;

    public AudioMixer audioMixer;
    void Start()
    {
        health = 1f;
        puntos = 0;

        scoreText.text = "0";
        Time.timeScale=1;
        Physics2D.IgnoreLayerCollision(0, 8, false);

        referenceCamera = GameObject.FindWithTag("MainCamera");
        referenceCameraScript = referenceCamera.GetComponent<CameraScript>();
    }

    void Update() {
        textWon.text = puntos.ToString();
        textLost.text = puntos.ToString();
        scoreText.text = puntos.ToString();
    }


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag != "Bullet" && col.gameObject.tag != "CannonBullet") { 
            if (col.gameObject.tag == "Ally")
            {
                Destroy(col.gameObject);
                puntos += 100;
                scoreText.text = puntos.ToString();
                audioSource.PlayOneShot(coin);
            }
            else if (health > 0.1)
            {
                health -= 0.2f;
                healthBar.SetSize(health);
                Destroy(col.gameObject);
                referenceCameraScript.shakeDuration = 1f;
                audioSource.PlayOneShot(boom);
            }

            if (health <= 0.1)
            {
                Physics2D.IgnoreLayerCollision(0, 8, true);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                gameOver.SetActive(true);
                audioSource.PlayOneShot(gameOverSound);
                audioMixer.SetFloat("Music_Param",0f);
                audioMixer.SetFloat("Env_Param",0f);
                referenceCameraScript.shakeDuration = 0f;
            }
        }
    }
    
}
