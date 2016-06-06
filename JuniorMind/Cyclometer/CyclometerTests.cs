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
    }
}


