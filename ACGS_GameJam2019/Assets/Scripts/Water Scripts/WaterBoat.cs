using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterBoat : MonoBehaviour
{
    AudioManager audioManager;

    private float horizVel;
    public float forwardVelocity;

    public int laneNum = 2;
    public string controlLocked = "n";

    public ParticleSystem rainParticle;
    public ParticleSystem fogParticle;

    public Animator rainText;

    public GameObject rainCountdown;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, forwardVelocity);

        if(Input.GetKeyDown(KeyCode.A) && laneNum>1 && controlLocked == "n")
        {
            horizVel = -20;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }

        if (Input.GetKeyDown(KeyCode.D) && laneNum<3 && controlLocked == "n")
        {
            horizVel = 20;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }

        if (Input.GetKeyDown(KeyCode.Space) && controlLocked == "n")
        {

        }
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        horizVel = 0;
        controlLocked = "n";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp")
        {
            other.gameObject.SetActive(false);
            //fogParticle.Clear();
            fogParticle.Stop();
            rainParticle.Play();
            StartCoroutine(restartWeather());
        }

        if (other.gameObject.tag == "Lethal")
        {
            Destroy(other.gameObject);
            LoadGameOver();
        }
    }

    public void LoadGameOver()
    {
            audioManager.StopSound("Level1_BGM");
            audioManager.PlaySound("GameOver_BGM");
            SceneManager.LoadScene("GameOver");
    }

    IEnumerator restartWeather()
    {
        rainCountdown.SetActive(true);
        yield return new WaitForSeconds(7f);
        fogParticle.Play();
        rainParticle.Stop();
        rainCountdown.SetActive(false);
    }
}
