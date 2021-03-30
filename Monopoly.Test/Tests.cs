using Monopoly.Command.Commands;
using Monopoly.Player;
using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;
using NUnit.Framework;

namespace Monopoly.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPayCommand()
        {
            var pay = new PayCommand(600);
            var playerA = new NPCPlayer(null, null, 700);
            var playerB = new NPCPlayer(null, null, 500);

            pay.Execute(null, playerA, playerB);

            Assert.AreEqual(playerA.GetMoney(), 100);
            Assert.AreEqual(playerB.GetMoney(), 1100);
        }

        [Test]
        public void TestBuy()
        {
            Material wood = new Wood();
            PawnShape shoe = PawnShape.Shoe;
            PawnFigure shoeFigure = new PawnFigure(shoe, wood);

            Board board = Board.Build(15);
            board.AddPlayer(new NPCPlayer(board.GetTiles()[0], shoeFigure, 1000));
            board.NextTurn();

            //Console.Writeline();
            //Assert.AreEqual(playerB.GetMoney(), 1100);
        }
    }
}