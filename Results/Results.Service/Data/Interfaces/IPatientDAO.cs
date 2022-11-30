using Results.Domain.Entities;
using Results.Service.Data.Entities;
using System;

namespace ShoppingList.Data.Interfaces
{
    public interface IPatientDAO : IDAO<Patient>, IDisposable
    {
    }
}
