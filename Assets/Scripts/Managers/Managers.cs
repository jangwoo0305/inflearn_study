using Unity.VisualScripting;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static Managers s_instance; // 유일성 보장
    public static Managers Instance {get { init(); return s_instance;}} // 유일한 매니저를 가져온다.
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject{name = "@Managers"};
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
} 
