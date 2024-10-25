using Domain.Entities;
using Infrastructure.Interfaces;
using System.Linq;

namespace Infrastructure;

public class SortedData
{
    private readonly IUnitOfWork _unitOfWork;

    public SortedData(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //public async Task<List<Holiday>> SortHolidayData (List<Holiday> data)
    //{
    //    fetchData.Holiday = await _unitOfWork.Holiday.GetHoliday();

    //    return result;

    //}
}
