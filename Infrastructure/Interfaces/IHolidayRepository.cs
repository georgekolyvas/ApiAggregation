﻿using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IHolidayRepository : IGenericRepository<Holiday>
{
    Task<Holiday?> GetHoliday();
}
