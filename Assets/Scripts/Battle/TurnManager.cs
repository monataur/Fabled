using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Enums.BattleEntity currentCharacter;
    public GameObject partyObj;
    public int skillPoints;

    public AudioClip battleMus;
    public AudioClip startMus;
    public AudioSource musSource;

    public int partyCount;
    public int enemyCount;
    public bool isInBattle = false;

    public GameObject enemy1obj;
    public GameObject enemy2obj;
    public GameObject enemy3obj;
    public GameObject enemy4obj;
    public GameObject party1obj;
    public GameObject party2obj;
    public GameObject party3obj;
    public GameObject party4obj;
    public GameObject musicObj;


    public Vector2[] oneEnemyPos = new Vector2[2];
    public Vector2[] twoEnemyPos = new Vector2[3];
    public Vector2[] threeEnemyPos = new Vector2[4];
    public Vector2[] fourEnemyPos = new Vector2[5];
    public Vector2[] onePartyPos = new Vector2[2];
    public Vector2[] twoPartyPos = new Vector2[3];
    public Vector2[] threePartyPos = new Vector2[4];
    public Vector2[] fourPartyPos = new Vector2[5];

    public PartyMember iceCreamOhNoSadAndScaredWowie;
    public Vector2 track;
    public GameObject partyobj;

    public Enums.BattleEntity partyTurn;
    public Image battleUi;
    public PartyMember currentParty;

    bool start = false;

    public MapEnemy mapEnemy;

    void StartEnemyTurn()
    {
        Debug.LogError("StartEnemyTurn() doesn't work yet you fucking burger");
    }

    public void ProgressPartyTurn()
    {
        switch (partyTurn)
        {
            case Enums.BattleEntity.PartyMember1:
                partyTurn = Enums.BattleEntity.PartyMember2;
                break;

            case Enums.BattleEntity.PartyMember2:
                partyTurn = Enums.BattleEntity.PartyMember3;
                break;

            case Enums.BattleEntity.PartyMember3:
                partyTurn = Enums.BattleEntity.PartyMember4;
                break;

            case Enums.BattleEntity.PartyMember4:
                partyTurn = Enums.BattleEntity.PartyMember1;
                StartEnemyTurn();
                break;
        }
    }

    public void StartBattle(MapEnemy enemy)
    {
        if(isInBattle == false)
        {
            mapEnemy = enemy;

            var p1anim = party1obj.GetComponent<Animator>();
            var p2anim = party2obj.GetComponent<Animator>();
            var p3anim = party3obj.GetComponent<Animator>();
            var p4anim = party4obj.GetComponent<Animator>();

            //musicObj.GetComponent<MusicObject>().PlayMusic(battleMus);

            SetDefaultBattlePositions();
            enemyCount = enemy.enemyCount;
            partyCount = partyObj.GetComponent<Party>().count;
            isInBattle = true;
            partyobj.GetComponent<Party>().status = Enums.PartyStatus.Battle;
            p1anim.Play("Battle");
            p1anim.StopPlayback();
            p2anim.Play("Battle");
            p2anim.StopPlayback();


            switch (enemyCount)
            {
                case 1:
                    enemy1obj.GetComponent<EnemyObject>().enemy = enemy.enemy1;
                    //enemy1obj.transform.position = oneEnemyPos[0]; THIS COULD BE USEFUL LATER IDK LOL | it isnt
                    break;

                case 2:
                    enemy1obj.GetComponent<EnemyObject>().enemy = enemy.enemy1;
                    enemy2obj.GetComponent<EnemyObject>().enemy = enemy.enemy2;
                    break;
                case 3:
                    enemy1obj.GetComponent<EnemyObject>().enemy = enemy.enemy1;
                    enemy2obj.GetComponent<EnemyObject>().enemy = enemy.enemy2;
                    enemy3obj.GetComponent<EnemyObject>().enemy = enemy.enemy3;
                    break;

                case 4:
                    enemy1obj.GetComponent<EnemyObject>().enemy = enemy.enemy1;
                    enemy2obj.GetComponent<EnemyObject>().enemy = enemy.enemy2;
                    enemy3obj.GetComponent<EnemyObject>().enemy = enemy.enemy3;
                    enemy4obj.GetComponent<EnemyObject>().enemy = enemy.enemy4;
                    break;
            }
        }
    }

    private void Start()
    {
        SetDefaultBattlePositions();
    }

    private void Update()
    {
        track = partyObj.GetComponent<Party>().track;
        var lerpSpeed = 1.5f;

        if (isInBattle == true)
        {
            if (musSource.isPlaying == false)
            {
                switch (mapEnemy.track.usesStart)
                {
                    case true:
                        switch (start)
                        {
                            case false:
                                musSource.clip = mapEnemy.track.start;
                                musSource.Play();
                                start = true;
                                Debug.Log(start);
                                break;

                            case true:
                                musSource.clip = mapEnemy.track.loop;
                                musSource.Play();
                                break;
                        }
                        break;

                    case false:
                        musSource.clip = mapEnemy.track.loop;
                        musSource.Play();
                        break;
                }
            }

            switch (partyTurn)
            {
                case Enums.BattleEntity.PartyMember1:
                    currentParty = party1obj.GetComponent<PartyMemberObject>().partyMember;
                    break;

                case Enums.BattleEntity.PartyMember2:
                    currentParty = party2obj.GetComponent<PartyMemberObject>().partyMember;
                    break;

                case Enums.BattleEntity.PartyMember3:
                    currentParty = party3obj.GetComponent<PartyMemberObject>().partyMember;
                    break;

                case Enums.BattleEntity.PartyMember4:
                    currentParty = party4obj.GetComponent<PartyMemberObject>().partyMember;
                    break;
            }

            battleUi.color = currentParty.menu;

            switch (enemyCount)
            {
                case 1:
                    enemy1obj.transform.position = Vector2.Lerp(enemy1obj.transform.position, oneEnemyPos[0], lerpSpeed * Time.deltaTime);
                    break;

                case 2:
                    enemy1obj.transform.position = Vector2.Lerp(enemy1obj.transform.position, twoEnemyPos[0], lerpSpeed * Time.deltaTime);
                    enemy2obj.transform.position = Vector2.Lerp(enemy2obj.transform.position, twoEnemyPos[1], lerpSpeed * Time.deltaTime);
                    break;

                case 3:
                    enemy1obj.transform.position = Vector2.Lerp(enemy1obj.transform.position, threeEnemyPos[0], lerpSpeed * Time.deltaTime);
                    enemy2obj.transform.position = Vector2.Lerp(enemy2obj.transform.position, threeEnemyPos[1], lerpSpeed * Time.deltaTime);
                    enemy3obj.transform.position = Vector2.Lerp(enemy3obj.transform.position, threeEnemyPos[2], lerpSpeed * Time.deltaTime);
                    break;

                case 4:
                    enemy1obj.transform.position = Vector2.Lerp(enemy1obj.transform.position, fourEnemyPos[0], lerpSpeed * Time.deltaTime);
                    enemy2obj.transform.position = Vector2.Lerp(enemy2obj.transform.position, fourEnemyPos[1], lerpSpeed * Time.deltaTime);
                    enemy3obj.transform.position = Vector2.Lerp(enemy3obj.transform.position, fourEnemyPos[2], lerpSpeed * Time.deltaTime);
                    enemy4obj.transform.position = Vector2.Lerp(enemy4obj.transform.position, fourEnemyPos[3], lerpSpeed * Time.deltaTime);
                    break;
            }

            switch (partyCount)
            {
                case 1:
                    party1obj.transform.position = Vector2.Lerp(party1obj.transform.position, onePartyPos[0], lerpSpeed * Time.deltaTime);
                    break;

                case 2:
                    party1obj.transform.position = Vector2.Lerp(party1obj.transform.position, twoPartyPos[0], lerpSpeed * Time.deltaTime);
                    party2obj.transform.position = Vector2.Lerp(party2obj.transform.position, twoPartyPos[1], lerpSpeed * Time.deltaTime);
                    break;

                case 3:
                    party1obj.transform.position = Vector2.Lerp(party1obj.transform.position, threePartyPos[0], lerpSpeed * Time.deltaTime);
                    party2obj.transform.position = Vector2.Lerp(party2obj.transform.position, threePartyPos[1], lerpSpeed * Time.deltaTime);
                    party3obj.transform.position = Vector2.Lerp(party3obj.transform.position, threePartyPos[2], lerpSpeed * Time.deltaTime);
                    break;

                case 4:
                    enemy1obj.transform.position = Vector2.Lerp(enemy1obj.transform.position, fourEnemyPos[0], lerpSpeed * Time.deltaTime);
                    enemy2obj.transform.position = Vector2.Lerp(enemy2obj.transform.position, fourEnemyPos[1], lerpSpeed * Time.deltaTime);
                    enemy3obj.transform.position = Vector2.Lerp(enemy3obj.transform.position, fourEnemyPos[2], lerpSpeed * Time.deltaTime);
                    enemy4obj.transform.position = Vector2.Lerp(enemy4obj.transform.position, fourEnemyPos[3], lerpSpeed * Time.deltaTime);
                    break;
            }
            var v2 = new Vector2(3, 3);
            switch (partyCount)
            {
                
                case 1:
                    party1obj.transform.position = Vector2.Lerp(party1obj.transform.position, v2, Time.deltaTime);
                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;
            }
        }
    }

    void SetDefaultBattlePositions()
    {
        oneEnemyPos[0] = new Vector2(party1obj.transform.position.x + 1.75f, track.y + -0.30f);
        twoEnemyPos[0] = new Vector2(party1obj.transform.position.x + 1.75f, track.y + -0.25f);
        twoEnemyPos[1] = new Vector2(party2obj.transform.position.x + 1.75f, track.y + -0.55f);
        threeEnemyPos[0] = new Vector2(party1obj.transform.position.x + 1.75f, track.y + -0.05f);
        threeEnemyPos[1] = new Vector2(party1obj.transform.position.x + 1.75f, track.y + -0.4f);
        threeEnemyPos[2] = new Vector2(party1obj.transform.position.x + 1.75f, track.y + -0.75f);
        fourEnemyPos[0] = new Vector2(party1obj.transform.position.x + 1.75f, party1obj.transform.position.y + 0.05f);
        fourEnemyPos[1] = new Vector2(party1obj.transform.position.x + 1.75f, party1obj.transform.position.y + -0.25f);
        fourEnemyPos[2] = new Vector2(party1obj.transform.position.x + 1.75f, party1obj.transform.position.y + -0.55f);
        fourEnemyPos[3] = new Vector2(party1obj.transform.position.x + 1.75f, party1obj.transform.position.y + -0.85f);
        onePartyPos[0] = new Vector2(party1obj.transform.position.x, party1obj.transform.position.y + -0.35f);
        twoPartyPos[0] = new Vector2(party1obj.transform.position.x, party1obj.transform.position.y + -0.25f);
        twoPartyPos[1] = new Vector2(party1obj.transform.position.x, party1obj.transform.position.y + -0.55f);
        threePartyPos[0] = new Vector2(party1obj.transform.position.x, party1obj.transform.position.y + -0.05f);
        threePartyPos[1] = new Vector2(party1obj.transform.position.x, party1obj.transform.position.y + -0.35f);
    }

    public float CamYOffset()
    {
        switch (enemyCount)
        {
            case 1:
                return 0.0f;

            case 2:
                return -0.3f;

            case 3:
                return -0.4f;

            case 4:
                return -0.3f;

            default:
                return 0.0f;
        }
    }

    Color ReturnPartyColor()
    {
        switch (currentCharacter)
        {
            case Enums.BattleEntity.PartyMember1:
                return partyObj.GetComponent<Party>().party1.color;

            case Enums.BattleEntity.PartyMember2:
                return partyObj.GetComponent<Party>().party2.color;

            case Enums.BattleEntity.PartyMember3:
                return partyObj.GetComponent<Party>().party3.color;

            case Enums.BattleEntity.PartyMember4:
                return partyObj.GetComponent<Party>().party3.color;

            default:
                return Color.white;
        }
    }

    void ModifySkillPoints(int point)
    {
        skillPoints += point;
    }
}
