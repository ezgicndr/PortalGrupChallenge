using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessLayerResult
    {
        public List<ErrorMessageObject> Errors { get; set; }

        public User Result { get; set; }

        public DataAccessLayerResult()
        {
            Errors = new List<ErrorMessageObject>();
        }

        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObject() { Code = code, Message = message });
        }
    }
}
