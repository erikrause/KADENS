using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.PostgresRepository
{
    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Prob3 { get; set; }

        public Post Post { get; set; }
    }
}
