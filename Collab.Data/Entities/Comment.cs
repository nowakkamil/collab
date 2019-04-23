using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Data.Entities
{    
 public class Comment
 {
      public string Content { get; set; }
      public DateTime DateofMade { get; set; }
      public DateTime DateOfEdit { get; set; }

      public ApplicationUser User { get; set; }
      //prop atricle
  }
}

