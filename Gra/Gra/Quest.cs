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
        private bool DialogOccured;

        public Quest(int _id, string _name, string _description, bool _isactive, QuestStatus _status)
        {
            Id = _id;
            Name = _name;
            Description = _description;
            isActive = _isactive;
            Status = _status;
            DialogOccured = false;
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

        public bool getDialogOccured()
        { return DialogOccured; }

        public void setDialogOccured(bool b)
        { DialogOccured = b; }

    }

    public class QuestItem : Quest  // quest dostarczenia pewnego przedmiotu(przedmiotów)
    {
        private int QuestItemId;  // przedmiot który ma być dostarczony
        private int wymaganaIlosc;  // ilość tych przedmiotów

        public QuestItem(int _id, string _name, string _description, bool _isactive, QuestStatus _status, int _questitemid, int _wymaganaIlosc) : base(_id, _name, _description, _isactive, _status)
        {
            QuestItemId = _questitemid;
            wymaganaIlosc = _wymaganaIlosc;
        }

        public bool CheckCompletion(Bohater gracz)  // sprawdza czy quest został wykonany, jesli w ekwipunku jest odpowiednia ilosc wymaganego przedmiotu, zabiera je i ustawia quest na skonczony
        {
            if(getStatus()==QuestStatus.Complited)
            { return true; }
            int iloscWEkwipunku=0; 
            foreach(Przedmiot przedmiot in gracz.Ekwipunek)
            {
                if(przedmiot.getId()==QuestItemId)
                {
                    iloscWEkwipunku += przedmiot.getIlosc();
                }
            }

            if (iloscWEkwipunku >= wymaganaIlosc)
            {
                for(int i=0; i<wymaganaIlosc; i++)  // usuniecie przedmiotu(przedmiotów) questowych z ekwipunku gracza. UsunPrzedmiot powinien zapewnic poprawne usuniecie i w przypadku stackowalnych i niestackowalnych przedmiotow
                {
                    gracz.UsunPrzedmiot(QuestItemId);
                }
                setStatus(QuestStatus.Complited);

                // nadanie nagrody tutaj?

                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class QuestKillEnemy : Quest  // quest zabicia pewnej ilosci pewnego przeciwnika
    {
        private int QuestEnemyId;
        private int wymaganaIlosc;
        private int licznikZabitych;

        public QuestKillEnemy(int _id, string _name, string _description, bool _isactive, QuestStatus _status, int _questenemyid, int _wymaganailosc) : base(_id, _name, _description, _isactive, _status)
        {
            QuestEnemyId = _questenemyid;
            wymaganaIlosc = _wymaganailosc;
            licznikZabitych = 0;
        }

        public void IncrementCounter()  // przy wygranej bitwie petla przechodzaca po questach i dla questow typu QuestKillEnemy i QuestEnemyId rownymi pokonanemu potworowi wywolujaca ta funkcje?
        { licznikZabitych++; }

        public bool CheckCompletion()
        {
            if(getStatus()==QuestStatus.Success)
            { return true; }

            if (licznikZabitych >= wymaganaIlosc)
            {
                setStatus(QuestStatus.Success);

                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetQuestEnemyID()
        {
            return QuestEnemyId;
        }

        public int GetEnemiesToKill()
        {
            return wymaganaIlosc;
        }

        public int GetEnemiesKilled()
        {
            return licznikZabitych;
        }
    }

    public static class Task
    {
        public static readonly List<Quest> quests = new List<Quest>();

        // Quests IDs
        public const int questId_Cave = 1;
        public const int questId_Danger = 2;
        public const int questId_Peasant = 3;

        static Task()
        {
            loadQuests();
        }

        private static void loadQuests()
        {
            quests.Add(new Quest(questId_Cave, "Jaskinia", "Twoim zadaniem jest zabicie potworów znajdujących się w jaskini.", false, QuestStatus.NotActive));
            quests.Add(new Quest(questId_Danger, "Niebezpieczenstwo", "Wroc do krolestwa by poinformowac krola o niebezpieczenstwie, zagrazającym calej krainie.", false, QuestStatus.NotActive));
            quests.Add(new QuestKillEnemy(questId_Peasant, "Chłopi w potrzebie", "Chłop poprosił Cię o zabicie bestii niszczących ich zbiory.", false, QuestStatus.NotActive, 3, 5));
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
