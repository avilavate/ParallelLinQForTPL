using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_For
{
    class AccountOps
    {

        public List<Account> Accounts { get; set; }
        public AccountOps()
        {
            this.Accounts = new List<Account>();
            Parallel.For(0, 100, i =>
            {
                System.Threading.Thread.Sleep(1000);
                var rnd = new Random();
                Accounts.Add(new Account
                {
                    Warn = false,
                    Limit = rnd.Next(1, 10) * 10000,
                    No = i,
                    OverDraft = rnd.Next(1, 10) * 10000
                });
            });
        }

        public void UpdatePredictionsParallel()
        {
            Parallel.ForEach(this.Accounts, (account) =>
            {
                account.Warn = account.OverDraft > account.Limit;
            });
        }

    }
}
