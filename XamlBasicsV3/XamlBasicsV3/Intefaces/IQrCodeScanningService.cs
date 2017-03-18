using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBasicsV3.Interfaces
{
    public interface IQrCodeScanningService
    {
        Task<string> ScanAsync();
    }
}
