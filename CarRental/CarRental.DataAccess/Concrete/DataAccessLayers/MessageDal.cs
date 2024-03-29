﻿using CarRental.Core.DataAccess.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.Contexts;
using CarRental.Entity.Concrete;

namespace CarRental.DataAccess.Concrete.DataAccessLayers
{
    public class MessageDal : EntityRepository<Message, EfContext>, IMessageDal
    {
    }
}