using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using System.Collections.Generic;
using TMPro;

public class ARButtonController : MonoBehaviour
{
    // 부품 3D 오브젝트 객체
    public GameObject M; 
    public GameObject r1; 
    public GameObject r2;
    public GameObject C;
    public GameObject CC;
    public GameObject GC;
    public GameObject P;
    public GameObject CA;
    public GameObject M_all;
    public GameObject CASE_all;

    // 합친 메인보드 3D 오브젝트 객체
    public GameObject M_r1;
    public GameObject M_r2;
    public GameObject M_r1_r2;
    public GameObject M_r1_r2_GC;
    public GameObject M_r1_r2_C_GC;
    public GameObject M_r2_GC;
    public GameObject M_r1_r2_C_CC_GC;
    public GameObject M_r2_C_CC_GC;
    public GameObject M_r1_C_CC_GC;
    public GameObject M_r1_C;
    public GameObject M_r1_C_CC;
    public GameObject M_r1_C_GC;
    public GameObject M_r2_C;
    public GameObject M_r2_C_CC;
    public GameObject M_r2_C_GC;
    public GameObject M_C;
    public GameObject M_C_CC_GC;
    public GameObject M_C_CC;
    public GameObject M_C_GC;
    public GameObject M_GC;
    public GameObject M_r1_GC;
    public GameObject M_r1_r2_C;
    public GameObject M_CA;
    public GameObject M_C_CA;
    public GameObject M_C_CC_CA;
    public GameObject M_C_CC_GC_CA;
    public GameObject M_C_CC_GC_P_CA;
    public GameObject M_C_GC_CA;
    public GameObject M_C_GC_P_CA;
    public GameObject M_GC_CA;
    public GameObject M_C_CC_P_CA;
    public GameObject M_P_CA;
    public GameObject M_r1_CA;
    public GameObject M_r1_C_CA;
    public GameObject M_r1_C_CC_CA;
    public GameObject M_r1_C_CC_GC_CA;
    public GameObject M_r1_C_CC_GC_P_CA;
    public GameObject M_r1_C_CC_P_CA;
    public GameObject M_r1_C_GC_CA;
    public GameObject M_r1_C_GC_P_CA;
    public GameObject M_r1_C_P_CA;
    public GameObject M_r1_GC_CA;
    public GameObject M_r1_GC_P_CA;
    public GameObject M_r1_P_CA;
    public GameObject M_r1_r2_CA;
    public GameObject M_r1_r2_C_CA;
    public GameObject M_r1_r2_C_CC_CA;
    public GameObject M_r1_r2_C_CC_GC_CA;
    public GameObject M_r1_r2_C_CC_GC_P_CA;
    public GameObject M_r1_r2_C_CC_P_CA;
    public GameObject M_r1_r2_C_GC_CA;
    public GameObject M_r1_r2_GC_P_CA;
    public GameObject M_r1_r2_P_CA;
    public GameObject M_r2_CA;
    public GameObject M_r2_C_CA;
    public GameObject M_r2_C_CC_CA;
    public GameObject M_r2_C_CC_GC_CA;
    public GameObject M_r2_C_CC_GC_P_CA;
    public GameObject M_r2_C_CC_P_CA;
    public GameObject M_r2_C_GC_CA;
    public GameObject M_r2_C_GC_P_CA;
    public GameObject M_r2_C_P_CA;
    public GameObject M_r2_GC_CA;
    public GameObject M_r2_GC_P_CA;
    public GameObject M_r2_P_CA;
    public GameObject P_CA;
    public GameObject M_r1_r2_C_CC;
    public GameObject M_r1_r2_C_GC_P_CA;
    public GameObject M_r1_r2_C_P_CA;
    public GameObject M_r1_r2_GC_CA;
    public GameObject M_GC_P_CA;
    public GameObject M_C_P_CA;


    // 이미지 타겟
    public GameObject M_image;
    public GameObject r1_image;
    public GameObject r2_image;
    public GameObject CPU_image;
    public GameObject CC_image;
    public GameObject GC_image;
    public GameObject P_image;
    public GameObject CA_image;

    // 이미지 타겟 ObserverBehaviour
    private ObserverBehaviour M_Observer; 
    private ObserverBehaviour r1_Observer;
    private ObserverBehaviour r2_Observer;
    private ObserverBehaviour C_Observer;
    private ObserverBehaviour CC_Observer;
    private ObserverBehaviour GC_Observer;
    private ObserverBehaviour P_Observer;
    private ObserverBehaviour CA_Observser;

