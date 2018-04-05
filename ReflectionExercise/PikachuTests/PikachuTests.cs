using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionExercise;

namespace ReflctionTests
{
    [TestClass]
    public class PikachuTests
    {
        [TestMethod]
        public void CanReflectPikachu()
        {
            int pikachuLevel = 4;
            int newPikachuLevel = 5;
            string[] pikachuAttacks = new string[] { "Thunder Shock", "Tail Whip", "Growl" };
            string[] newPikachuAttacks = new string[] { "Thunder Shock", "Tail Whip", "Growl", "Quick Attack" };

            var pikachu = Activator.CreateInstance(typeof(Pikachu), pikachuLevel, pikachuAttacks) as Pikachu;
            var pikachuProperties = typeof(Pikachu).GetProperties();
            var levelUpMethod = pikachu.GetType().GetMethod("LevelUp");

            Assert.AreNotEqual(pikachuProperties.Length, 0);

            typeof(Pikachu).GetProperty("Attacks").SetValue(pikachu, newPikachuAttacks);
            typeof(Pikachu).GetProperty("Level").SetValue(pikachu, newPikachuLevel);

            foreach (var property in pikachuProperties)
            {
                var value = property.GetValue(pikachu);
                
                switch (property.Name)
                {
                    case "Attacks":
                        Assert.AreEqual(value, newPikachuAttacks);
                        break;
                    case "Level":
                        Assert.AreEqual(value, newPikachuLevel);
                        Assert.AreEqual(levelUpMethod.Invoke(pikachu, null), newPikachuLevel + 1);
                        break;
                    default:
                        Assert.Fail();
                        break;
                }
            }
            
        }
    }
}
