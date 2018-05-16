using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public enum  QuestStatus { NotActive, Active, Success, Complited };

    public class Quest
    {
        private int Id;
        private string Name;
        private string Description;
        private bool isActive;
        private QuestStatus Status;

        public Quest(int _id, string _name, string _description, bool _isactive, QuestStatus _status)
        {
            Id = _id;
            Name = _name;
            Description = _description;
            isActive = _isactive;
            Status = _status;
        }

        public virtual Quest Kopia()
        {
            Quest temp = new Quest(this.Id, this.Name, this.Description, this.isActive, this.Status);
            return temp;
        }

        public int getId()
        { return Id; }

        public void setId(int _id)
        { Id = _id; }

        public string getName()
        { return Name; }

        public void setName(string _name)
        { Name = _name; }

        public string getDescription()
        { return Description; }

        public void setDescription(string _description)
        { Description = _description; }

        public bool getIsActive()
        { return isActive; }

        public void setIsActive(bool _isactive)
        { isActive = _isactive; }

        public QuestStatus getStatus()
        { return Status; }

        public void setStatus(QuestStatus _status)
        { Status = _status; }
    }

    public static class Task
    {
        public static readonly List<Quest> quests = new List<Quest>();

        // Quests IDs
        public const int questId_Cave = 1;
        public const int questId_Danger = 2;

        static Task()
        {
            loadQuests();
        }

        private static void loadQuests()
        {
            quests.Add(new Quest(questId_Cave, "Jaskinia", "Twoim zadaniem jest zabicie potworów znajdujących się w jaskini.", false, QuestStatus.NotActive));
            quests.Add(new Quest(questId_Danger, "Niebezpieczenstwo", "Wroc do krolestwa by poinformowac krola o niebezpieczenstwie, zagrazającym calej krainie.", false, QuestStatus.NotActive));
        }

        public static Quest questsById(int _id)
        {
            foreach (Quest quest in quests)
            {
                if (quest.getId() == _id)
                    return quest;
            }

            return null;
        }
    }
}
