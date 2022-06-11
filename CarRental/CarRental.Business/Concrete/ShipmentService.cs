using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class ShipmentService : CoreService<Shipment, IShipmentDal>, IShipmentService
    {
        public ShipmentService(IShipmentDal shipmentDal) : base(shipmentDal)
        {
        }
    }
}