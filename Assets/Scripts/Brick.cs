using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public AudioClip crack;
    public Sprite[] hitSprite;
    public static int breakableCount = 0;
    public GameObject smoke;
    private Level_Manager level_Manager;
    private int timesHit;
    private int maxHits;
    private bool isBreakable; 
    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position,2f);
        if (isBreakable)
        {
            HandleHits();
        }
    }


    void HandleHits()
    {
        Vector3 smokePos = gameObject.transform.position;
        timesHit++;
        maxHits = hitSprite.Length + 1;
        print(breakableCount);
        if (timesHit >= maxHits)
        {
            breakableCount--;
            level_Manager.BrickDestroyed();
            GameObject smokePuff;
            smokePuff = Instantiate(smoke, smokePos, Quaternion.identity);
            ParticleSystem.MainModule main= smokePuff.GetComponent<ParticleSystem>().main;
            main.startColor = gameObject.GetComponent<SpriteRenderer>().color;

            Destroy(gameObject);
        }
        else
        {
            LoadSprite();
        }
    }

    void LoadSprite()
    {
        int spriteIndex = timesHit-1;
        if (hitSprite[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }
    }

     void Awake()
    {
        if (breakableCount > 0)
        {
            breakableCount = 0;
        }
    }

    // Use this for initialization

    void Start () {
        
        isBreakable = (this.tag == "Breakable");
        timesHit = 0;
        if (isBreakable)
        {
            breakableCount++;
        }
        level_Manager = GameObject.FindObjectOfType<Level_Manager>();
        print(breakableCount);
    }
	
	// Update is called once per frame
	void Update () {
       
		
	}
    //TODO Remove this
    void SimulateWin()
    {
        level_Manager.LoadNextLevel();
    }
}
