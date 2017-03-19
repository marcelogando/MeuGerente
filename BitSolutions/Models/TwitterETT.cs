using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitSolutions.Models
{
    public class TwitterETT
    {
        private String _msg;
        private DateTime _dt;

        public string Msg
        {
            get
            {
                return _msg;
            }

            set
            {
                _msg = value;
            }
        }

        public DateTime Dt
        {
            get
            {
                return _dt;
            }

            set
            {
                _dt = value;
            }
        }
    }
}