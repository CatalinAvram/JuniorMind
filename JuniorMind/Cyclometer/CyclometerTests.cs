using System;
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
            Assert.AreEqual(125.6, IndividualDistance(cyclist), 0.1);
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
            Assert.AreEqual(6, FindSecondOfMaximumSpeed(cyclists));
            Assert.AreEqual("Vasile", FindNameOfFastestCyclist(cyclists));
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

        double ComputeWheelCircumference(Cyclist cyclist)
        {
            return cyclist.wheelDiameter * 3.14;
        }

        double IndividualDistance(Cyclist cyclist)
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
                totalDistance += IndividualDistance(cyclists[i]);
            }
            return totalDistance;
        }

        private int FindSecondOfMaximumSpeed(Cyclist[] cyclists)
        {
            int secondOfMaximumSpeed = cyclists[0].performances[0].second;
            for(int i = 0; i < cyclists.Length; i++)
                for(int j = 0; j < cyclists[i].performances.Length; j++)
                {
                    if (cyclists[i].performances[j].rotations > secondOfMaximumSpeed)
                        secondOfMaximumSpeed = cyclists[i].performances[j].rotations;
                }
            return secondOfMaximumSpeed;
        }

        private string FindNameOfFastestCyclist(Cyclist[] cyclists)
        {
            string nameOfFastestCyclist = cyclists[0].cyclistName;
            int secondOfMaximumSpeed = cyclists[0].performances[0].second;
            for (int i = 0; i < cyclists.Length; i++)
                for (int j = 0; j < cyclists[i].performances.Length; j++)
                {
                    if (cyclists[i].performances[j].rotations > secondOfMaximumSpeed)
                    {
                        secondOfMaximumSpeed = cyclists[i].performances[j].rotations;
                        nameOfFastestCyclist = cyclists[i].cyclistName;
                    }
                }
            return nameOfFastestCyclist;
        }
    }
}


