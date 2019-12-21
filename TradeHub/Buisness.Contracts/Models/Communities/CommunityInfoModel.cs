using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
    // zostawiłem wszystko to samo co w CommunityModel, bo imo wszystkie te rzeczy dobrze byłoby widzieć na stronce
    public class CommunityInfoModel
    {
        public long Id { get; set; }
    
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }
    }
}
