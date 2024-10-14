using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using System.Linq;
// using UnityEditor.Experimental.GraphView;

public class GameState : MonoBehaviour
{
    public GameObject hpUP;
    public GameObject atkUP;
    public GameObject defUP;
    public GameObject spdUP;
    public GameObject knifeRange, featherRange;
    public GameObject[] knifeObject;
    public GameObject[] boneObject;
    public GameObject[] featherObject;
    public GameObject[] pocketObject;
    public GameObject[] skateboardObject;
    public GameObject secondFeatherActivation;
    public UnityEvent pauseEvent;
    public UnityEvent resumeEvent;
    public UnityEvent settingEvent;
    public UnityEvent deadEvent;
    public bool paused;
    public bool settings;
    public bool leveling;
    public bool gameover;
    public bool hpOn, atkOn, defOn, spdOn, knifeOn, boneOn, featherOn, pocketOn, skateboardOn;
    public int knifeBuffCount = 0, boneBuffCount = 0, featherBuffCount = 0, pocketBuffCount = 0, skateboardBuffCount = 0;
    public AudioMixer audioMixer;
    public PlayerStatus playerStatus;
    public PlayerControl playerControl;
    public EnemyChefM enemyChefM;
    private int slot;
    void Start()
    {
        audioMixer.SetFloat("BGM", PlayerPrefs.GetFloat("BGM"));
        audioMixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover && !paused && !leveling && Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
            pauseEvent?.Invoke();
            Time.timeScale = 0f;
        }
        else if (settings == true && Input.GetKeyDown(KeyCode.Escape))
        {
            settings = false;
            settingEvent?.Invoke();
        }
        else if (paused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            paused = false;
            resumeEvent?.Invoke();
            Time.timeScale = 1f;
        }
    }
    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
    }
    public void SettingsEnter()
    {
        settings = true;
    }
    public void SettingExit()
    {
        settings = false;
    }
    public void ExitOrRetry()
    {
        Time.timeScale = 1f;
    }
    public void LevelUp()
    {
        leveling = true;
        slot = 0;
        while (slot < 4)
        {
            switch (Random.Range(1, 10))
            {
                case 1:
                    if (!hpOn)
                    {
                        hpUP.SetActive(true);
                        hpOn = true;
                        slot++;
                    }
                    break;
                case 2:
                    if (!atkOn)
                    {
                        atkUP.SetActive(true);
                        atkOn = true;
                        slot++;
                    }
                    break;
                case 3:
                    if (!defOn)
                    {
                        defUP.SetActive(true);
                        defOn = true;
                        slot++;
                    }
                    break;
                case 4:
                    if (!spdOn)
                    {
                        spdUP.SetActive(true);
                        spdOn = true;
                        slot++;
                    }
                    break;
                case 5:
                    if (!knifeOn)
                    {
                        if (knifeBuffCount == 0)
                        {
                            knifeObject[0].SetActive(true);
                        }
                        else if (knifeBuffCount == 1)
                        {
                            knifeObject[1].SetActive(true);
                        }
                        else if (knifeBuffCount == 2)
                        {
                            knifeObject[2].SetActive(true);
                        }
                        else if (knifeBuffCount == 3)
                        {
                            knifeObject[3].SetActive(true);
                        }
                        else if (knifeBuffCount == 4)
                        {
                            knifeObject[4].SetActive(true);
                        }
                        else
                        {
                            slot--;
                        }
                        knifeOn = true;
                        slot++;
                    }
                    break;
                case 6:
                    if (!boneOn)
                    {
                        if (boneBuffCount == 0)
                        {
                            boneObject[0].SetActive(true);
                        }
                        else if (boneBuffCount == 1)
                        {
                            boneObject[1].SetActive(true);
                        }
                        else if (boneBuffCount == 2)
                        {
                            boneObject[2].SetActive(true);
                        }
                        else if (boneBuffCount == 3)
                        {
                            boneObject[3].SetActive(true);
                        }
                        else
                        {
                            slot--;
                        }
                        boneOn = true;
                        slot++;
                    }
                    break;
                case 7:
                    if (!featherOn)
                    {
                        if (featherBuffCount == 0)
                        {
                            featherObject[0].SetActive(true);
                        }
                        else if (featherBuffCount == 1)
                        {
                            featherObject[1].SetActive(true);
                        }
                        else if (featherBuffCount == 2)
                        {
                            featherObject[2].SetActive(true);
                        }
                        else if (featherBuffCount == 3)
                        {
                            featherObject[3].SetActive(true);
                        }
                        else
                        {
                            slot--;
                        }
                        featherOn = true;
                        slot++;
                    }
                    break;
                case 8:
                    if (!pocketOn)
                    {
                        if (pocketBuffCount == 0)
                        {
                            pocketObject[0].SetActive(true);
                        }
                        else if (pocketBuffCount == 1)
                        {
                            pocketObject[1].SetActive(true);
                        }
                        else if (pocketBuffCount == 2)
                        {
                            pocketObject[2].SetActive(true);
                        }
                        else
                        {
                            slot--;
                        }
                        pocketOn = true;
                        slot++;
                    }
                    break;
                case 9:
                    if (!skateboardOn)
                    {
                        if (skateboardBuffCount == 0)
                        {
                            skateboardObject[0].SetActive(true);
                        }
                        else if (skateboardBuffCount == 1)
                        {
                            skateboardObject[1].SetActive(true);
                        }
                        else
                        {
                            slot--;
                        }
                        skateboardOn = true;
                        slot++;
                    }
                    break;
            }
        }
        Time.timeScale = 0f;
    }
    public void LevelUpExit()
    {
        leveling = false;
        hpOn = false;
        atkOn = false;
        defOn = false;
        spdOn = false;
        knifeOn = false;
        boneOn = false;
        featherOn = false;
        pocketOn = false;
        skateboardOn = false;
        hpUP.SetActive(false);
        atkUP.SetActive(false);
        defUP.SetActive(false);
        spdUP.SetActive(false);
        foreach (GameObject knifeobj in knifeObject)
        {
            knifeobj.SetActive(false);
        }
        foreach (GameObject boneobj in boneObject)
        {
            boneobj.SetActive(false);
        }
        foreach (GameObject featherobj in featherObject)
        {
            featherobj.SetActive(false);
        }
        foreach (GameObject pocketobj in pocketObject)
        {
            pocketobj.SetActive(false);
        }
        foreach (GameObject skateboardobj in skateboardObject)
        {
            skateboardobj.SetActive(false);
        }
        Time.timeScale = 1f;
    }
    public void HpUp()
    {
        playerStatus.maxHp += 10;
        playerStatus.hp += 10;
    }
    public void AtkUp()
    {
        playerStatus.atk += 3;
    }
    public void DefUp()
    {
        playerStatus.def += 2;
    }
    public void SpdUp()
    {
        playerStatus.spd += 0.5f;
    }
    public void HasteUp()
    {
        playerStatus.haste -= playerStatus.haste / 10;
    }
    public void KnifeUpgrade()
    {
        if (knifeBuffCount == 0)
        {
            knifeBuffCount++;
        }
        else if (knifeBuffCount == 1)
        {
            // upgrade knife stk speed
            playerControl.knifeUpgrade = 2;
            knifeBuffCount++;
            playerControl.Invoke("KnifeGet", 0);
        }
        else if (knifeBuffCount == 2)
        {
            // upgrade knife dmg
            enemyChefM.addKnifeDmg = 5;
            knifeBuffCount++;
        }
        else if (knifeBuffCount == 3)
        {
            // add more knife
            playerControl.doubleknife = true;
            knifeBuffCount++;
            playerControl.Invoke("KnifeGet", 0);
        }
        else if (knifeBuffCount == 4)
        {
            // upgrade knife atk size
            Vector3 knifeSize = new Vector3(0.7f, 0.7f, 0.7f);
            knifeRange.transform.localScale = knifeSize;
            knifeBuffCount++;
        }
    }
    public void BoneUpgrade()
    {
        if (boneBuffCount == 0)
        {
            boneBuffCount++;
        }
        if (boneBuffCount == 1)
        {
            // upgrade bone throw speed
            playerControl.boneUpgrade = 2;
            boneBuffCount++;
            playerControl.Invoke("BoneGet", 0);
        }
        else if (boneBuffCount == 2)
        {
            // add more bone
            playerControl.doubleBone = true;
            boneBuffCount++;
            playerControl.Invoke("BoneGet", 0);
        }
        else if (boneBuffCount == 3)
        {
            // upgrade bone radius
            GameObject bone = GameObject.Find("Bone Radius");
            Vector3 boneRadius = new Vector3(2, 2, 2);
            bone.transform.localScale = boneRadius;
            boneBuffCount++;
        }
    }
    public void FeatherUpgrade()
    {
        if (featherBuffCount == 0)
        {
            // upgrade feather stk speed
            playerControl.featherUpgrade = 1;
            featherBuffCount++;
            playerControl.Invoke("RestartInvokeUseAttack", 0f);
        }
        else if (featherBuffCount == 1)
        {
            // upgrade feather dmg
            enemyChefM.addFeatherDmg = 7;
            featherBuffCount++;
        }
        else if (featherBuffCount == 2)
        {
            // add more feather
            secondFeatherActivation.SetActive(true);
            featherBuffCount++;
        }
        else if (featherBuffCount == 3)
        {
            // upgrade feather atk size
            Vector3 featherSize = new Vector3(2, 2, 2);
            featherRange.transform.localScale = featherSize;
            featherBuffCount++;
        }
    }
    public void PocketUpgrade()
    {
        if (pocketBuffCount == 0)
        {
            // aktifin pocket get di PlayerControl lewat button
            playerControl.pocketRegenValue = 2;
            pocketBuffCount++;
        }
        else if (pocketBuffCount == 1)
        {
            // upgrade increase HP regen
            playerControl.pocketRegenValue = 3;
            pocketBuffCount++;
        }
        else if (pocketBuffCount == 2)
        {
            // aktifin pocket get di PlayerControl lewat button
            // decrease interval time regen
            playerControl.pocketUpgrade = 1;
            pocketBuffCount++;
        }
    }
    public void SkateboardUpgrade()
    {
        if (skateboardBuffCount == 0)
        {
            // upgrade feather stk speed
            playerStatus.countDownOn = true;
            playerStatus.skateboardMultiplier = 0.2f;
            skateboardBuffCount++;
        }
        else if (skateboardBuffCount == 1)
        {
            // upgrade feather dmg
            playerStatus.skateboardMultiplier = 0.5f;
            skateboardBuffCount++;
        }
    }
    public void GameOverEnter()
    {
        gameover = true;
        StartCoroutine(GameOverDelay());
    }
    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1f);
        deadEvent?.Invoke();
        Time.timeScale = 0f;
    }

}
