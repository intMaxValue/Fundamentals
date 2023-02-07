using System;
using System.Collections.Generic;

namespace HeroesOfCodeAndLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var heroes = new Dictionary<string, Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] startingHeroes = Console.ReadLine().Split(' ');

                string heroName = startingHeroes[0];
                
                int hp = int.Parse(startingHeroes[1]);
               
                int mp = int.Parse(startingHeroes[2]);

                heroes[heroName] = new Hero(hp, mp);
            }

            string input;
            
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmnd = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                
                string action = cmnd[0];
               
                string name = cmnd[1];

                switch (action)
                {
                    case "CastSpell":
                        CastSpell(heroes, name, int.Parse(cmnd[2]), cmnd[3]);
                        break;
                    case "TakeDamage":
                        TakeDamage(heroes, name, int.Parse(cmnd[2]), cmnd[3]);
                        break;
                    case "Recharge":
                        Recharge(heroes, name, int.Parse(cmnd[2]));
                        break;
                    case "Heal":
                        Heal(heroes, name, int.Parse(cmnd[2]));
                        break;
                }
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }

        private static void Heal(Dictionary<string, Hero> heroes, string name, int hp)
        {
            if (heroes[name].HP + hp > 100)
            {
                int recovered = 100 - heroes[name].HP;
                heroes[name].HP = 100;

                Console.WriteLine($"{name} healed for {recovered} HP!");
            }

            else
            {
                heroes[name].HP += hp;
                Console.WriteLine($"{name} healed for {hp} HP!");
            }
        }

        private static void Recharge(Dictionary<string, Hero> heroes, string name, int mp)
        {
            if (heroes[name].MP + mp > 200)
            {
                int recharged = 200 - heroes[name].MP;
                heroes[name].MP = 200;

                Console.WriteLine($"{name} recharged for {recharged} MP!");
            }

            else
            {
                heroes[name].MP += mp;
                Console.WriteLine($"{name} recharged for {mp} MP!");
            }
        }
        static void TakeDamage(Dictionary<string, Hero> heroes, string name, int damage, string attacker)
        {
            if (heroes[name].HP - damage > 0)
            {
                heroes[name].HP -= damage;

                Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HP} HP left!");
            }

            else
            {
                Console.WriteLine($"{name} has been killed by {attacker}!");

                heroes.Remove(name);
            }


        }

        static void CastSpell(Dictionary<string, Hero> heroes, string name, int mpNeeded, string spellName)
        {
            if (heroes[name].MP >= mpNeeded)
            {
                heroes[name].MP -= mpNeeded;

                Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name].MP} MP!");
            }

            else
            {
                Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
            }
        }
        class Hero
        {
            public Hero(int hP, int mP)
            {
                HP = hP;
                MP = mP;
            }

            public int HP { get; set; }
            public int MP { get; set; }
        }
    }
}