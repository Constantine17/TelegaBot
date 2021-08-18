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
    public class AdminEntity : INotifyPropertyChanged
    {
        private long chatId;
        [Key]
        public long ChatId { get { return chatId; } set { chatId = value; OnPropertyChanged("ChatId"); } }

        private string nickname;
        public string Nickname { get { return nickname; } set { nickname = value; OnPropertyChanged("Nickname"); } }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
