﻿namespace Combat;

public interface IEntity
{
    public string Name { get; set; }
    public CombatHandler CombatHandler { get; set; }
}