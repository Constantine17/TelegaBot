using DataLayer.SQLite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SQLite.Entities
{
    public class AdminEntity : INotifyPropertyChanged, IUserEntity
    {
        private long chatId;
        [Key]
        public long ChatId { get { return chatId; } set { chatId = value; OnPropertyChanged("ChatId"); } }

        private string nickname;
        public string FirstName { get { return nickname; } set { nickname = value; OnPropertyChanged("FirstName"); } }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
