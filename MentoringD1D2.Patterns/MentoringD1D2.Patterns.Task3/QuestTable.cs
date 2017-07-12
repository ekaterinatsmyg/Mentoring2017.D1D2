using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Patterns.Task3.Invokers;
using MentoringD1D2.Patterns.Task3.Observer;

namespace MentoringD1D2.Patterns.Task3
{
    public class QuestTable : ICustomObserver<Quest>
    {
        /// <summary>
        /// The quests that is in progress.
        /// </summary>
        private List<Quest> _quests;
        
        /// <summary>
        /// When quest starts the table of the quest is notifaied and the quest is added to the table of the quests that was started.
        /// </summary>
        /// <param name="value">The quest that is in progress.</param>
        public void Update(Quest value)
        {
            if (_quests == null)
            {
                _quests = new List<Quest>();
            }
            _quests.Add(value);
        }
    }
}
