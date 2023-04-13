using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public enum ApplicationType
    {
        Basic,
        Premium,
        VIP
    }

    public class Application
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ApplicationType Type { get; set; }
    }
    public abstract class ApplicationHandler
    {
        protected ApplicationHandler _nextHandler;

        public ApplicationHandler SetNext(ApplicationHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual void Handle(Application application)
        {
            if (_nextHandler != null)
            {
                _nextHandler.Handle(application);
            }
        }
    }

    public class BasicSupportHandler : ApplicationHandler
    {
        public override void Handle(Application application)
        {
            if (application.Type == ApplicationType.Basic)
            {
                MessageBox.Show($"Basic support team will handle the application of {application.Name} ({application.Email}).");
            }
            else
            {
                base.Handle(application);
            }
        }
    }

    public class PremiumSupportHandler : ApplicationHandler
    {
        public override void Handle(Application application)
        {
            if (application.Type == ApplicationType.Premium)
            {
                MessageBox.Show($"Premium support team will handle the application of {application.Name} ({application.Email}).");
            }
            else
            {
                base.Handle(application);
            }
        }
    }

    public class VIPSupportHandler : ApplicationHandler
    {
        public override void Handle(Application application)
        {
            if (application.Type == ApplicationType.VIP)
            {
                MessageBox.Show($"VIP support team will handle the application of {application.Name} ({application.Email}).");
            }
            else
            {
                base.Handle(application);
            }
        }
    }
    public class SupportService
    {
        private readonly ApplicationHandler _basicHandler;
        private readonly ApplicationHandler _premiumHandler;
        private readonly ApplicationHandler _vipHandler;

        public SupportService()
        {
            _basicHandler = new BasicSupportHandler();
            _premiumHandler = new PremiumSupportHandler();
            _vipHandler = new VIPSupportHandler();

            _basicHandler.SetNext(_premiumHandler).SetNext(_vipHandler);
        }

        public void AcceptApplication(Application application)
        {
            _basicHandler.Handle(application);
        }
    }

}
