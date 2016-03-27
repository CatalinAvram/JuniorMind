using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*Trebuie pus parchet laminat într-o cameră de N x M mp. Dimensiunea unei plăci de parchet e de A x B mp. Pierderile 
sunt de 15%. De cât parchet e nevoie?*/

namespace Parquet
{
    [TestClass]
    public class ParquetTests
    {
        [TestMethod]
        public void piecesNeeded()
        {
            Assert.AreEqual(14, CalculateParquetPieces(6, 4, 2, 1, 15));
        }
        decimal CalculateParquetPieces(int roomLength, int roomWidth, int pieceLength,  int pieceWidth, decimal losses)
        {
            int roomDimension = roomLength * roomWidth;
            int pieceDimension = pieceLength * pieceWidth;
            decimal numberOfPieces = roomDimension / pieceDimension;
            decimal supplemantaryPieces = losses / 100 * numberOfPieces;

            return Math.Round(numberOfPieces + supplemantaryPieces);
        }
    }
}
