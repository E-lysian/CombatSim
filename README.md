<br />
<div align="center">
  <h3 align="center">RuneScape 05 Combat Simulator</h3>

  <p align="center">
    A CLI project made to simulate the RuneScape combat system
    <br />
    <a href="https://oldschoolrunescape.fandom.com/wiki/Combat"><strong>OldSchool RuneScape Combat »</strong></a>
  </p>
</div>


<!-- ABOUT THE PROJECT -->
## About The Project

The project was started becase I was interested in learning how to create a combat system that works like the one RuneScape has implemented.<br/>
It's currently based on my vague understanding of it.

Here's why:
* If done correctly, it should serve as a template for other projects which might need to implement something similar.
* Should demonstrate basic SRP.
* It should also demonstrate the DRY principle.

Of course, this project is not by any means flawless and could benefit from some more encapsulation but in good time this shall be worked on as well.


<!-- GETTING STARTED -->
## Getting Started

How to get this running locally.
### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/E-lysian/CombatSim
   ```
2. Build
   ```sh
   dotnet build
   ```
3. Change Directory (if not already in the project directory)
   ```sh
   cd Combat
   ```

4. Run
    ```sh
    dotnet run
    ```

<br/>

Following these steps successfully should print this out
```cs
Tick..
Tick..
Tick..
Elysian attacking Goblin
Goblin attacking Elysian
Tick..
Tick..
Tick..
Tick..
Elysian attacking Goblin
Goblin attacking Elysian
Tick..
Tick..
Tick..
Tick..
Elysian attacking Goblin
Goblin attacking Elysian
Elysian won over Goblin. Remaining health: 0
Elysian Resetting combat.. 
Goblin won over Elysian. Remaining health: 0
Goblin Resetting combat..
...
```


<!-- USAGE EXAMPLES -->
## Usage

### Adding more NPCs
Adding more NPCs can be done through the [NPCLoader](https://github.com/E-lysian/CombatSim/blob/master/Combat/Loaders/NPCLoader.cs).<br/>
The same goes for Players.

```cs
public class NPCLoader
{
    public static List<IEntity> Npcs { get; set; } = new();

    public static void Load()
    {
        /* Just add more NPCs here */
        Npcs.Add(new NPC());
    }
}
```

<br/>

### Change Weapon Attack Speed
Changing the weapon attack speed can be done in order to simulate using a faster attacking weapon.<br/>
The speed is set in ticks, and one tick is 600ms.<br/>
The attack speed is changed inside the instance of the entity because that's where the `Weapon` property resides.

#### Example
If a weapon has the attack speed of `4`, then the amount of time it takes to perform an attack is `(4 * 0.6)` which is `2.4s`

```cs
/* Here the attack speed is set to 4 ticks */
public Weapon Weapon { get; set; } = new(0, 0, 4, new CombatAnimations(0, 0, 0), WeaponType.HAND);

/* Here the attack speed is set to 8 ticks */
public Weapon Weapon { get; set; } = new(0, 0, 8, new CombatAnimations(0, 0, 0), WeaponType.HAND);
```

<br/>

### Modify the combat formula
In order to modify the <a href="https://oldschoolrunescape.fandom.com/wiki/Maximum_melee_hit"><strong>Combat Formula</strong></a>, based on the combat style (Melee, Mage or Range), you want to head over to [MeleeCombat](https://github.com/E-lysian/CombatSim/blob/master/Combat/Combat/Methods/Melee/MeleeCombat.cs)<br/> which best demonstrates how this can be achieved.<br/>
As of right now the damage you inflict with melee is set to a constant value of `5`. <br/>This does not accurately demonstrate how an entity inflicts damage to another entity.


```cs
public CombatHit CalculateDamage()
{
    /* Combat formula etc */
    return new CombatHit
    {
        Damage = 5,
        Delay = 0,
        Type = 1
    };
}
```
<br/>


There are different types of damage in RuneScape which can be demonstrated by the [DamageType](https://github.com/E-lysian/CombatSim/blob/master/Combat/Combat/DamageType.cs) enum.

```cs
public enum DamageType
{
    Block,
    Damage,
    Poison,
    Desease,
    DeseaseAlternative
}
```




<!-- ROADMAP -->
## Roadmap

- [x] Implement a foundation to work with
- [x] Use SRP & DRY
- [ ] Implement the other combat methods (Range, Mage)


<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

Use this space to list resources you find helpful and would like to give credit to. I've included a few of my favorites to kick things off!

* [OldSchool RuneScape](https://oldschool.runescape.com/)
* [OSRS Wiki](https://oldschool.runescape.wiki/)


<p align="right">(<a href="#readme-top">back to top</a>)</p>
