using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public abstract class PaymentService
{
    protected PaymentService _nextService;

    public PaymentService SetNext(PaymentService service)
    {
        _nextService = service;
        return _nextService;
    }

    public abstract bool Handle(int amount);
}

public class BankTransferService : PaymentService
{
    public override bool Handle(int amount)
    {
        if (amount <= 500)
        {
            MessageBox.Show("Оплачується банківським переказом");
            return true;
        }
        else if (_nextService != null)
        {
            MessageBox.Show("Сума перевищує ліміт банківського переказу. Спробувати наступну послугу...");
            return _nextService.Handle(amount);
        }
        else
        {
            MessageBox.Show("Платіж не може бути завершений");
            return false;
        }
    }
}

public class CreditCardService : PaymentService
{
    public override bool Handle(int amount)
    {
        if (amount <= 1000)
        {
            MessageBox.Show("Оплачено кредитною карткою");
            return true;
        }
        else if (_nextService != null)
        {
            MessageBox.Show("Сума перевищує ліміт кредитної картки. Спробувати наступну послугу...");
            return _nextService.Handle(amount);
        }
        else
        {
            MessageBox.Show("Платіж не може бути завершений");
            return false;
        }
    }
}

public class PayPalService : PaymentService
{
    public override bool Handle(int amount)
    {
        if (amount <= 2000)
        {
            MessageBox.Show("Оплачено за допомогою PayPal");
            return true;
        }
        else if (_nextService != null)
        {
            MessageBox.Show("Сума перевищує ліміт PayPal. Спробуємо наступну послугу...");
            return _nextService.Handle(amount);
        }
        else
        {
            MessageBox.Show("Платіж не може бути завершений");
            return false;
        }
    }
}


