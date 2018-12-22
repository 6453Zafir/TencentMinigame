using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRedLine : MonoBehaviour {

    private float duration = 1.0f;//持续时间
    private bool delete = false;
    [SerializeField]
    public LineRenderer m_LineRenderer;
    [SerializeField]
    protected bool m_AddCollider = false;
    [SerializeField]
    protected EdgeCollider2D m_EdgeCollider2D;
    [SerializeField]
    protected Camera m_Camera;

    private float limit = 5.6f;
    public static bool can_draw_red;//是否用红画笔
    public static bool is_draw_red;//是否作画

    private float begin_time;
    protected List<Vector2> m_Points;
    protected List<List<Vector2>> pos;
    private Vector2 buffer = Vector2.zero;
    private Vector2 now = Vector2.zero;
    private Vector2 end = Vector2.zero;
    private Vector2 firepoint1 = Vector2.zero;
    private Vector2 firepoint2 = Vector2.zero;
    private Vector2 firepoint3 = Vector2.zero;
    private Vector2 V = Vector2.zero;
    private Vector2 V1 = Vector2.zero;
    private Vector2 miss = new Vector2(27.75456f, 2.521699f);
    private RaycastHit2D Hit;
    public GameObject m_line;
    //鼠标前后点的距离
    private float reddistance;
    //前后火点的距离
    private float firedistance;
    private float Firedistance = 0.8f;
    private float HadDrawDistance = 0.0f;
    [SerializeField]
    public GameObject myPrefab;

    private int DelRedLine_num = 0;
    private int DelFire_num = 0;
    public Material m_material;



    public virtual LineRenderer lineRenderer
    {
        get
        {
            return m_LineRenderer;
        }
        set
        {
            m_LineRenderer = value;
        }
    }

    public virtual GameObject line
    {
        get
        {
            return m_line;
        }
    }

    public virtual bool addCollider
    {
        get
        {
            return m_AddCollider;
        }
    }

    public virtual EdgeCollider2D edgeCollider2D
    {
        get
        {
            return m_EdgeCollider2D;
        }
    }

    public virtual List<Vector2> points
    {
        get
        {
            return m_Points;
        }
    }

    //Debug info
    protected virtual void Awake()
    {
        buffer = Vector2.zero;
        now = Vector2.zero;
        firepoint1 = Vector2.zero;
        firepoint2 = Vector2.zero;
        begin_time = 0.0f;

        can_draw_red = false;
        if (m_LineRenderer == null)
        {
            //Line Render not assigned
            Debug.LogWarning("DrawLine: Line Renderer not assigned, Adding and Using default Line Renderer.");
            CreateDefaultLineRenderer();
        }
        if (m_EdgeCollider2D == null && m_AddCollider)
        {
            //Edge Collider 2D not assigned
            Debug.LogWarning("DrawLine: Edge Collider 2D not assigned, Adding and Using default Edge Collider 2D.");
            CreateDefaultEdgeCollider2D();
        }
        if (m_Camera == null)
        {
            //Camera not assigned
            m_Camera = Camera.main;
        }
        m_Points = new List<Vector2>();
        pos = new List<List<Vector2>>();//对线的初始化
    }

    //Get the mouseButtonDown position
    protected virtual void Update()
    {

        if (PlayerController.fire_count && (Time.time - begin_time) > duration)
        {//火区持续时间到了      
            DeleteLine();       
            return;
        }
        if(delete)
        {
            if (DelFire_num != 0)
            {
              //  Debug.Log(DelFire_num + "DelFire_num");
                var fire = GameObject.Find("fire");
                Destroy(fire);
                DelFire_num -= 1;
            }
            if (DelFire_num == 0) delete = false;
            return;
        }
        

        if (PlayerController.fire_count)
        {//计时时不允许画画
            return;
        }

        if (!can_draw_red) return;

        if (can_draw_red) {
            if (Input.GetMouseButtonDown(0))
            {
                is_draw_red = true;
            }
        }

        if(Input.GetMouseButtonUp(0)&&is_draw_red)
        {
            can_draw_red = false;
            is_draw_red = false;
            PlayerController.fire_count = true;//火生效
            begin_time = Time.time;//火生效的开始时间
            GameController.RedLine_num += 1;    //已画线条数加一
        }
        if (HadDrawDistance >= limit) return;//超过560像素
        if (Input.GetMouseButtonDown(0) && GameController.InkDistance > 0)//判定是否是画的一条新线
        {
            if(GameController.RedLine_num==1)
            {
                DeleteLine();
            }
            
            buffer = Vector2.zero;                //初始化上一画点
            now = Vector2.zero;                   //初始化现在画点
            firepoint1 = Vector2.zero;
            firepoint2 = Vector2.zero;
            firepoint3 = Vector2.zero;
            m_Points = new List<Vector2>();       //初始化一条新线
            pos.Add(m_Points);                    //添加到线的数组           
            m_line = new GameObject("RedDraw");      //创建新的物体作为画线
            m_line.tag = "Fire";

            m_LineRenderer = m_line.AddComponent<LineRenderer>();
            m_EdgeCollider2D = m_line.AddComponent<EdgeCollider2D>();          
            m_EdgeCollider2D.isTrigger = true;
            //Settings of the linerender component
            m_LineRenderer.positionCount = 0;       //Describe an array of Vector3 points to connect
            m_LineRenderer.material = m_material;      //Line material
            m_LineRenderer.startColor = Color.white;        //The color of startpoint
            m_LineRenderer.endColor = Color.white;         //The color of endpoint
            m_LineRenderer.startWidth = 1f; //The width of startpoint
            m_LineRenderer.endWidth = 1f;   //The width of endpoint
            m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates


        }
        else if (Input.GetMouseButton(0) && GameController.InkDistance > 0)
        {
            Vector2 mousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);


            //如果刚开始画，对上一次鼠标位置做储存
            if (buffer == Vector2.zero)
            {
                Vector2 mousePosition1 = mousePosition;
                buffer = mousePosition1;
                firepoint1 = mousePosition1;

                return;
            }
            //对现在位置做储存
            else
            {
                now = mousePosition;
                firepoint2 = mousePosition;
            }

            m_EdgeCollider2D.enabled = false;
            if (Hit = Physics2D.Linecast(buffer, now))
            {
                if (Hit.collider.tag != "Player" && Hit.collider.tag != "Boat" && Hit.collider.tag != "Fire" && Hit.collider.tag != "Tree")
                {
                    m_EdgeCollider2D.enabled = true;
                    return;
                }
            }
            m_EdgeCollider2D.enabled = true;
            if (now != Vector2.zero)
            {
                //计算两点之间距离
                Vector2 offset = now - buffer;
                reddistance = offset.magnitude;
                Vector2 offset1 = firepoint2 - firepoint1;
                firedistance = offset1.magnitude;
                V1 = offset1.normalized;
                firepoint3 = firepoint1 + V1 * Firedistance;
                //当剩余墨量大于需要画出的线段并且没有超过560像素
                if (!m_Points.Contains(mousePosition) && (GameController.InkDistance - reddistance) >= 0 && (reddistance + HadDrawDistance) < limit)
                {
                    //火点距离大于一定值，产生火团效果
                    if (firedistance > Firedistance)
                    {
                        GameObject newObject = Instantiate(myPrefab) as GameObject;
                        newObject.transform.position = firepoint3 + miss;
                        newObject.transform.name = "fire";
                        GameController.Fire_num += 1;
                        firepoint1 = firepoint3;
                    }

                    GameController.InkDistance = GameController.InkDistance - reddistance;
                    HadDrawDistance += reddistance;
                    m_Points.Add(mousePosition);
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, mousePosition);
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();
                    }
                }
                else if (!m_Points.Contains(mousePosition) && (GameController.InkDistance - reddistance) >= 0 )
                {
                    float NowCanDraw = limit - HadDrawDistance;
                    V = offset.normalized;
                    end = buffer + V * NowCanDraw;
                    HadDrawDistance += NowCanDraw;
                    //火点距离大于一定值，产生火团效果
                    if (firedistance > Firedistance)
                    {
                        GameObject newObject = Instantiate(myPrefab) as GameObject;
                        newObject.transform.position = firepoint3 + miss;
                        newObject.transform.name = "fire";
                        GameController.Fire_num += 1;
                        firepoint1 = firepoint3;
                    }

                    m_Points.Add(end);
                    m_LineRenderer.positionCount = m_Points.Count;
                    m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, end);
                    if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                    {
                        m_EdgeCollider2D.points = m_Points.ToArray();
                    }
                    GameController.InkDistance -= NowCanDraw;
                }
                //当剩余墨量小于需要画出的线段
                else if (!m_Points.Contains(mousePosition) && (GameController.InkDistance - reddistance) < 0)
                {
                    float NowCanDraw = limit - HadDrawDistance;
                    if(NowCanDraw>GameController.InkDistance)
                    {
                        V = offset.normalized;
                        end = buffer + V * GameController.InkDistance;
                        HadDrawDistance += GameController.InkDistance;
                        //火点距离大于一定值，产生火团效果
                        if (firedistance > Firedistance)
                        {
                            GameObject newObject = Instantiate(myPrefab) as GameObject;
                            newObject.transform.position = firepoint3 + miss;
                            newObject.transform.name = "fire";
                            GameController.Fire_num += 1;
                            firepoint1 = firepoint3;
                        }

                        m_Points.Add(end);
                        m_LineRenderer.positionCount = m_Points.Count;
                        m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, end);
                        if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                        {
                            m_EdgeCollider2D.points = m_Points.ToArray();
                        }
                        GameController.InkDistance = 0;
                    }
                    else
                    {
                        V = offset.normalized;
                        end = buffer + V * NowCanDraw;
                        HadDrawDistance += NowCanDraw;
                        //火点距离大于一定值，产生火团效果
                        if (firedistance > Firedistance)
                        {
                            GameObject newObject = Instantiate(myPrefab) as GameObject;
                            newObject.transform.position = firepoint3 + miss;
                            newObject.transform.name = "fire";
                            GameController.Fire_num += 1;
                            firepoint1 = firepoint3;
                        }
                        m_Points.Add(end);
                        m_LineRenderer.positionCount = m_Points.Count;
                        m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, end);
                        if (m_EdgeCollider2D != null && m_AddCollider && m_Points.Count > 1)
                        {
                            m_EdgeCollider2D.points = m_Points.ToArray();
                        }
                        GameController.InkDistance -= NowCanDraw;
                    }
                }
                buffer = now;


            }

        }


    }

    public void DeleteLine()
    {
        //Debug.Log("111");
        PlayerController.fire_count = false;
        DelRedLine_num = GameController.RedLine_num;
        GameController.RedLine_num = GameController.RedLine_numzero;
        DelFire_num = GameController.Fire_num;
        GameController.Fire_num = GameController.Fire_numzero;
        //若有需要回收的墨水则进行回收
        if (DelRedLine_num != 0)
        {

            var draw = GameObject.Find("RedDraw");
            //Debug.Log("delete line" + draw);
            Destroy(draw);
            DelRedLine_num -= 1;
            if (DelRedLine_num == 0)
            {
                
                GameController.InkDistance += HadDrawDistance;
                HadDrawDistance = 0;
              //  Debug.Log(GameController.InkDistance+"dfassaf");
            }
           
        }
        delete = true;
    }


    protected virtual void CreateDefaultLineRenderer()
    {
        //Add linerender component
        m_LineRenderer = gameObject.AddComponent<LineRenderer>();
        //Settings of the linerender component
        m_LineRenderer.positionCount = 0;       //Describe an array of Vector3 points to connect
        m_LineRenderer.material = m_material;      //Line material
        m_LineRenderer.startColor = Color.white;        //The color of startpoint
        m_LineRenderer.endColor = Color.white;         //The color of endpoint
        m_LineRenderer.startWidth = 1f; //The width of startpoint
        m_LineRenderer.endWidth = 1f;   //The width of endpoint
        m_LineRenderer.useWorldSpace = true;  //The points are considered as world space coordinates
    }

    protected virtual void CreateDefaultEdgeCollider2D()
    {
        m_EdgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
    }
}
