using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loosePlant : MonoBehaviour
{
    [SerializeField]
    private GameObject chiottes;
    private SpriteRenderer chiottes_sprite;
    private SpriteRenderer shrek_sprite;
    [SerializeField]
    private Sprite[] spriteChiottes;
    [SerializeField]
    private Sprite[] spriteShrek;

    public float tempsDeMarcheDeShrek = 10;

    float beginTime;
    float tempsEcoule;
    int nTours;
    bool countTime;
    bool hasToMove;

    private AudioSource grr;
    public AudioClip gre1;
    public AudioClip gre2;
    public AudioClip gre3;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        chiottes_sprite= chiottes.GetComponent<SpriteRenderer>();
        shrek_sprite= gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        hasToMove = false;
        grr=GetComponent<AudioSource>();
    } 

    // Update is called once per frame
    void Update()
    {

        if (hasToMove)
        {
            transform.position = transform.position + new Vector3(3 * Time.deltaTime, 0, 0);
        }
    }

    public void loose()
    {
        beginTime = Time.fixedTime;
        countTime = true;
        nTours = 0;
    }

    private void FixedUpdate()
    {
        if (countTime)
        {
            tempsEcoule = Time.fixedTime - beginTime;

            if (nTours == 0)
            {
                grr.PlayOneShot(gre2, 1);
                nTours++;
            }

            if(tempsEcoule >= 2 && nTours == 1)
            {
                chiottes_sprite.sprite = spriteChiottes[1];
                shrek_sprite.enabled = true;
                nTours++;
            }

            if (tempsEcoule >= 4 && nTours == 2)
            {
                chiottes_sprite.sprite = spriteChiottes[0];
                shrek_sprite.sprite = spriteShrek[1];
                nTours++;
            }
            if (tempsEcoule >= 5 && nTours == 3)
            { 
                hasToMove = true;
                anim.SetBool("Marche", true);
                nTours++;
            }
            if (tempsEcoule >= 6+tempsDeMarcheDeShrek && nTours == 4)
            {
                hasToMove = false;
                anim.SetBool("Marche", false);
                nTours++;
            }
            if (tempsEcoule >= 7 + tempsDeMarcheDeShrek && nTours == 5)
            {
                shrek_sprite.sprite = spriteShrek[2];
                grr.PlayOneShot(gre3, 1); grr.PlayOneShot(gre3, 1); grr.PlayOneShot(gre3, 1);
                nTours++;
            }
            if (tempsEcoule >= 9 + tempsDeMarcheDeShrek && nTours == 6)
            {
                shrek_sprite.sprite = spriteShrek[3];
                nTours++;
            }
        }
    }
}