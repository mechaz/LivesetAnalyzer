using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivesetAnalyzer
{
    class AnalyzerException: Exception
    {
	
	public AnalyzerException(string msg): base(msg) { }

    public AnalyzerException(string msg, Exception innerException): base (msg, innerException) {}


    }
}
