using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.Interface
{
    public interface IDatabase
    {
        MySqlCommand GetCommand();
        void ConnectDb();
        void CloseDb();
        void CreateCommand(string command);
        int DataNum(string command);
        int Execute(string com);
        IDataReader GetReader(string command);
    }
}
