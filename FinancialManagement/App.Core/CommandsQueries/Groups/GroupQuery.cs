using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CommandsQueries.Group
{
    public class GroupQuery
    {
        public int Id { get; set; }
        public string Nature { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ParentGroupId { get; set; }
    }
}
