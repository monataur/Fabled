using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum Platform {PC, Xbox, Switch, Playstation, Android, iOS}
    public enum Element {Physical, Fire, Water, Earth, Wind, Nature, Metal, Dark, Light, Ace, Status, Rune, RuneResist, RuneWeak, None}
    public enum SkillType {Standard, Function}
    public enum DamageType {Magical, Physical}
    public enum DamageSeverity {Light, Medium, Heavy, Extreme, Mortal, Ultimate, Dynamic}
    public enum BattleEntity {PartyMember1,PartyMember2,PartyMember3,PartyMember4,Enemy1,Enemy2,Enemy3,Enemy4}
    public enum PartyStatus {Map, Battle, Cutscene}
    public enum Locale {Home, MidnightForest, Glintsboro, MarshCadaverine, Bleachrock, StoneBarrens, NewIcarusCity, OldIcarus, MirrorZone}
    public enum CharacterType { Player, NPC }
    public enum MoveDirection {Up,Down,Left,Right,None}
    public enum EquipType {Pen, Rune, Tome, DualBlade, PDA, Unknown}
    public enum EnemyType {NormalEncounter, MiniBoss, Boss,}
}
