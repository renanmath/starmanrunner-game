using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class MainPlayer : MonoBehaviour
{
    public GameObject yellowBulletPrefab;
    public Transform firePoint;
    public GameObject explosionPrefab;
    public Text bulletText;
    public Text flyingText;
    public Text countdownText;
    public Text hpText;
    public int hpLife;

    public static MainPlayer instance;

    private Rigidbody2D rigbody;
    public float playerSpeed = 3f;
    public float jumpForce = 700f;
    private Animator playerAnimator;
    private bool isPlayerJumping;
    private bool isPlayerFlying;    
    private int amoutYellowBullet = 150;
    private int flyingChances;


    void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        isPlayerJumping = false;
        isPlayerFlying = false;
        flyingChances = 1;
        hpLife = 200;
        bulletText.text = amoutYellowBullet.ToString();
        flyingText.text = flyingChances.ToString();
        hpText.text = hpLife.ToString();
        instance = this;
        
        
    }

    void FixedUpdate()
    {
        rigbody.velocity = new Vector2(playerSpeed, rigbody.velocity.y);

        if(isPlayerFlying)
        {
            rigbody.AddForce(new Vector2(0, 700f - 5*transform.position.y), ForceMode2D.Force);
            
            if(transform.position.y > 10f)
            {
                rigbody.AddForce(new Vector2(0, -200f), ForceMode2D.Force);
            }

        }
    }

    void Update()
    {
        // normal jump
        if(Input.GetKeyDown(KeyCode.Space) && !isPlayerJumping && !isPlayerFlying)
        {
            normalJump();
            
        }

        // small jump
        if(Input.GetKeyDown(KeyCode.UpArrow) && !isPlayerJumping && !isPlayerFlying)
        
        {
            rigbody.AddForce(new Vector2(0, jumpForce - 350f), ForceMode2D.Impulse);
            playerAnimator.SetBool("isJumping", true);
            isPlayerJumping = true;
        }

        // random jump
        if (Input.GetKeyDown(KeyCode.J) && !isPlayerJumping)
        {
            float jumpVariantion = Random.Range(-7f, 5f);
            rigbody.AddForce(new Vector2(0, jumpForce + jumpVariantion), ForceMode2D.Impulse);
            playerAnimator.SetBool("isJumping", true);
            isPlayerJumping = true;
        }

        // flyMode controls
        if(Input.GetKey(KeyCode.W) && isPlayerFlying)
        {
            flyUp();
        }

        if(Input.GetKey(KeyCode.S) && isPlayerFlying)
        {
            flyDown();
        }

        if(Input.GetKey(KeyCode.A) && isPlayerFlying)
        {
            flyLeft();
        }

        if(Input.GetKey(KeyCode.D) && isPlayerFlying)
        {
            flyRight();
            
        }


        if(Input.GetKeyDown(KeyCode.RightArrow) && amoutYellowBullet > 0)
        {
            
            shootFire();
            
        }

        if(Input.GetKeyDown(KeyCode.F) && !isPlayerFlying && flyingChances > 0)
        {
            StartCoroutine(beginFlyMode());
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "platform")
        {
            playerAnimator.SetBool("isJumping", false);
            isPlayerJumping = false;
        }

        if(col.gameObject.tag == "bomb")
        {
            GameObject deathExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject, 0.1f);
            Destroy(deathExplosion, 0.3f);
            StartCoroutine(waiter());
            GameManeger.instance.showGameOverScreen();

        }

        if(col.gameObject.tag == "boundary")
        {
            rigbody.AddForce(new Vector2(20, 0), ForceMode2D.Force);
        }
    }


    // dynimic phisics functions
    public void normalJump()
    {
        if(!isPlayerJumping && !isPlayerFlying)
        {
        rigbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        playerAnimator.SetBool("isJumping", true);
        isPlayerJumping = true;
        }
    }

    public void shootFire()
    {
        if(amoutYellowBullet > 0)
        {
            GameObject newBullet = Instantiate(yellowBulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(newBullet, 1f);
            AudioManager.instance.playSound(AudioManager.instance.shootSound);
            amoutYellowBullet --;
            bulletText.text = amoutYellowBullet.ToString();
        }

        if (amoutYellowBullet == 50)
        {
            SpawnItem.instance.spawnBulletItem();
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1f);
    }

    public void increaseAmmunition(int plus)
    {
        amoutYellowBullet += plus;
        bulletText.text = amoutYellowBullet.ToString();
    }

    IEnumerator beginFlyMode()
    {
        float initialFlyPosition = transform.position.x;
        flyingChances--;
        if(flyingChances <= 0)
        {
            flyingChances = 0;
            SpawnItem.instance.spawnFlyingItem();
        }
        
        flyingText.text = flyingChances.ToString();

        isPlayerFlying = true;
        transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 1f, transform.position.z);
        playerSpeed = 5f;
        rigbody.AddForce(new Vector2(1000f, 7000f), ForceMode2D.Force);

        for(int i = 30; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);

        }

        countdownText.text = ' '.ToString();
        playerSpeed = 3f;
        isPlayerFlying = false;
        
    }

    public void beginFly()
    {
        if(!isPlayerFlying)
        {
            StartCoroutine(beginFlyMode());
            flyingChances += 2;
            flyingText.text = flyingChances.ToString();
        }
        else
        {
            flyingChances++;
            flyingText.text = flyingChances.ToString();
        }
                
    }

    public void startFly()
    {
        if(!isPlayerFlying && flyingChances > 0)
        {
            StartCoroutine(beginFlyMode());
        }
    }

    public void flyUp()
    {
        if(isPlayerFlying)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        }
    }

    public void flyDown()
    {
        if(isPlayerFlying)
        {
             transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
    }

    public void flyLeft()
    {
        if(isPlayerFlying)
        {
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        }
    }

    public void flyRight()
    {
        if(isPlayerFlying)
        {
            transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z);
        }
    }

    public void receiveDemage(int demageReceived)
    {
        hpLife -= demageReceived;
        if (hpLife < 0)
        {
            hpLife =0;
        }
        if (hpLife < 25)
        {
            SpawnItem.instance.spawnHeart();
        }
         if(hpLife > 500)
         {
             hpLife = 500;
         }

         hpText.text = hpLife.ToString();
        
        if(hpLife == 0)
        {
            GameManeger.instance.showGameOverScreen();
        }
    }

}
