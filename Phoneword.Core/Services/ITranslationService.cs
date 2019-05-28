using System;
using System.Collections.Generic;
using System.Text;

namespace Phoneword.Core.Services
{
    public interface ITranslationService
    {
        string ToNumber(string raw);
    }
}
