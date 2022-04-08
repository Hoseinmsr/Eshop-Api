﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Domain.UserAgg
{
    public class Wallet : BaseEntity
    {
        public Wallet(int price, string description, bool isFinally, DateTime? finallyDate, WalletType type)
        {
            if (price < 500)
                throw new InvalidDomainDataException();
            Price = price;
            Description = description;
            IsFinally = isFinally;
            FinallyDate = finallyDate;
            Type = type;
        }

        public long UserId { get;internal set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime? FinallyDate { get; private set; }
        public WalletType Type { get; private set; }


        public void Finaly(string refcode)
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            Description += $"کد پیگیری {refcode}";
        }
        public void Finaly()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
        }
    }
}