    // 이미지 타겟 발견 여부
    private bool M_Found = false;
    private bool r1_Found = false;
    private bool r2_Found = false;
    private bool C_Found = false;
    private bool CC_Found = false;
    private bool GC_Found = false;
    private bool P_Found = false;
    private bool CA_Found = false;

    public List<bool> But_Obj = new List<bool>(); // 버튼 누름 확인 부울 리스트

    // 조립 버튼
    //public List<Button> OnBut = new List<Button>();

    // 분해 버튼
    //public List<Button> OffBut = new List<Button>();
    
    public Button r1_onButton; // RAM_1과 메인보드 조립하는 버튼
    public Button r2_onButton; // RAM_2과 메인보드 조립하는 버튼
    public Button C_onButton; // CPU와 메인보드 조립하는 버튼
    public Button CC_onButton; // CPU_Cooler와 메인보드 조립하는 버튼
    public Button GC_onButton; // Graphics_card와 메인보드 조립하는 버튼
    public Button P_onButton; // Power와 케이스 조립하는 버튼
    public Button CA_onButton; // CASE와 메인보드 조립하는 버튼
    
    public Button r1_offButton;
    public Button r2_offButton;
    public Button C_offButton;
    public Button CC_offButton;
    public Button GC_offButton; 
    public Button P_offButton;
    public Button CA_offButton;

    private Transform parentTransform;
    private Transform parentTransformc;

