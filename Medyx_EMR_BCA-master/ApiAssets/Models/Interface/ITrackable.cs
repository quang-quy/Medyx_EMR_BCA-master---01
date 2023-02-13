using System;

namespace Medyx.ApiAssets.Models.Interface
{
    public interface ITrackable : ITrackableCreate, ITrackableUpdate, ITrackableDelete, ITrackableMaMay, ITrackableTrangThaiHuy
    {
        new string MaMay { get; set; }
        new bool? Huy { get; set; }
        new DateTime? NgayLap { get; set; }
        new string NguoiLap { get; set; }
        new DateTime? NgaySd { get; set; }
        new string NguoiSd { get; set; }
        new DateTime? NgayHuy { get; set; }
        new string NguoiHuy { get; set; }
    }

    public interface ITrackableHuy : ITrackableDelete, ITrackableTrangThaiHuy
    {
        new bool? Huy { get; set; }
        new DateTime? NgayHuy { get; set; }
        new string NguoiHuy { get; set; }
    }

    public interface ITrackableMaMay
    {
        string MaMay { get; set; }
    }

    public interface ITrackableTrangThaiHuy
    {
        bool? Huy { get; set; }
    }

    public interface ITrackableDelete
    {
        DateTime? NgayHuy { get; set; }
        string NguoiHuy { get; set; }
    }

    public interface ITrackableUpdate
    {
        DateTime? NgaySd { get; set; }
        string NguoiSd { get; set; }
    }

    public interface ITrackableCreate
    {
        DateTime? NgayLap { get; set; }
        string NguoiLap { get; set; }
    }
    public interface ITrackableIDBA
    {
        decimal Idba { get; set; }
    }
}