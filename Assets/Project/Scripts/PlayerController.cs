using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rig;
    //public float speed; 废弃的速度
    public float transformSpeed;//不用刚体的移动速度
    private float lastSecondPosition;//物体上一秒的位置

    // private Vector2 previous_v = Vector2.zero;
    private int face;//记录朝向
    private Vector2 wind_direction = Vector2.zero;//风向的单位向量
    /// <summary>
    /// 0：未死亡
    /// 1：摔死
    /// 2：淹死
    /// 3：烧死
    /// </summary>
    public static int DeadType = 0;
    public static bool canControl = true;
    public static bool can_draw_blue;//是否青画笔
    public static bool can_draw_red;//是否用红画笔
    public static bool can_draw_black;//是否用黑色画笔
    public static bool fire_count = false;//火开始生效，开始计时
    public static bool begin_count = false;
    public static bool PlayerMove = true;
    public GameObject Draw_blue;
    public Material NormalMat, CaveMat;
    private Vector2 add = new Vector2(0, 90.0f);
    private float forceBegin_time;
    public GameObject Stone;
    public GameObject Rope;
    public Vector3 StonePos = new Vector3(466.27f,6.62f,0);
    public Vector3 RopePos = new Vector3(466.17f, 9.266941f,0);
    private bool force_count = false;//风力开始计时

    private bool isBurnFireNewed = false;


    // public static bool wind_ready = false;//风生效
    //private bool fire_ready = false;//火生效
    // public static float begin_time=0.0f;
    //public GameObject Draw_blue;
    //>>>>>>> Stashed changes
    // Use this for initialization
    private Animator characterAnimator;//人物动画机

    private Vector2 touchPosition;  //触摸点坐标
    private float screenWeight; //屏幕宽度

    public bool isPainting; //是否正在画

    //两种画笔的音效控制
    //public AudioClip drawFireAudio;//火焰音效
    //public AudioClip drawWindAudio;//风音效
    //private AudioSource audioController;



    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        face = 1;//开始向右
        forceBegin_time = 0.0f;

        //begin_count = false;
        touchPosition = new Vector2();
        screenWeight = Screen.width;
        characterAnimator = GetComponent<Animator>();
        isPainting = false;

        //audioController = this.GetComponent<AudioSource>();

        transformSpeed = 0.04f; //初始化速度
        lastSecondPosition = this.transform.position.x; //初始化上一帧位置

    }

    // Update is called once per frame
    void Update()
    {
        // if (audioController.isPlaying == false)
        // {
        //音效控制
        //     if (DrawBlueLine.can_draw_blue == true)
        //         audioController.PlayOneShot(drawWindAudio);
        //     if (DrawRedLine.can_draw_red == true)
        //         audioController.PlayOneShot(drawFireAudio);
        // }


        isPainting = DrawLine2D.can_draw_black || DrawBlueLine.can_draw_blue || DrawRedLine.can_draw_red;

        characterAnimator.SetBool("canControl", canControl);
        //设置人物动画机参数 ，动画机共两个bool参数，一个isMoving(是否走路)，一个isPainting(是否绘画)，绘画动画优先。
        if (this.transform.position.x > lastSecondPosition)
        {
            characterAnimator.SetBool("isMoving", true);
            this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, 0, this.transform.localEulerAngles.z);
        }
        else if (this.transform.position.x < lastSecondPosition)
        {
            characterAnimator.SetBool("isMoving", true);
            this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, 180, this.transform.localEulerAngles.z);
        }
        else
            characterAnimator.SetBool("isMoving", false);
        lastSecondPosition = this.transform.position.x;

        //废弃了
        /*
        if (rig.velocity.x != 0)
        {
            characterAnimator.SetBool("isMoving", true);  //人物速度不为零，设置变量，播放走路动画
        }
        else
        {
            characterAnimator.SetBool("isMoving", false);
        }
        */

        //设置人物动画机参数
        if (isPainting == true)
        {
            characterAnimator.SetBool("isPainting", true);  //正在绘画，设置动画机参数
        }
        else
        {
            characterAnimator.SetBool("isPainting", false);  //不在绘画，设置动画机参数
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (EventSystem.current.IsPointerOverGameObject())
        //    {

        //        print("On UI");
        //    }
        //    else
        //    {
        //        print("On scene");
        //    }
        //}
        if (isPainting == false && canControl)//不在绘画方能移动
        {
            //触摸屏幕控制左右移动
            if (Input.touchCount > 0)
            {
                if (IsPointerOverUIObject())
                {

                }
                else
                {
                    for (int i = 0; i < Input.touchCount; i++)
                    {
                        Touch touch = Input.touches[i];
                        //手指触摸但没有移动/滑动
                        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                        {
                            touchPosition = touch.position;
                            //对比屏幕坐标进行移动
                            if (touchPosition.x > screenWeight / 2)
                            {
                                //rig.velocity = new Vector2(speed, rig.velocity.y);
                                this.transform.position = new Vector3(this.transform.position.x + transformSpeed, this.transform.position.y, this.transform.position.z);
                            }
                            else if (touchPosition.x < screenWeight / 2)
                            {
                                //rig.velocity = new Vector2(-speed, rig.velocity.y);
                                this.transform.position = new Vector3(this.transform.position.x - transformSpeed, this.transform.position.y, this.transform.position.z);
                            }

                        }
                    }
                }

            }
        }

        if (transform.position.x > 346f && transform.position.x < 494.31f)
        {
            GetComponent<SpriteRenderer>().material = CaveMat;
            Camera.main.backgroundColor = Color.black;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            GetComponent<SpriteRenderer>().material = NormalMat;
            Camera.main.backgroundColor = 0.95f * Color.white;
            if (transform.GetChild(0).gameObject.activeInHierarchy)
                transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    void FixedUpdate()
    {
        if (isPainting == false&&canControl)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //rig.velocity = new Vector2(-speed, rig.velocity.y);
                this.transform.position = new Vector3(this.transform.position.x - transformSpeed, this.transform.position.y, this.transform.position.z);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //rig.velocity = new Vector2(speed, rig.velocity.y);
                this.transform.position = new Vector3(this.transform.position.x + transformSpeed, this.transform.position.y, this.transform.position.z);
            }
        }

        if (GameController.wind_count && GameController.forceReady)//风区存在并未加过力时
        {
            //return;
            if (!force_count)
            {
                forceBegin_time = Time.time;
                Debug.Log("forceBegin_time " + forceBegin_time);
                force_count = true;
                wind_direction = (DrawBlueLine.wind_end - DrawBlueLine.wind_start);//风向的单位向量


                rig.AddForce(wind_direction * GameController.windforce + add, ForceMode2D.Force);
                Debug.Log("wind_direction * GameController.windforce111111杀" + wind_direction * GameController.windforce + add);

            }

            //Debug.Log("wind_direction * windforce" + wind_direction * GameController.windforce);
            if (Time.time - forceBegin_time >= GameController.forceDuration)
            {
                Debug.Log("力的作用时间到了" + Time.time);

                GameController.forceReady = false;//加过力了,不用加了
                force_count = false;//风力计时结束
            }

        }

        //删掉
        /*
        if (rig.velocity.x < 0)
            this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x,180,this.transform.localEulerAngles.z);
        else if (rig.velocity.x > 0)
            this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x,0, this.transform.localEulerAngles.z);
        */

    }


    public void startDraw(int InkNum)
    {
        switch (InkNum)
        {
            case 0:
                //black
                if (GameController.InkDistance > 0) DrawLine2D.can_draw_black = !DrawLine2D.can_draw_black;
                else DrawLine2D.can_draw_black = false;
                DrawBlueLine.can_draw_blue = false;
                DrawRedLine.can_draw_red = false;
                break;
            case 1:
                //blue
                if (GameController.InkDistance > 0) DrawBlueLine.can_draw_blue = !DrawBlueLine.can_draw_blue;
                else DrawBlueLine.can_draw_blue = false;
                DrawRedLine.can_draw_red = false;
                DrawLine2D.can_draw_black = false;
                GameController.wind_count = false;
                break;
            case 2:
                //red
                if (GameController.InkDistance > 0) DrawRedLine.can_draw_red = !DrawRedLine.can_draw_red;
                else DrawRedLine.can_draw_red = false;
                DrawLine2D.can_draw_black = false;
                DrawBlueLine.can_draw_blue = false;
                fire_count = false;
                break;
            default:
                break;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Light" || other.tag == "Fire")
        {
            Debug.Log("burn");
            Burn();
            return;
        }
        if (!GameController.wind_count && !fire_count) return;





        if (other.tag == "Wind" && PlayerMove)
        {
            if (!begin_count)
            {
                GameController.forceReady = true;
                begin_count = true;
            }

        }
    }

    public void Burn()
    {
        if (!isBurnFireNewed)
        {
            var Stone1 = GameObject.Find("吊石");
            if(Stone1)
            {
                var Rope1 = GameObject.Find("绳子");
                if(Rope1) Destroy(Rope1);
                Destroy(Stone1);
                GameObject newObject = Instantiate(Stone) as GameObject;
                newObject.transform.position = StonePos;
                newObject.transform.name = "吊石";
                GameObject newObject1 = Instantiate(Rope) as GameObject;
                newObject1.transform.position = RopePos;
                newObject1.transform.name = "绳子";
            }
           
            GameObject BornParticle = Instantiate(Resources.Load("PlayerFireParticle") as GameObject, transform);
            BornParticle.transform.localPosition = Vector3.zero;

            var shape = BornParticle.GetComponent<ParticleSystem>().shape;
            shape.enabled = true;
            // shape.spriteRenderer.enabled = true;

            shape.shapeType = ParticleSystemShapeType.SpriteRenderer;
            shape.meshShapeType = ParticleSystemMeshShapeType.Edge;
            shape.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

            StartCoroutine(ClearBurnParticle(3f, BornParticle));
            isBurnFireNewed = true;
        }
    }

    IEnumerator ClearBurnParticle(float waittime, GameObject obToDestory)
    {
        yield return new WaitForSeconds(waittime);
        DeadType = 3;
        isBurnFireNewed = false;
        Destroy(obToDestory);
    }
}