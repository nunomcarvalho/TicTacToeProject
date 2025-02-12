using TicTacToe;

namespace TicTacToeTests
{
    public class BoardTests
    {
        private Board _board;

        [SetUp]
        public void Setup()
        {
            _board = new Board(3, 3);
        }

        [Test]
        public void Test_ValidMove_ShouldReturnInProgress()
        {
            var result = _board.SetMove(0, 0, "X");

            Assert.That(result, Is.EqualTo(Board.EBoardStatus.InProgess));
        }

        [Test]
        public void Test_InvalidMove_ShouldReturnInvalidMove()
        {
            var result = _board.SetMove(3, 3, "X"); // out of bound

            Assert.That(result, Is.EqualTo(Board.EBoardStatus.InvalidMove));
        }

        [Test]
        public void Test_IsDraw_ShouldReturnDraw()
        {
            // moq values
            _board.SetMove(0, 0, "X");
            _board.SetMove(1, 0, "X");
            _board.SetMove(2, 0, "O");
            _board.SetMove(0, 1, "O");
            _board.SetMove(1, 1, "O");
            _board.SetMove(2, 1, "X");
            _board.SetMove(0, 2, "X");
            _board.SetMove(1, 2, "O");
            _board.SetMove(2, 2, "X");

            var result = _board.BoardStatus();

            Assert.That(result, Is.EqualTo(Board.EBoardStatus.Draw));
        }

        [Test]
        public void Test_GameWon_ShouldReturnGameWon()
        {
            // moq values
            _board.SetMove(0, 0, "X");
            _board.SetMove(1, 0, "X");
            _board.SetMove(2, 0, "X");

            var result = _board.BoardStatus();

            Assert.That(result, Is.EqualTo(Board.EBoardStatus.GameWon));
        }

        [Test]
        public void Test_AreAllElementsInRowEqual_ShouldReturnTrueWhenAllAreEqual()
        {
            // moq values
            _board.SetMove(0, 0, "X");
            _board.SetMove(1, 0, "X");
            _board.SetMove(2, 0, "X");

            var result = _board.AreAllElementsInRowEqual(0);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_AreAllElementsInRowEqual_ShouldReturnFalseWhenSomeAreDifferent()
        {
            // moq values
            _board.SetMove(0, 0, "X");
            _board.SetMove(1, 0, "Y");
            _board.SetMove(2, 0, "X");

            var result = _board.AreAllElementsInRowEqual(0);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Test_AreAllElementsInColumnEqual_ShouldReturnTrueWhenAllAreEqual()
        {
            // moq values
            _board.SetMove(0, 0, "X");
            _board.SetMove(0, 1, "X");
            _board.SetMove(0, 2, "X");

            var result = _board.AreAllElementsInColumnEqual(0);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_AreAllElementsInColumnEqual_ShouldReturnFalseWhenSomeAreDifferent()
        {
            // moq values
            _board.SetMove(0, 0, "X");
            _board.SetMove(0, 1, "Y");
            _board.SetMove(0, 2, "X");

            var result = _board.AreAllElementsInColumnEqual(0);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Test_AreAllElementsInDiagonalEqual_ShouldReturnTrueWhenAllAreEqualLeft()
        {
            // moq values
            _board.SetMove(0, 0, "X");
            _board.SetMove(1, 1, "X");
            _board.SetMove(2, 2, "X");

            var result = _board.AreAllDiagonalElementsEqual();

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_AreAllElementsInDiagonalEqual_ShouldReturnTrueWhenAllAreEqualRight()
        {
            // moq values
            _board.SetMove(0, 2, "X");
            _board.SetMove(1, 1, "X");
            _board.SetMove(2, 0, "X");

            var result = _board.AreAllDiagonalElementsEqual();

            Assert.That(result, Is.True);
        }
    }
}