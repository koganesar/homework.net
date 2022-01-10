using Business.Models;

namespace Business.Services;

public static class CharacterCalculator
{
    public static CalculatedCharacter Calculate(Character character) =>
        new CalculatedCharacter
        {
            Name = character.Name,
            HitPoints = character.HitPoints,
            AttackModifier = character.AttackModifier,
            AttackPerRound = character.AttackPerRound,
            Damage = character.Damage,
            DiceType = character.DiceType,
            DamageModifier = character.DamageModifier,
            Weapon = character.Weapon,
            AC = character.AC,
            MinAcToAlwaysHit = character.AttackModifier + character.Weapon + 1,
            DamagePerRoundLeft = (character.Damage + character.Weapon + character.DamageModifier) *
                                 character.AttackPerRound,
            DamagePerRoundRight = (character.DiceType + character.Weapon + character.DamageModifier) *
                                  character.AttackPerRound
        };
}