    public TextMeshProUGUI able;

    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            But_Obj.Add(false); // 초기 부울 비활성화
        }

        // 초기 상태에서 버튼을 비활성화
        /*
        for (int i = 0; i < OnBut.Count; i++)
        {
            int index = i;
            OnBut[i].onClick.AddListener(() => ToggleObjectState(index));
            OnBut[i].interactable = false;
            OffBut[i].onClick.AddListener(() => ToggleObjectState(index));
            OffBut[i].interactable = false;
        }
        */

        UpdataText("조합 가능 부품 : 메인보드, Ram1, Ram2, CPU, CPU_Cooler, Graphics_Card, Power, CASE");

        r1.SetActive(true);
        r2.SetActive(true);
        C.SetActive(true);
        CC.SetActive(true);
        GC.SetActive(true);
        P.SetActive(true);
        CA.SetActive(true);
        M.SetActive(true);
        
        parentTransform = transform.Find("M_all");
        parentTransformc = transform.Find("CASE_all");

        r1_onButton.gameObject.SetActive(false); 
        r2_onButton.gameObject.SetActive(false);
        C_onButton.gameObject.SetActive(false);
        CC_onButton.gameObject.SetActive(false);
        GC_onButton.gameObject.SetActive(false);
        P_onButton.gameObject.SetActive(false);
        CA_onButton.gameObject.SetActive(false);

        r1_offButton.gameObject.SetActive(false); 
        r2_offButton.gameObject.SetActive(false);
        C_offButton.gameObject.SetActive(false);
        CC_offButton.gameObject.SetActive(false);
        GC_offButton.gameObject.SetActive(false);
        P_offButton.gameObject.SetActive(false);
        CA_offButton.gameObject.SetActive(false);
        

        // 이미지 타겟의 컴포넌트 가져오기
        M_Observer = M_image.GetComponent<ObserverBehaviour>();
        r1_Observer = r1_image.GetComponent<ObserverBehaviour>();
        r2_Observer = r2_image.GetComponent<ObserverBehaviour>();
        C_Observer = CPU_image.GetComponent<ObserverBehaviour>();
        CC_Observer = CC_image.GetComponent<ObserverBehaviour>();
        GC_Observer = GC_image.GetComponent<ObserverBehaviour>();
        P_Observer = P_image.GetComponent<ObserverBehaviour>();
        CA_Observser = CA_image.GetComponent<ObserverBehaviour>();

        // 이미지 타겟의 이벤트에 대한 핸들러 등록
        M_Observer.OnTargetStatusChanged += OnMTargetStatusChanged;
        r1_Observer.OnTargetStatusChanged += Onr1TargetStatusChanged;
        r2_Observer.OnTargetStatusChanged += Onr2TargetStatusChanged;
        C_Observer.OnTargetStatusChanged += OnCTargetStatusChanged;
        CC_Observer.OnTargetStatusChanged += OnCCTargetStatusChanged;
        GC_Observer.OnTargetStatusChanged += OnGCTargetStatusChanged;
        P_Observer.OnTargetStatusChanged += OnPTargetStatusChanged;
        CA_Observser.OnTargetStatusChanged += OnCATargetStatusChanged;

        // 버튼 클릭 시 동작 설정
        r1_onButton.onClick.AddListener(r1_onClick);
        r2_onButton.onClick.AddListener(r2_onClick);
        C_onButton.onClick.AddListener(C_onClick);
        CC_onButton.onClick.AddListener(CC_onClick);
        GC_onButton.onClick.AddListener(GC_onClick);
        P_onButton.onClick.AddListener(P_onClick);
        CA_onButton.onClick.AddListener(CA_onClick);

        // 버튼 클릭 시 동작 설정
        r1_offButton.onClick.AddListener(r1_offClick);
        r2_offButton.onClick.AddListener(r2_offClick);
        C_offButton.onClick.AddListener(C_offClick);
        CC_offButton.onClick.AddListener(CC_offClick);
        GC_offButton.onClick.AddListener(GC_offClick);
        P_offButton.onClick.AddListener(P_offClick);
        CA_offButton.onClick.AddListener(CA_offClick);
    }

    // M 이미지 타겟 상태 변경 이벤트 핸들러
    private void OnMTargetStatusChanged(ObserverBehaviour observerBehaviour, TargetStatus status)
    {
        bool newMFound = (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL);

        if (newMFound != M_Found)
        {
            Debug.Log("M");
            M_Found = newMFound;
            CheckAndPerformAction();
        }
        
    }

    // R1 이미지 타겟 상태 변경 이벤트 핸들러
    private void Onr1TargetStatusChanged(ObserverBehaviour observerBehaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            Debug.Log("ram");
            r1_Found = true;
            CheckAndPerformAction();
        }
        else
        {
            r1_Found = false;
            CheckAndPerformAction();
            //But_Obj[0] = false;
        }
    }

    // r2 이미지 타겟 상태 변경 이벤트 핸들러
    private void Onr2TargetStatusChanged(ObserverBehaviour observerBehaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            r2_Found = true;
            CheckAndPerformAction();
        }
        else
        {
            r2_Found = false;
            CheckAndPerformAction();
            //But_Obj[1] = false;
        }
    }

    // C 이미지 타겟 상태 변경 이벤트 핸들러
    private void OnCTargetStatusChanged(ObserverBehaviour observerBehaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            C_Found = true;
            CheckAndPerformAction();
        }
        else
        {
            C_Found = false;
            CheckAndPerformAction();
            //But_Obj[2] = false;
        }
    }

    // CC 이미지 타겟 상태 변경 이벤트 핸들러
    private void OnCCTargetStatusChanged(ObserverBehaviour observerBehaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            CC_Found = true;
            CheckAndPerformAction();
        }
        else
        {
            CC_Found = false;
            CheckAndPerformAction();
            //But_Obj[3] = false;
        }
    }
    
    // GC 이미지 타겟 상태 변경 이벤트 핸들러
    private void OnGCTargetStatusChanged(ObserverBehaviour observerBehaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            GC_Found = true;
            CheckAndPerformAction();
        }
        else
        {
            GC_Found = false;
            CheckAndPerformAction();
            //But_Obj[4] = false;
        }
    }

    // P 이미지 타겟 상태 변경 이벤트 핸들러
    private void OnPTargetStatusChanged(ObserverBehaviour observerBehaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            P_Found = true;
            CheckAndPerformAction();
        }
        else
        {
            P_Found = false;
            CheckAndPerformAction();
            //But_Obj[5] = false;
        }
    }

    // CA 이미지 타겟 상태 변경 이벤트 핸들러
    private void OnCATargetStatusChanged(ObserverBehaviour observerBehaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            CA_Found = true;
            CheckAndPerformAction();
        }
        else
        {
            CA_Found = false;
            CheckAndPerformAction();
            //But_Obj[6] = false;
        }
    }

    // 두 이미지 타겟을 모두 발견한 경우 동작을 수행하는 함수
    private void CheckAndPerformAction()
    {
        if (M_Found && r1_Found && !But_Obj[0])
        {
            Debug.Log("버튼 활성화");
            //OnBut[0].interactable = true;
            r1_onButton.gameObject.SetActive(true);
            r1_offButton.gameObject.SetActive(false);
        }
        else if (M_Found && r1_Found && But_Obj[0])
        {
            r1_onButton.gameObject.SetActive(false);
            r1_offButton.gameObject.SetActive(true);
        }
        else
        {
           r1_onButton.gameObject.SetActive(false);
           r1_offButton.gameObject.SetActive(false);
        }

        if (M_Found && r2_Found && !But_Obj[1])
        {
            r1_offButton.gameObject.SetActive(false);
            r2_onButton.gameObject.SetActive(true);
        }
        else if (M_Found && r2_Found && But_Obj[1])
        {
            r2_offButton.gameObject.SetActive(true);
            r2_onButton.gameObject.SetActive(false);
        }
        else
        {
            r2_offButton.gameObject.SetActive(false);
            r2_onButton.gameObject.SetActive(false);
        }

        if (M_Found && C_Found && !But_Obj[2])
        {
            C_offButton.gameObject.SetActive(false);
            C_onButton.gameObject.SetActive(true);
        }
        else if (M_Found && C_Found && But_Obj[2])
        {
            C_offButton.gameObject.SetActive(true);
            C_onButton.gameObject.SetActive(false);
        }
        else
        {
            C_offButton.gameObject.SetActive(false);
            C_onButton.gameObject.SetActive(false);
        }

        if (M_Found && CC_Found && !But_Obj[3])
        {
            CC_offButton.gameObject.SetActive(false);
            CC_onButton.gameObject.SetActive(true);
        }
        else if (M_Found && CC_Found && But_Obj[3])
        {
            CC_offButton.gameObject.SetActive(true);
            CC_onButton.gameObject.SetActive(false);
        }
        else
        {
            CC_offButton.gameObject.SetActive(false);
            CC_onButton.gameObject.SetActive(false);
        }

        if (M_Found && GC_Found && !But_Obj[4])
        {
            GC_offButton.gameObject.SetActive(false);
            GC_onButton.gameObject.SetActive(true);
            //OnBut[4].interactable = true;
        }
        else if (M_Found && GC_Found && But_Obj[4])
        {
            GC_offButton.gameObject.SetActive(true);
            GC_onButton.gameObject.SetActive(false);
        }
        else
        {
            GC_offButton.gameObject.SetActive(false);
            GC_onButton.gameObject.SetActive(false);
        }

        if (M_Found && CA_Found && !But_Obj[6])
        {
            CA_offButton.gameObject.SetActive(false);
            CA_onButton.gameObject.SetActive(true);
            //OnBut[5].interactable = true;
        }
        else if (M_Found && CA_Found && But_Obj[6])
        {
            CA_onButton.gameObject.SetActive(true);
            CA_offButton.gameObject.SetActive(true);
        }
        else
        {
            CA_offButton.gameObject.SetActive(false);
            CA_onButton.gameObject.SetActive(false);
        }

        if (CA_Found && P_Found && !But_Obj[5])
        {
            P_offButton.gameObject.SetActive(false);
            P_onButton.gameObject.SetActive(true);
            //OnBut[6].interactable = true;
        }
        else if (CA_Found && P_Found && But_Obj[5])
        {
            P_offButton.gameObject.SetActive(true);
            P_onButton.gameObject.SetActive(false);
        }
        else
        {
            P_onButton.gameObject.SetActive(false);
            P_offButton.gameObject.SetActive(false);
        }

        
    }

    void Update()
    {
        /*if (!But_Obj[0] && !But_Obj[1] && !But_Obj[2] && !But_Obj[3] && !But_Obj[4] && !But_Obj[5] && !But_Obj[6])
        {
            Debug.Log("GI");
            foreach (Transform child in M_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            M.SetActive(true);
            r1.SetActive(true);
            r2.SetActive(true);
            C.SetActive(true);
            CC.SetActive(true);
            GC.SetActive(true);
            P.SetActive(true);
            CA.SetActive(true);
        }*/
        if (But_Obj[0])
        {
            foreach (Transform child in M_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            //M_all.SetActive(false);
            r1.SetActive(false);
            r2.SetActive(true);
            C.SetActive(true);
            CC.SetActive(true);
            GC.SetActive(true);
            P.SetActive(true);
            CA.SetActive(true);
            M_r1.SetActive(true);
            UpdataText("조합 가능 부품 : Ram2, CPU, CPU_Cooler, Graphics_Card, Power, CASE");
            /*if (But_Obj[5])
            {
                foreach (Transform child in CASE_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                P.SetActive(false);
                CA.SetActive(false);
                P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : 메인보드, Ram1, Ram2, CPU, CPU_Cooler, Graphics_Card");
            }*/
            if (But_Obj[0] && But_Obj[1])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_r2.SetActive(true);
                UpdataText("조합 가능 부품 : CPU, CPU_Cooler, Graphics_Card, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[2])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_C.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU_Cooler, Graphics_Card, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_GC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU, CPU_Cooler, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU, CPU_Cooler, Graphics_Card, Power");
            }

            if (But_Obj[0] && But_Obj[2] && But_Obj[3])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }  
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_C_CC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, Graphics_Card, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                C.SetActive(false);
                r2.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_r2_C.SetActive(true);
                UpdataText("조합 가능 부품 : CPU_Cooler, Graphics_Card, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_r2_GC.SetActive(true);
                UpdataText("조합 가능 부품 : CPU, CPU_Cooler, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_r2_CA.SetActive(true);
                UpdataText("조합 가능 부품 : CPU, CPU_Cooler, Graphics_Card, Power");
            }
            if (But_Obj[0] && But_Obj[2] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_C_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU_Cooler, Graphics_Card, Power");
            }
            if (But_Obj[0] && But_Obj[2] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);           
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_C_GC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU_Cooler, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU, CPU_Cooler, Power");
            }
            if (But_Obj[0] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU, CPU_Cooler, Graphics_Card");
            }
            if (But_Obj[0] && But_Obj[2] && But_Obj[3] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_C_CC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, Graphics_Card, Power");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_r2_C_CA.SetActive(true);
                UpdataText("조합 가능 부품 : CPU_Cooler, Graphics_Card, Power");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[3])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_r2_C_CC.SetActive(true);
                UpdataText("조합 가능 부품 : Graphics_Card, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[2] && But_Obj[3] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_C_CC_GC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[2] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);       
                GC.SetActive(false);
                P.SetActive(true);           
                CA.SetActive(false);
                M_r1_C_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU_Cooler, Power");
            }
            if (But_Obj[0] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU, CPU_Cooler");
            }
            if (But_Obj[0] && But_Obj[2] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_C_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU_Cooler, Graphics_Card");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_r2_C_GC.SetActive(true);
                UpdataText("조합 가능 부품 : CPU_Cooler, Power, CASE");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_r2_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : CPU, CPU_Cooler, Power");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_r2_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : CPU, CPU_Cooler, Graphics_Card");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_r2_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : CPU, CPU_Cooler");
            }
            if (But_Obj[0] && But_Obj[2] && But_Obj[3] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_C_CC_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, Power");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_r2_C_CC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Graphics_Card, Power");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_r1_r2_C_CC_GC.SetActive(true);
                UpdataText("조합 가능 부품 : Power, CASE");
            }
            if (But_Obj[0] && But_Obj[2] && But_Obj[3] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_C_CC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : 메인보드, Ram1, CPU, CPU_Cooler, Power, CASE");
            }
            
            if (But_Obj[0] && But_Obj[2] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_C_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2, CPU_Cooler");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_r2_C_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : CPU_Cooler, Graphics_Card");
            }
            if (But_Obj[0] && But_Obj[2] && But_Obj[3] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_C_CC_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram2");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_r1_r2_C_CC_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Power");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_r2_C_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : CPU_Cooler");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_r2_C_CC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Graphics_Card");
            }
            if (But_Obj[0] && But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(false);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_r1_r2_C_CC_GC_P_CA.SetActive(true);
                UpdataText("조합 가능한 부품이 더 이상 없습니다!");
            }
        }
        else if (But_Obj[1])
        {
            foreach (Transform child in M_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            r1.SetActive(true);
            r2.SetActive(false);
            C.SetActive(true);
            CC.SetActive(true);
            GC.SetActive(true);
            P.SetActive(true);
            CA.SetActive(true);
            M_r2.SetActive(true);
            UpdataText("조합 가능 부품 : Ram1, CPU, CPU_Cooler, Graphics_Card, Power, CASE");
            if (But_Obj[1] && But_Obj[2])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(true);
                M_r2_C.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU_Cooler, Graphics_Card, Power, CASE");
            }
            if (But_Obj[1] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_r2_GC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU, CPU_Cooler, Power, CASE");
            }
             if (But_Obj[1] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_r2_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU, CPU_Cooler, Graphics_Card, Power");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[3])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(true);
                M_r2_C_CC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Graphics_Card, Power, CASE");
            }
             if (But_Obj[1] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_r2_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU, CPU_Cooler, Power");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_r2_C_GC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU_Cooler, Power, CASE");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_r2_C_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU_Cooler, Graphics_Card, Power");
            }
            if (But_Obj[1] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_r2_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU, CPU_Cooler, Graphics_Card");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_r2_C_CC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Graphics_Card, Power");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_r2_C_CC_GC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Power, CASE");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_r2_C_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU_Cooler, Power");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_r2_C_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU_Cooler, Graphics_Card");
            }
            if (But_Obj[1] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_r2_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU, CPU_Cooler");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_r2_C_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, CPU_Cooler");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_r2_C_CC_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Power");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_r2_C_CC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Graphics_Card");
            }
            if (But_Obj[1] && But_Obj[2] && But_Obj[3] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(false);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_r2_C_CC_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1");
            }
        }
        else if (But_Obj[2])
        {
            foreach (Transform child in M_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            r1.SetActive(true);
            r2.SetActive(true);
            C.SetActive(false);
            CC.SetActive(true);
            GC.SetActive(true);
            P.SetActive(true);
            CA.SetActive(true);
            M_C.SetActive(true);
            UpdataText("조합 가능 부품 : Ram1, Ram2, CPU_Cooler, Graphics_Card, Power, CASE");
            if (But_Obj[2] && But_Obj[3])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(true);
                M_C_CC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, Graphics_Card, Power, CASE");
            }
            if (But_Obj[2] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_C_GC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, CPU_Cooler, Power, CASE");
            }
            if (But_Obj[2] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_C_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, CPU_Cooler, Graphics_Card, Power");
            }
            if (But_Obj[2] && But_Obj[3] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }   
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(true);
                CA.SetActive(false);
                M_C_CC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, Graphics_Card, Power");
            }
            if (But_Obj[2] && But_Obj[3] && But_Obj[4])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(true);
                M_C_CC_GC.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, Power, CASE");
            }
            if (But_Obj[2] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_C_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, CPU_Cooler, Power");
            }
            if (But_Obj[2] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_C_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, Graphics_Card");
            }
            if (But_Obj[2] && But_Obj[3] && But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_C_CC_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, Power");
            }
            if (But_Obj[2] && But_Obj[3] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_C_CC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, Graphics_Card");
            }
            if (But_Obj[2] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_C_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, CPU_Cooler");
            }
            if (But_Obj[2] && But_Obj[3] && But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(false);
                CC.SetActive(false);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_C_CC_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2");
            }
        }
        else if (But_Obj[4])
        {
            foreach (Transform child in M_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            foreach (Transform child in CASE_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            r1.SetActive(true);
            r2.SetActive(true);
            C.SetActive(true);
            CC.SetActive(true);
            GC.SetActive(false);
            P.SetActive(true);
            CA.SetActive(true);
            M_GC.SetActive(true);
            UpdataText("조합 가능 부품 : Ram1, Ram2, CPU, CPU_Cooler, Power, CASE");
            if (But_Obj[4] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                foreach (Transform child in CASE_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(true);
                CA.SetActive(false);
                M_GC_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, CPU, CPU_Cooler, Power");
            }
            if (But_Obj[4] && But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                foreach (Transform child in CASE_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(false);
                P.SetActive(false);
                CA.SetActive(false);
                M_GC_P_CA.SetActive(true);
                UpdataText("조합 가능 부품 : Ram1, Ram2, CPU, CPU_Cooler");
            }
        }
        else if (But_Obj[5])
        {
            foreach (Transform child in CASE_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            foreach (Transform child in M_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            r1.SetActive(true);
            r2.SetActive(true);
            C.SetActive(true);
            CC.SetActive(true);
            GC.SetActive(true);
            M.SetActive(true);
            P.SetActive(false);
            CA.SetActive(false);
            P_CA.SetActive(true);
            UpdataText("조합 가능 부품 : 메인보드, Ram1, Ram2, CPU, CPU_Cooler, Graphics_Card");
            if (But_Obj[5] && But_Obj[6])
            {
                foreach (Transform child in CASE_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                foreach (Transform child in M_all.transform)
                {
                    child.gameObject.SetActive(false);
                }
                r1.SetActive(true);
                r2.SetActive(true);
                C.SetActive(true);
                CC.SetActive(true);
                GC.SetActive(true);
                P.SetActive(false);
                CA.SetActive(false);
                M_P_CA.SetActive(true);
            }
        }
        else if (But_Obj[6])
        {
            foreach (Transform child in M_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            foreach (Transform child in CASE_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            r1.SetActive(true);
            r2.SetActive(true);
            C.SetActive(true);
            CC.SetActive(true);
            GC.SetActive(true);
            P.SetActive(true);
            CA.SetActive(false);
            M_CA.SetActive(true);
            UpdataText("조합 가능 부품 : Ram1, Ram2, CPU, CPU_Cooler, Graphics_Card, Power");
        }
        else //if(!M.activeSelf && !But_Obj[0] && !But_Obj[1] && !But_Obj[2] && !But_Obj[3] && !But_Obj[4] && !But_Obj[5] && !But_Obj[6])
        {
            foreach (Transform child in M_all.transform)
            {
                child.gameObject.SetActive(false);
            }
            r1.SetActive(true);
            r2.SetActive(true);
            C.SetActive(true);
            CC.SetActive(true);
            GC.SetActive(true);
            P.SetActive(true);
            CA.SetActive(true);
            M.SetActive(true);
            UpdataText("조합 가능 부품 : 메인보드, Ram1, Ram2, CPU, CPU_Cooler, Graphics_Card, Power, CASE");
        }
    }

    // 버튼을 클릭할 때 호출되는 함수
    private void r1_onClick()
    {
        But_Obj[0] = !But_Obj[0];
        r1_offButton.gameObject.SetActive(true);
        r1_onButton.gameObject.SetActive(false);
    }

    private void r2_onClick()
    {
        But_Obj[1] = !But_Obj[1];
        r2_offButton.gameObject.SetActive(true);
        r2_onButton.gameObject.SetActive(false);
    }

    private void C_onClick()
    {
        But_Obj[2] = !But_Obj[2];
        C_offButton.gameObject.SetActive(true);
        C_onButton.gameObject.SetActive(false);
    }

    private void CC_onClick()
    {
        But_Obj[3] = !But_Obj[3];
        CC_offButton.gameObject.SetActive(true);
        CC_onButton.gameObject.SetActive(false);
    }

    private void GC_onClick()
    {
        But_Obj[4] = !But_Obj[4];
        GC_offButton.gameObject.SetActive(true);
        GC_onButton.gameObject.SetActive(false);
    }

    private void P_onClick()
    {
        But_Obj[5] = !But_Obj[5];
        P_offButton.gameObject.SetActive(true);
        P_onButton.gameObject.SetActive(false);
    }

    private void CA_onClick()
    {
        But_Obj[6] = !But_Obj[6];
        CA_offButton.gameObject.SetActive(true);
        CA_onButton.gameObject.SetActive(false);
    }

    // 버튼을 클릭할 때 호출되는 함수
    private void r1_offClick()
    {
        But_Obj[0] = !But_Obj[0];
        r1_offButton.gameObject.SetActive(false);
        r1_onButton.gameObject.SetActive(true);
    }

    private void r2_offClick()
    {
        But_Obj[1] = !But_Obj[1];
        r2_onButton.gameObject.SetActive(true);
        r2_offButton.gameObject.SetActive(false);
    }

    private void C_offClick()
    {
        But_Obj[2] = !But_Obj[2];
        C_onButton.gameObject.SetActive(true);
        C_offButton.gameObject.SetActive(false);
    }

    private void CC_offClick()
    {
        But_Obj[3] = !But_Obj[3];
        CC_onButton.gameObject.SetActive(true);
        CC_offButton.gameObject.SetActive(false);
    }

    private void GC_offClick()
    {
        But_Obj[4] = !But_Obj[4];
        GC_onButton.gameObject.SetActive(true);
        GC_offButton.gameObject.SetActive(false);
    }

    private void P_offClick()
    {
        But_Obj[5] = !But_Obj[5];
        P_onButton.gameObject.SetActive(true);
        P_offButton.gameObject.SetActive(false);
    }

    private void CA_offClick()
    {
        But_Obj[6] = !But_Obj[6];
        CA_onButton.gameObject.SetActive(true);
        CA_offButton.gameObject.SetActive(false);
    }

    private void UpdataText(string newText)
    {
        if (able != null)
        {
            able.text = newText;
        }
    }
}
