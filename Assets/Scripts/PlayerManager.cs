using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Sprite JinStat;
    public Sprite JinWalkA;
    public Sprite JinWalkB;
    public GameObject Cam;
    public GameObject jinSprite;
    public float Speed=1f;

    public float aniSpeed = 0.5f;
    public float addFrame = 1f;
    // Start is called before the first frame update
    void Start()
    {
        jinSprite.GetComponent<SpriteRenderer>().sprite = JinStat;
    }

    // Update is called once per frame
    void Update()
    {
        //Walking speed
        //debug section
        print("Frame:" + aniSpeed);
        print(transform.rotation.z);
        
        
        #region MovingCamWithPlayer
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, Speed * Time.deltaTime,0);
            Cam.transform.Translate(0, Speed * Time.deltaTime,0);
            jinSprite.transform.rotation = Quaternion.Euler(0,0,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -Speed * Time.deltaTime,0);
            Cam.transform.Translate(0, -Speed * Time.deltaTime,0);
            jinSprite.transform.rotation = Quaternion.Euler(0,0,180);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Speed * Time.deltaTime,0,0);
            Cam.transform.Translate(-Speed * Time.deltaTime,0,0);
            jinSprite.transform.rotation = Quaternion.Euler(0,0,90);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Speed * Time.deltaTime,0,0);
            Cam.transform.Translate(Speed * Time.deltaTime,0,0);
            jinSprite.transform.rotation = Quaternion.Euler(0,0,270);
        }
        #endregion

        #region WalkingAnimation
        
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            aniSpeed += addFrame * Time.deltaTime;
            if (aniSpeed >= 1 && aniSpeed < 2)
            {
                jinSprite.GetComponent<SpriteRenderer>().sprite = JinWalkA;
            }
            if (aniSpeed >= 2 && aniSpeed < 3)
            {
                jinSprite.GetComponent<SpriteRenderer>().sprite = JinWalkB;
            }
            if (aniSpeed >= 3)
            {
                aniSpeed = 1;
            }
        }
        else
        {
            aniSpeed = 0.5f;
            jinSprite.GetComponent<SpriteRenderer>().sprite = JinStat;
        }
        

        #endregion
    }
}
