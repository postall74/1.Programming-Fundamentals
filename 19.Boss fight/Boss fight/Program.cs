using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss_fight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            // Переменные с минимальными и максимальными стартовыми значениями характеристик Героя
            int minimalPlayerHealth = 75;
            int maximalPlayerHealth = 100;
            int minimalPlayerDamage = 8;
            int maximalPlayerDamage = 15;
            int minimalPlayerArrmor = 80;
            int maximalPlayerArrmor = 100;
            int minimalPlayerMana = 50;
            int maximalPlayerMana = 75;
            // Переменные с минимальными и максимальными стартовыми значениями характеристик Злодея
            int minimalBossHealth = 100;
            int maximalBossHealth = 150;
            int minimalBossDamage = 5;
            int maximalBossDamage = 25;
            int minimalBossArrmor = 50;
            int maximallBossArrmor = 95;
            // Заполненные рандомом значения характеристик Героя
            float playerHealth = random.Next(minimalPlayerHealth, maximalPlayerHealth);
            float playerHealtStart = playerHealth; // Переменная для записи стартового значения кол-ва здоровья героя
            int playerDamage = random.Next(minimalPlayerDamage, maximalPlayerDamage);
            int playerArrmor = 100 - random.Next(minimalPlayerArrmor, maximalPlayerArrmor);
            int playerMana = random.Next(minimalPlayerMana, maximalPlayerMana);
            int playerManaStart = playerMana; // Переменная для записи стартового значения кол-ва маны героя
            //Заполненные рандомом значения характеристик Злодея
            float bossHealth = random.Next(minimalBossHealth, maximalBossHealth);
            int bossDamage = random.Next(minimalBossDamage, maximalBossDamage);
            int bossArrmor = 100 - random.Next(minimalBossArrmor, maximallBossArrmor);
            //Переменные получения урона героем и злодем
            float damageTekenPlayer;
            float damageTekenBoss;
            //Переменные для проверок использования заклинаний "невидимость" и "востановление"
            bool wasInvisibilityUsed = false;
            bool wasRehabilitationUsed = false;
            //Постоянные значения
            const int oneHundredPercent = 100;
            const int twentyPercent = 20;
            const int doubleDamage = 2;
            const int tripleDamage = 3;
            const int halfArrmor = 2;
            Console.WriteLine("Нажмите Enter для начала боя!");
            Console.ReadKey();

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 21);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Показатели нашего героя:\n" +
                                  "Здоровье - " + playerHealth + "\n" +
                                  "Мана - " + playerMana + "\n" +
                                  "Броня - " + playerArrmor + "\n" +
                                  "Удар кулаком - " + playerDamage);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Показатели Злого Властелина:\n" +
                                  "Здоровье - " + bossHealth + "\n" +
                                  "Броня - " + bossArrmor + "\n" +
                                  "Удар оружием - " + bossDamage);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\n0 - Punch\n\n1 - Fireball\n\n2- Ice Cube\n\n3 - Arrmagedon\n\n4 - Invisible\n\n5 - Rehabilitation");
                Console.WriteLine("Выберите заклинание:");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0:
                        damageTekenPlayer = Convert.ToSingle(random.Next(0, bossDamage)) / oneHundredPercent * random.Next(0, playerArrmor);
                        playerHealth -= damageTekenPlayer;
                        damageTekenBoss = Convert.ToSingle(random.Next(0, playerDamage)) / oneHundredPercent * random.Next(0, bossArrmor);
                        bossHealth -= damageTekenBoss;

                        if (damageTekenPlayer > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nГерой получил ранение - " + damageTekenPlayer + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nНаш герой ловко увернулся от атаки злодея!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (damageTekenBoss > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Злой Властелин получил ранение - " + damageTekenBoss + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Наш герой промахнулся!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        wasInvisibilityUsed = false;
                        Console.ReadKey();
                        break;
                    case 1:
                        int manaPerFireball = 7;

                        if (playerMana >= manaPerFireball)
                        {
                            damageTekenBoss = Convert.ToSingle(random.Next(0, (playerDamage * doubleDamage))) / oneHundredPercent * random.Next(0, bossArrmor);
                            bossHealth -= damageTekenBoss;
                            playerMana -= manaPerFireball;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("У героя не хватает маны для этого заклинания!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            break;
                        }
                        damageTekenPlayer = Convert.ToSingle(random.Next(0, bossDamage)) / oneHundredPercent * random.Next(0, playerArrmor);
                        playerHealth -= damageTekenPlayer;

                        if (damageTekenPlayer > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nГерой получил ранение - " + damageTekenPlayer + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nНаш герой ловко увернулся от атаки злодея!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (damageTekenBoss > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Злой Властелин получил ранение - " + damageTekenBoss + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Наш герой промахнулся!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        wasInvisibilityUsed = false;
                        Console.ReadKey();
                        break;
                    case 2:
                        int manaPerIcecube = 11;

                        if (playerMana >= manaPerIcecube)
                        {
                            damageTekenBoss = Convert.ToSingle(random.Next(0, (playerDamage * doubleDamage)));
                            bossHealth -= damageTekenBoss;
                            playerMana -= manaPerIcecube;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("У героя не хватает маны для этого заклинания!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            break;
                        }
                        damageTekenPlayer = Convert.ToSingle(random.Next(0, bossDamage)) / oneHundredPercent * random.Next(0, playerArrmor);
                        playerHealth -= damageTekenPlayer;

                        if (damageTekenPlayer > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nГерой получил ранение - " + damageTekenPlayer + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nНаш герой ловко увернулся от атаки злодея!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (damageTekenBoss > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Злой Властелин получил ранение - " + damageTekenBoss + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Наш герой промахнулся!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        wasInvisibilityUsed = false;
                        Console.ReadKey();
                        break;
                    case 3:
                        int manaPerArmagedon = 30;
                        float extraDamageTakenPlayer;

                        if (playerMana >= manaPerArmagedon)
                        {
                            damageTekenBoss = Convert.ToSingle(random.Next(0, (playerDamage * tripleDamage))) / oneHundredPercent * random.Next(0, bossArrmor / halfArrmor);
                            bossHealth -= damageTekenBoss;
                            playerMana -= manaPerArmagedon;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("У героя не хватает маны для этого заклинания!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            break;
                        }
                        damageTekenPlayer = Convert.ToSingle(random.Next(0, bossDamage)) / oneHundredPercent * random.Next(0, playerArrmor);
                        playerHealth -= damageTekenPlayer;

                        if (damageTekenPlayer > 0)
                        {
                            extraDamageTakenPlayer = damageTekenBoss / oneHundredPercent * twentyPercent;
                            playerHealth -= extraDamageTakenPlayer;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nГерой получил ранение - " + damageTekenPlayer + ", герой не смог увернуться от своего заклинания и получил дополнительный урон - " + extraDamageTakenPlayer + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nНаш герой ловко увернулся от атаки злодея!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        if (damageTekenBoss > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Злой Властелин получил ранение - " + damageTekenBoss + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Наш герой промахнулся!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        wasInvisibilityUsed = false;
                        Console.ReadKey();
                        break;
                    case 4:
                        int manaPerInvisible = 5;
                        bool howDidSpell;

                        if (playerMana >= manaPerInvisible)
                        {
                            howDidSpell = Convert.ToBoolean(random.Next(0, 2));

                            if (howDidSpell == true && wasInvisibilityUsed == false)
                            {
                                wasInvisibilityUsed = true;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Герой ушел в тень от атаки злодея.\n");
                                Console.ForegroundColor = ConsoleColor.White;
                                damageTekenBoss = Convert.ToSingle(random.Next(0, playerDamage)) / oneHundredPercent * random.Next(0, bossArrmor);
                                bossHealth -= damageTekenBoss;
                                playerMana -= manaPerInvisible;

                                if (damageTekenBoss > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nЗлой Властелин получил ранение - " + damageTekenBoss + "\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("\nНаш герой промахнулся!\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else if (howDidSpell == false && wasInvisibilityUsed == false)
                            {
                                wasInvisibilityUsed = true;
                                Console.ForegroundColor = ConsoleColor.Red;
                                damageTekenPlayer = Convert.ToSingle(random.Next(1, bossDamage)) / oneHundredPercent * random.Next(0, playerArrmor);
                                playerHealth -= damageTekenPlayer;
                                playerMana -= manaPerInvisible;
                                Console.WriteLine("\nЗаклинание провалилось и герой получил урон от злодея - " + damageTekenPlayer + " не нанеся удара.\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (wasInvisibilityUsed == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nЗаклинание нельзя использовать дважы подряд!\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nУ героя не хватает маны для этого заклинания!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            break;
                        }
                        wasInvisibilityUsed = true;
                        Console.ReadKey();
                        break;
                    case 5:
                        int manaPerRehabilitation = playerManaStart;

                        if (playerMana >= manaPerRehabilitation && wasRehabilitationUsed == false)
                        {
                            if (playerHealth == playerHealtStart)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nЗдоровье героя в полном порядке!\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (wasRehabilitationUsed == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nСвитки с заклинанием востановления закончились!\n");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.WriteLine("\nЗаклинание востановило здоровье герою - " + (playerHealtStart - playerHealth) + "\n");
                                playerHealth = playerHealtStart;
                                playerMana -= playerManaStart;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nУ героя не хватает маны для этого заклинания!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            break;
                        }
                        damageTekenPlayer = Convert.ToSingle(random.Next(0, bossDamage)) / oneHundredPercent * random.Next(0, playerArrmor);
                        playerHealth -= damageTekenPlayer;

                        if (damageTekenPlayer > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nГерой получил ранение - " + damageTekenPlayer + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nНаш герой ловко увернулся от атаки злодея!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        wasInvisibilityUsed = false;
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        break;
                }

                if (playerMana != playerManaStart)
                {
                    playerMana += 1;
                }
            }
            Console.Clear();

            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("В этом бою наш герой пал, но победил Злого Властелина!");
            }
            else if (playerHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Наш герой пал от рук Злого Властелина!");
            }
            else if (bossHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Злой Властелин повержен! И наш герой с победой вернулся в родные края!");
            }
            Console.ReadKey();
        }
    }
}
