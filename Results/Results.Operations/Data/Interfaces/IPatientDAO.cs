using Results.Operations.Data.Entities;
using System;

namespace Results.Operations.Data.Interfaces
{
    public interface IPatientDAO : IDAO<Patient>, IDisposable
    {
    }
}
