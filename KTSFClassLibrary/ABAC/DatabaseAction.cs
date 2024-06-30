using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.ABAC
{
    //Таблица с действиями, которые можно совершать в базе данных
    //Нужно что-бы отслеживать доступные действия пользователей
    //Update, Delete, Insert, Read

    internal class DatabaseAction
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
