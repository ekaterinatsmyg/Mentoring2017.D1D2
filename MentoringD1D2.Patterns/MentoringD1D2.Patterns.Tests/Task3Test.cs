using MentoringD1D2.Patterns.Task3;
using MentoringD1D2.Patterns.Task3.Enums;
using MentoringD1D2.Patterns.Task3.Invokers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MentoringD1D2.Patterns.Tests
{
    [TestClass]
    public class Task3Test
    {
        [TestMethod]
        public void GeneralTest()
        {
            var questTable = new QuestTable();
            var player = new Player();
            var quest = new Quest(player);
            quest.AddObserver(questTable);
            var commandCreator = new QuestCommandCreator(quest);
            player.AddObserver(commandCreator);

            quest.RunQuest();
            quest.Run();

            Assert.AreEqual(quest.State, QuestState.Completed);
        }
    }
}
