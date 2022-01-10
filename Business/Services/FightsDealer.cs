using System.Text;
using Business.Controllers;
using Business.Models;

namespace Business.Services;

public static class FightsDealer
{

    public static string Fight(Character player, Character monster)
    {
        var stringBuilder = new StringBuilder();
        while (true)
        {
            for (var i = 0; i < player.AttackPerRound; i++)
            {
                var randomsum = 0;
                var randomAC = Random.Shared.Next(20) + 1;
                for (var j = 0; j < player.Damage; j++)
                {
                    var random = Random.Shared.Next(player.DiceType) + 1;
                    randomsum += random;
                }

                if (monster.AC <= randomAC + player.Weapon + player.AttackModifier)
                {
                    monster.HitPoints -= randomsum + player.Weapon + player.DamageModifier;
                    if (monster.HitPoints <= 0)
                    {
                        stringBuilder.Append($"{player.Name} won\n");
                        return stringBuilder.ToString();
                    }
                }
            }

            for (var i = 0; i < monster.AttackPerRound; i++)
            {
                var randomsum = 0;
                var randomAC = Random.Shared.Next(20) + 1;
                for (var j = 0; j < monster.Damage; j++)
                {
                    var random = Random.Shared.Next(monster.DiceType) + 1;
                    randomsum += random;
                }

                if (player.AC <= randomAC + monster.Weapon + monster.AttackModifier)
                {
                    player.HitPoints -= randomsum + monster.Weapon + monster.DamageModifier;
                    if (player.HitPoints <= 0)
                    {
                        stringBuilder.Append($"{monster.Name} won");
                        return stringBuilder.ToString();
                    }
                }

            }
        }
    }
}
