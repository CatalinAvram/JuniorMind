﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Un ciclometru e un mecanism simplu care numără rotațiile unei roți de bicicletă.
În urma unei curse ai datele înregistrate de ciclometrele bicicliștilor participanți.
Ciclometrul fiecărui participant a înregistrat numărul de rotații făcute în fiecare secundă.
Dacă cunoști pentru fiecare bicicletă diametrul roților:
    Calculează distanța totală parcursă de toți bicicliștii
    Găsește secunda și numele biciclistului care a atins viteza maximă
    Găsește biciclistul care a avut cea mai bună viteză medie*/
namespace Cyclometer
{
    [TestClass]
    public class CyclometerTests
    {
        [TestMethod]
        public void TotalDistanceOfOneCyclist()
        {
            Cyclist cyclist = new Cyclist("Radu", 10, new Performances[] { new Performances(1, 1), new Performances(2, 3) });
            Assert.AreEqual(125.6, GetIndividualDistance(cyclist), 0.1);
        }

        [TestMethod]
        public void TotalDistanceForMoreCyclists()
        {
            Cyclist[] cyclists = new Cyclist[] { new Cyclist("Radu", 10, new Performances[] { new Performances(1, 1), new Performances(2, 3) }),
                                                 new Cyclist("Vasile", 10, new Performances[] { new Performances(1, 1), new Performances(2, 3) })};
            Assert.AreEqual(251.2, ComputeTotalDistance(cyclists), 0.1);
        }

        [TestMethod]
        public void SecondAndCyclistNameForMaximumSpeed()
        {
            Cyclist[] cyclists = new Cyclist[] { new Cyclist("Radu", 10, new Performances[] { new Performances(1, 1), new Performances(2, 3) }),
                                                 new Cyclist("Vasile", 10, new Performances[] { new Performances(1, 1), new Performances(2, 6), new Performances(3, 5) }),
                                                 new Cyclist("Marius", 10, new Performances[] { new Performances(1, 2), new Performances(2, 5) }) };
            Assert.AreEqual(new NameSecond("Vasile", 2), FindNameOfFastestCyclist(cyclists));            
        }

        [TestMethod]
        public void IndividualTime()
        {
            Cyclist cyclist = new Cyclist("Radu", 10, new Performances[] { new Performances(1, 1), new Performances(2, 3) });
            Assert.AreEqual(2, GetIndividualTime(cyclist));
        }

        [TestMethod]
        public void BestAverageSpeed()
        {
            Cyclist[] cyclists = new Cyclist[] { new Cyclist("Radu", 10, new Performances[] { new Performances(1, 1), new Performances(2, 3) }),
                                                 new Cyclist("Vasile", 10, new Performances[] { new Performances(1, 1), new Performances(2, 6), new Performances(3, 5) }),
                                                 new Cyclist("Marius", 20, new Performances[] { new Performances(1, 2), new Performances(2, 5) }) };
            Assert.AreEqual("Marius", ComputeBestAverageSpeed(cyclists));
        }

        public struct Cyclist
        {
            public string cyclistName;
            public double wheelDiameter;
            public Performances[] performances;    
                  
            public Cyclist(string cyclistName, double wheelDiameter, Performances[] performances)
            {
                this.cyclistName = cyclistName;
                this.wheelDiameter = wheelDiameter;
                this.performances = performances;
            }
        }

        public struct Performances
        {
            public int second;
            public int rotations;
            public Performances(int second, int rotations)
            {
                this.second = second;
                this.rotations = rotations;
            }
        }

        public struct NameSecond
        {
            public string name;
            public int second;

            public NameSecond(string name, int second)
            {
                this.name = name;
                this.second = second;
            }
        }

        double ComputeWheelCircumference(Cyclist cyclist)
        {
            return cyclist.wheelDiameter * 3.14;
        }

        double GetIndividualDistance(Cyclist cyclist)
        {
            double individualDistance = 0;
            double wheelCircumference = ComputeWheelCircumference(cyclist);
            for (int i = 0; i < cyclist.performances.Length; i++)
            {
                 individualDistance += wheelCircumference * cyclist.performances[i].rotations;
            }
            return individualDistance;
        }

        double ComputeTotalDistance(Cyclist[] cyclists)
        {
            double totalDistance = 0;
            for(int i = 0; i < cyclists.Length; i++)
            {
                totalDistance += GetIndividualDistance(cyclists[i]);
            }
            return totalDistance;
        }
  
        private NameSecond FindNameOfFastestCyclist(Cyclist[] cyclists)
        {
            NameSecond nameSecond = new NameSecond("", 0);
            int maxNumberOfRotations = cyclists[0].performances[0].rotations;

            for (int i = 0; i < cyclists.Length; i++)
                for (int j = 0; j < cyclists[i].performances.Length; j++)
                {
                    if (cyclists[i].performances[j].rotations > maxNumberOfRotations)
                    {
                        maxNumberOfRotations = cyclists[i].performances[j].rotations;
                        nameSecond.name = cyclists[i].cyclistName;
                        nameSecond.second = cyclists[i].performances[j].second;
                    }
                }
            return nameSecond;
        }                   

        string ComputeBestAverageSpeed(Cyclist[] cyclists)
        {
            double maxAverageSpeed = GetIndividualDistance(cyclists[0]) / GetIndividualTime(cyclists[0]);
            double cyclistSpeed = 0;
            string name = cyclists[0].cyclistName;

            for (int i = 1; i < cyclists.Length; i++)
            {
                cyclistSpeed = GetIndividualDistance(cyclists[i]) / GetIndividualTime(cyclists[i]);
                if (cyclistSpeed > maxAverageSpeed)
                {
                    maxAverageSpeed = cyclistSpeed;
                    name = cyclists[i].cyclistName;
                }
            }
            return name; 
        }

        private int GetIndividualTime(Cyclist cyclist)
        {
            return cyclist.performances[cyclist.performances.Length - 1].second;
        }
    }
}


