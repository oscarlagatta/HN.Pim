using Core.Common.Core;

namespace HN.Pim.Client.Entities
{
    public class SalesOrder : ObjectBase
    {

        private int _salesOrderId;
        private int _accountId;
        private decimal _amount;

        public int SalesOrderId
        {
            get { return _salesOrderId; }
            set
            {
                if (_salesOrderId != value)
                {
                    _salesOrderId = value;
                    OnPropertyChanged(() => SalesOrderId);
                }
            }
        }
       
        public int AccountId
        {
            get { return _accountId; }
            set
            {
                if (_accountId != value)
                {
                    _salesOrderId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(() => Amount);
                }
            }
        }

    }
}
