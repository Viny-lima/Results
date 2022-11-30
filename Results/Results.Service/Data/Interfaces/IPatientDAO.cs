using Results.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Data.Interfaces
{
    public interface IPatientDAO : IDAO<Patient>, IDisposable
    {
    }
}
