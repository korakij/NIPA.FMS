using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Commons
{
  public interface IEntity
  {
    DateTime CreatedDate { get; set; }
    string CreatedBy { get; set; }

    DateTime UpdatedDate { get; set; }
    string UpdatedBy { get; set; }
  }
}
