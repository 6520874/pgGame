/****************************************************
    文件：PlayerCtrlWnd.cs
	作者：Plane
    邮箱: 1785275942@qq.com
    日期：2019/3/19 5:39:47
	功能：玩家控制界面
*****************************************************/

using PEProtocol;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerCtrlWnd : WindowRoot {
    public Image imgTouch;
    public Image imgDirBg;
    public Image imgDirPoint;
    public Text txtLevel;
    public Text txtName;
    public Text txtExpPrg;
    public Transform expPrgTrans;

    private float pointDis;
    private Vector2 startPos = Vector2.zero;
    private Vector2 defaultPos = Vector2.zero;

    public Vector2 currentDir;

    #region Skill
    #region SK1
    public Image imgSk1CD;
    public Text txtSk1CD;
    private bool isSk1CD = false;
    private float sk1CDTime;
    private int sk1Num;
    private float sk1FillCount = 0;
    private float sk1NumCount = 0;
    #endregion

    #region SK2
    public Image imgSk2CD;
    public Text txtSk2CD;
    private bool isSk2CD = false;
    private float sk2CDTime;
    private int sk2Num;
    private float sk2FillCount = 0;
    private float sk2NumCount = 0;
    #endregion

    #region SK3
    public Image imgSk3CD;
    public Text txtSk3CD;
    private bool isSk3CD = false;
    private float sk3CDTime;
    private int sk3Num;
    private float sk3FillCount = 0;
    private float sk3NumCount = 0;
    #endregion
    #endregion

    public Text txtSelfHP;
    public Image imgSelfHP;

    private int HPSum;

    protected override void InitWnd() {
        base.InitWnd();

        pointDis = Screen.height * 1.0f / Constants.ScreenStandardHeight * Constants.ScreenOPDis;
        defaultPos = imgDirBg.transform.position;
        SetActive(imgDirPoint, false);

        HPSum = GameRoot.Instance.PlayerData.hp;
        SetText(txtSelfHP, HPSum + "/" + HPSum);
        imgSelfHP.fillAmount = 1;

        // SetBossHPBarState(false);
        // RegisterTouchEvts();
        // sk1CDTime = resSvc.GetSkillCfg(101).cdTime / 1000.0f;
        // sk2CDTime = resSvc.GetSkillCfg(102).cdTime / 1000.0f;
        // sk3CDTime = resSvc.GetSkillCfg(103).cdTime / 1000.0f;

        RefreshUI();
    }
    public void RefreshUI() {
        PlayerData pd = GameRoot.Instance.PlayerData;

        SetText(txtLevel, pd.lv);
        SetText(txtName, pd.name);

        #region Expprg
        int expPrgVal = (int)(pd.exp * 1.0f / PECommon.GetExpUpValByLv(pd.lv) * 100);
        SetText(txtExpPrg, expPrgVal + "%");
        int index = expPrgVal / 10;

        GridLayoutGroup grid = expPrgTrans.GetComponent<GridLayoutGroup>();

        float globalRate = 1.0F * Constants.ScreenStandardHeight / Screen.height;
        float screenWidth = Screen.width * globalRate;
        float width = (screenWidth - 180) / 10;

        grid.cellSize = new Vector2(width, 7);

        for (int i = 0; i < expPrgTrans.childCount; i++) {
            Image img = expPrgTrans.GetChild(i).GetComponent<Image>();
            if (i < index) {
                img.fillAmount = 1;
            }
            else if (i == index) {
                img.fillAmount = expPrgVal % 10 * 1.0f / 10;
            }
            else {
                img.fillAmount = 0;
            }
        }
        #endregion    
    }

    // private void Update() {
    //     //TEST
    //     if (Input.GetKeyDown(KeyCode.A)) {
    //         ClickNormalAtk();
    //     }
    //     if (Input.GetKeyDown(KeyCode.Alpha1)) {
    //         ClickSkill1Atk();
    //     }
    //     if (Input.GetKeyDown(KeyCode.Alpha2)) {
    //         ClickSkill2Atk();
    //     }
    //     if (Input.GetKeyDown(KeyCode.Alpha3)) {
    //         ClickSkill3Atk();
    //     }

    //     float delta = Time.deltaTime;
    //     #region Skill CD
    //     if (isSk1CD) {
    //         sk1FillCount += delta;
    //         if (sk1FillCount >= sk1CDTime) {
    //             isSk1CD = false;
    //             SetActive(imgSk1CD, false);
    //             sk1FillCount = 0;
    //         }
    //         else {
    //             imgSk1CD.fillAmount = 1 - sk1FillCount / sk1CDTime;
    //         }

    //         sk1NumCount += delta;
    //         if (sk1NumCount >= 1) {
    //             sk1NumCount -= 1;
    //             sk1Num -= 1;
    //             SetText(txtSk1CD, sk1Num);
    //         }
    //     }

    //     if (isSk2CD) {
    //         sk2FillCount += delta;
    //         if (sk2FillCount >= sk2CDTime) {
    //             isSk2CD = false;
    //             SetActive(imgSk2CD, false);
    //             sk2FillCount = 0;
    //         }
    //         else {
    //             imgSk2CD.fillAmount = 1 - sk2FillCount / sk2CDTime;
    //         }

    //         sk2NumCount += delta;
    //         if (sk2NumCount >= 1) {
    //             sk2NumCount -= 1;
    //             sk2Num -= 1;
    //             SetText(txtSk2CD, sk2Num);
    //         }
    //     }

    //     if (isSk3CD) {
    //         sk3FillCount += delta;
    //         if (sk3FillCount >= sk3CDTime) {
    //             isSk3CD = false;
    //             SetActive(imgSk3CD, false);
    //             sk3FillCount = 0;
    //         }
    //         else {
    //             imgSk3CD.fillAmount = 1 - sk3FillCount / sk3CDTime;
    //         }

    //         sk3NumCount += delta;
    //         if (sk3NumCount >= 1) {
    //             sk3NumCount -= 1;
    //             sk3Num -= 1;
    //             SetText(txtSk3CD, sk3Num);
    //         }
    //     }
    //     #endregion

    //     if (transBossHPBar.gameObject.activeSelf) {
    //         BlendBossHP();
    //         imgYellow.fillAmount = currentPrg;
    //     }
    // }


}