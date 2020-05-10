using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GSMElectronicNB.Models
{
    public class Message
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Text { get; set; }


        public override string ToString()
        {
            return this.Text;
        }
    }
}
