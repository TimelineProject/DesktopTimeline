using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Entity;

namespace TimeLine.Interface
{
    public interface IMessageDAO
    {
        int InsertDataByUserAndMessage(User user, Msg message);
        List<MixMsg> GetData(IDataReader reader);
        int GetNum();
    }
}
